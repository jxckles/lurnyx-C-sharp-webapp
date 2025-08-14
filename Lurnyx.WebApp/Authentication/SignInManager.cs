﻿using System.Security.Claims;
using System.Security.Principal;
using Lurnyx.WebApp.Extensions.Configuration;
using Lurnyx.WebApp.Models;
using Lurnyx.Resources.Constants;
using Lurnyx.Data.Models;
using Microsoft.AspNetCore.Authentication;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.WebApp.Authentication
{
    /// <summary>
    /// SignInManager
    /// </summary>
    public class SignInManager
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public LoginUser user { get; set; }

        /// <summary>
        /// Initializes a new instance of the SignInManager class.
        /// </summary>
        public SignInManager()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SignInManager class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="accountService">The account service.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        public SignInManager(IConfiguration configuration,
                             IHttpContextAccessor httpContextAccessor)
        {
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            user = new LoginUser();
        }

        /// <summary>
        /// Gets the claims identity.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The successfully completed task</returns>
        public Task<ClaimsIdentity> GetClaimsIdentity(string username, string password)
        {
            ClaimsIdentity claimsIdentity = null;
            User userData = new User();

            user.loginResult = LoginResult.Success;
            // TODO this._accountService.AuthenticateUser(username, password, ref userData);

            if (user.loginResult == LoginResult.Failed)
            {
                return Task.FromResult<ClaimsIdentity>(null);
            }

            user.userData = userData;
            claimsIdentity = CreateClaimsIdentity(userData);
            return Task.FromResult(claimsIdentity);
        }

        /// <summary>
        /// Creates the claims identity.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Instance of ClaimsIdentity</returns>
        public ClaimsIdentity CreateClaimsIdentity(User user)
        {
            // The list of "claims" is the user's identity card.
            // It contains all the key facts about them.

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String, Const.Issuer),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName, ClaimValueTypes.String, Const.Issuer),
                new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.String, Const.Issuer),
                new Claim(ClaimTypes.Role, user.Role.ToString(), ClaimValueTypes.String, Const.Issuer)

            };

            if (!string.IsNullOrEmpty(user.ProfileImageUrl))
            {
                claims.Add(new Claim("profile_image_url", user.ProfileImageUrl, ClaimValueTypes.String, Const.Issuer));
            }

            return new ClaimsIdentity(claims, Const.AuthenticationScheme);
        }

        /// <summary>
        /// Creates the claims principal.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <returns>Created claims principal</returns>
        public IPrincipal CreateClaimsPrincipal(ClaimsIdentity identity)
        {
            var identities = new List<ClaimsIdentity>
            {
                identity
            };
            return this.CreateClaimsPrincipal(identities);
        }

        /// <summary>
        /// Creates the claims principal.
        /// </summary>
        /// <param name="identities">The identities.</param>
        /// <returns>Created claims principal</returns>
        public IPrincipal CreateClaimsPrincipal(IEnumerable<ClaimsIdentity> identities)
        {
            var principal = new ClaimsPrincipal(identities);
            return principal;
        }

        /// <summary>
        /// Signs out the current user and signs them back in with updated claims.
        /// This is useful after a user profile has been updated.
        /// </summary>
        /// <param name="user">The user object with updated information.</param>
        public async Task RefreshSignInAsync(User user)
        {
            // Get the authentication properties from the current sign-in context
            var authResult = await _httpContextAccessor.HttpContext.AuthenticateAsync(Const.AuthenticationScheme);
            
            // Check if the user was authenticated and get their properties (like IsPersistent)
            var authProperties = authResult?.Properties ?? new AuthenticationProperties();

            // Sign the user in again with the updated claims and original properties
            await SignInAsync(user, authProperties.IsPersistent);
}

        /// <summary>
        /// Signs in user asynchronously
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="isPersistent">if set to <c>true</c> [is persistent].</param>
        public async Task SignInAsync(User user, bool isPersistent = false)
        {
            var claimsIdentity = this.CreateClaimsIdentity(user);
            var principal = this.CreateClaimsPrincipal(claimsIdentity);
            await this.SignInAsync(principal, isPersistent);
        }

        /// <summary>
        /// Signs in user asynchronously
        /// </summary>
        /// <param name="principal">The principal.</param>
        /// <param name="isPersistent">if set to <c>true</c> [is persistent].</param>
        public async Task SignInAsync(IPrincipal principal, bool isPersistent = false)
        {
            var token = _configuration.GetTokenAuthentication();
            await _httpContextAccessor
                .HttpContext
                .SignInAsync(
                            Const.AuthenticationScheme,
                            (ClaimsPrincipal)principal,
                            new AuthenticationProperties
                            {
                                ExpiresUtc = DateTime.UtcNow.AddMinutes(token.ExpirationMinutes),
                                IsPersistent = isPersistent,
                                AllowRefresh = false
                            });
        }

        /// <summary>
        /// Signs out user asynchronously
        /// </summary>
        public async Task SignOutAsync()
        {
            var token = _configuration.GetTokenAuthentication();
            await _httpContextAccessor.HttpContext.SignOutAsync(Const.AuthenticationScheme);
        }
    }
}
