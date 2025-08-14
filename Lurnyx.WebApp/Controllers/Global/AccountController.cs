using AutoMapper;
using Lurnyx.Services.Interfaces;
using Lurnyx.Services.Manager;
using Lurnyx.Services.ServiceModels;
using Lurnyx.WebApp.Authentication;
using Lurnyx.WebApp.Models;
using Lurnyx.WebApp.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.WebApp.Controllers
{
    [AllowAnonymous]
    public class AccountController : ControllerBase<AccountController>
    {
        private readonly SessionManager _sessionManager;
        private readonly SignInManager _signInManager;
        private readonly TokenValidationParametersFactory _tokenValidationParametersFactory;
        private readonly TokenProviderOptionsFactory _tokenProviderOptionsFactory;
        private readonly IConfiguration _appConfiguration;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        public AccountController(
                            SignInManager signInManager,
                            IHttpContextAccessor httpContextAccessor,
                            ILoggerFactory loggerFactory,
                            IConfiguration configuration,
                            IMapper mapper,
                            IUserService userService,
                            IEmailService emailService,
                            TokenValidationParametersFactory tokenValidationParametersFactory,
                            TokenProviderOptionsFactory tokenProviderOptionsFactory) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            this._sessionManager = new SessionManager(this._session);
            this._signInManager = signInManager;
            this._tokenProviderOptionsFactory = tokenProviderOptionsFactory;
            this._tokenValidationParametersFactory = tokenValidationParametersFactory;
            this._appConfiguration = configuration;
            this._userService = userService;
            this._emailService = emailService;
        }

        #region Registration
        
        /// <summary>
        /// Displays the registration view for new user sign-up.
        /// </summary>
        /// <returns>The registration view.</returns>
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.LoginView = false;
            return View();
        }

        /// <summary>
        /// Handles the user registration process by accepting user details in the form of a UserDto model.
        /// If registration is successful, redirects to the login page; otherwise, displays error messages.
        /// </summary>
        /// <param name="model">The UserDto model containing user registration information.</param>
        /// <returns>A redirection to the login view if successful, otherwise the registration view with error messages.</returns>
        [HttpPost]
        public async Task<IActionResult> Register(UserDto model)
        {
            ViewBag.LoginView = false;
            try
            {
                await _userService.RegisterUserAsync(model);
                TempData["ToastSuccess"] = "Registration successful. Login to continue with your account.";
                return RedirectToAction("Login", "Account");
            }
            catch(InvalidDataException ex)
            {
                TempData["ToastError"] = ex.Message;
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                TempData["ToastError"] = Resources.Messages.Errors.ServerError;
            }
            return View(model);
        }

        #endregion

        #region Login / Logout

        /// <summary>
        /// Handles GET requests for the login page. Clears the session and redirects to the login view.
        /// </summary>
        /// <returns>The login view.</returns>
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.LoginView = false;
            TempData["returnUrl"] = System.Net.WebUtility.UrlDecode(HttpContext.Request.Query["ReturnUrl"]);
            this._sessionManager.Clear();
            this._session.SetString("SessionId", System.Guid.NewGuid().ToString());
            return this.View();
        }


        /// <summary>
        /// Handles the POST request for user login.
        /// Authenticates the user using the credentials provided in the login view model.
        /// If authentication is successful, signs in the user, sets session variables, and redirects to the appropriate dashboard based on user role.
        /// If authentication fails, returns the login view with an error message.
        /// </summary>
        /// <param name="model">The login view model containing user credentials.</param>
        /// <param name="returnUrl">The return URL to redirect to after successful login.</param>
        /// <returns>A redirection to the user's dashboard if successful; otherwise, the login view with an error message.</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            ViewBag.LoginView = false;
            this._session.SetString("HasSession", "Exist");

            var user = await _userService.AuthenticateUserAsync(model.Email, model.Password);

            if (user != null)
            {
                await this._signInManager.SignInAsync(user);
                this._session.SetString("UserId", user.Id.ToString());
                this._session.SetString("UserFirstName", user.FirstName);
                this._session.SetString("UserLastName", user.LastName);
                this._session.SetString("UserRole", user.Role.ToString());

                if (user.Role == UserRole.ADMIN)
                {
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            else
            {
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.InvalidCredentials;
                return View(model);
            }   
        }

        /// <summary>
        /// Signs out the currently authenticated user and redirects them to the login page.
        /// </summary>
        /// <returns>A redirection to the login view.</returns>
        [HttpPost]
        public async Task<IActionResult> SignOutUser()
        {
            await this._signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        #endregion

        #region Password Reset

        /// <summary>
        /// Displays the Forgot Password view.
        /// </summary>
        /// <returns>The ForgotPassword view.</returns>
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewBag.LoginView = false;
            return View();
        }

        /// <summary>
        /// Handles POST requests for the Forgot Password process. Generates a password reset token for the specified email
        /// and sends an email with the reset link if the email is valid. Always returns a generic confirmation view to 
        /// prevent email enumeration attacks.
        /// </summary>
        /// <param name="model">The ForgotPasswordViewModel containing the user's email address.</param>
        /// <returns>The ForgotPassword view if the model state is invalid, otherwise the ForgotPasswordConfirmation view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            ViewBag.LoginView = false;
            if (ModelState.IsValid)
            {
                var token = await _userService.GeneratePasswordResetTokenAsync(model.Email);

                if (!string.IsNullOrEmpty(token))
                {
                    var resetLink = Url.Action("ResetPassword", "Account", new { token }, Request.Scheme);
                    var subject = "Reset Your Lurnyx Password";
                    var message = $"Please reset your password by clicking this link: <a href='{resetLink}'>Reset Password</a>. This link will expire in one hour.";

                    await _emailService.SendEmailAsync(model.Email, subject, message);
                }

                // To prevent email enumeration, always show a generic confirmation message.
                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }
        
        /// <summary>
        /// Displays the confirmation view after a user has submitted their email address for a password reset.
        /// Always returns the ForgotPasswordConfirmation view.
        /// </summary>
        /// <returns>The ForgotPasswordConfirmation view.</returns>
        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            ViewBag.LoginView = false;
            return View();
        }

        /// <summary>
        /// Displays the Reset Password view if the token is valid, or redirects to the Login view with an error message if the token is invalid.
        /// </summary>
        /// <param name="token">The password reset token.</param>
        /// <returns>The ResetPassword view if the token is valid, otherwise a redirection to the Login view.</returns>
        [HttpGet]
        public IActionResult ResetPassword(string token)
        {
            ViewBag.LoginView = false;
            if (string.IsNullOrWhiteSpace(token))
            {
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.MissingToken;
                return RedirectToAction("Login");
            }

            var model = new ResetPasswordViewModel { Token = token };
            return View(model); 
        }

        /// <summary>
        /// Handles the POST request to reset a user's password.
        /// Validates the model and attempts to reset the password using the provided token and new password.
        /// If successful, redirects to the ResetPasswordConfirmation view; otherwise, returns the ResetPassword view with an error message.
        /// </summary>
        /// <param name="model">The view model containing the token and new password for resetting the password.</param>
        /// <returns>Redirects to ResetPasswordConfirmation view if successful; otherwise, returns the ResetPassword view with model errors.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            ViewBag.LoginView = false;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userService.ResetPasswordAsync(model.Token, model.Password);

            if (result)
            {
                return RedirectToAction("ResetPasswordConfirmation");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "This password reset link is invalid or has expired. Please try again.");
                return View(model);
            }
        }
        
        /// <summary>
        /// Displays a confirmation view after a user has successfully reset their password.
        /// </summary>
        /// <returns>The ResetPasswordConfirmation view.</returns>
        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            ViewBag.LoginView = false;
            return View();
        }
        
        #endregion
    }
}
