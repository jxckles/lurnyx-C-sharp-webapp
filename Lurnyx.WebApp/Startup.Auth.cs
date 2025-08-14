using Lurnyx.WebApp.Authentication;
using Lurnyx.WebApp.Extensions.Configuration;
using Lurnyx.Resources.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Lurnyx.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;

namespace Lurnyx.WebApp
{
    // Authorization configuration
    internal partial class StartupConfigurer
    {
        private readonly SymmetricSecurityKey _signingKey;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly TokenProviderOptions _tokenProviderOptions;

        /// <summary>
        /// Configure authorization
        /// </summary>
        private void ConfigureAuthorization()
        {
            var token = Configuration.GetTokenAuthentication();
            var tokenProviderOptionsFactory = this._services.BuildServiceProvider().GetService<TokenProviderOptionsFactory>();
            var tokenValidationParametersFactory = this._services.BuildServiceProvider().GetService<TokenValidationParametersFactory>();
            var tokenValidationParameters = tokenValidationParametersFactory.Create();

            this._services.AddAuthentication(Const.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            })
            .AddCookie(Const.AuthenticationScheme, options =>
            {
                options.Cookie = new CookieBuilder()
                {
                    IsEssential = true,
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest,
                    Name = $"{this._environment.ApplicationName}_{token.CookieName}"
                };
                options.LoginPath = new PathString("/Account/Login");
                options.AccessDeniedPath = new PathString("/html/Forbidden.html");
                options.ReturnUrlParameter = "ReturnUrl";
                options.TicketDataFormat = new CustomJwtDataFormat(SecurityAlgorithms.HmacSha256, _tokenValidationParameters, Configuration, tokenProviderOptionsFactory);

                options.Events = new CookieAuthenticationEvents
                {
                    OnValidatePrincipal = async context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userIdClaim = context.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                        if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
                        {
                            context.RejectPrincipal();
                            await context.HttpContext.SignOutAsync(Const.AuthenticationScheme);
                            return;
                        }

                        try
                        {
                            var user = await userService.GetUserByIdAsync(userId);
                            if (user == null || user.DeletedAt > DateTime.MinValue)
                            {
                                context.RejectPrincipal();
                                await context.HttpContext.SignOutAsync(Const.AuthenticationScheme);
                            }
                        }
                        catch (KeyNotFoundException)
                        {
                            context.RejectPrincipal();
                            await context.HttpContext.SignOutAsync(Const.AuthenticationScheme);
                        }
                    }
                };
            });

            this._services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAuthenticatedUser", policy =>
                {
                    policy.RequireAuthenticatedUser();
                });
            });

            this._services.AddMvc(options =>
            {
                options.Filters.Add(new AuthorizeFilter("RequireAuthenticatedUser"));
            });
        }
    }
}
