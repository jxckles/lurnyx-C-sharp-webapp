using AutoMapper;
using Lurnyx.Data.Models;
using Lurnyx.Services.Interfaces;
using Lurnyx.Services.ServiceModels;
using Lurnyx.WebApp.Authentication;
using Lurnyx.WebApp.Models;
using Lurnyx.WebApp.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lurnyx.WebApp.Controllers
{
    [Authorize(Roles = "SUPER_ADMIN,USER")]
    [Route("User/[controller]/[action]")]
    public class ProfileController : ControllerBase<ProfileController>
    {
        private readonly IUserService _userService;
        private readonly SignInManager _signInManager;

        public ProfileController(
            IHttpContextAccessor httpContextAccessor,
            ILoggerFactory loggerFactory,
            IConfiguration configuration,
            IUserService userService,
            SignInManager signInManager,
            IMapper mapper = null)
            : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        /// <summary>
        /// GET /User/Profile
        /// Displays the user's profile, or redirects to the dashboard on error.
        /// </summary>
        /// <returns>The view with the user's profile details, or a redirect to the dashboard if an unexpected error occurs.</returns>
        /// <exception cref="Exception">Logs an error and displays a generic error message when an unexpected error occurs.</exception>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var user = await _userService.GetCurrentUserDetailsAsync();
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading user profile.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction("Index", "Dashboard");
            }
        }

        /// <summary>
        /// Handles the HTTP GET request to load the current user's profile for editing.
        /// Retrieves the current user's details via the service and returns the edit view with the user's information.
        /// In case of an exception, logs the error, sets an error message, and redirects to the profile index view.
        /// </summary>
        /// <returns>The edit view with the current user's details, or a redirect to the profile index view in case of an error.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            try
            {
                var user = await _userService.GetCurrentUserDetailsAsync();
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading user profile for editing.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// Handles the POST request to update the current user's profile.
        /// </summary>
        /// <param name="userViewModel">The view model containing the updated user information.</param>
        /// <returns>A redirect to the Index action.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserDto userViewModel)
        {
            try
            {
                User updatedUser = await _userService.UpdateCurrentUserProfileAsync(userViewModel);
                await _signInManager.RefreshSignInAsync(updatedUser);
                TempData["ToastSuccess"] = "Profile updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user profile.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// Handles the HTTP GET request for the change photo page.
        /// Tries to load the current user via the service, then returns the view with the user's details.
        /// Handles and logs exceptions, setting error messages and redirecting to the profile view.
        /// </summary>
        /// <returns>A redirection to the profile view with an error message, or the change photo view with the user's details.</returns>
        [HttpGet]
        public async Task<IActionResult> ChangePhoto()
        {
            try
            {
                var user = await _userService.GetCurrentUserDetailsAsync();
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading change photo page.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// Handles the POST request to change the user's profile photo.
        /// </summary>
        /// <param name="model">The view model containing the new profile photo.</param>
        /// <returns>A redirect to the Index action.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePhoto(UserDto model)
        {
            try
            {
                User updatedUser = await _userService.UpdateCurrentUserProfileAsync(model);
                await _signInManager.RefreshSignInAsync(updatedUser);
                TempData["ToastSuccess"] = "Profile photo updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error changing profile photo.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(ChangePhoto));
            }
        }

        /// <summary>
        /// Displays the change password form.
        /// </summary>
        /// <returns>The ChangePassword view.</returns>
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        /// <summary>
        /// Handles the POST request to change the user's password.
        /// Validates the model, checks the current password, and attempts to change the password using the provided new password.
        /// If successful, redirects to the Index view; otherwise, returns the ChangePassword view with a model error.
        /// </summary>
        /// <param name="model">The view model containing the current and new passwords for changing the password.</param>
        /// <returns>Redirects to Index view if successful; otherwise, returns the ChangePassword view with model errors.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var result = await _userService.ChangePasswordAsync(model.CurrentPassword, model.NewPassword);
                if (result)
                {
                    TempData["ToastSuccess"] = "Your password has been changed successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid current password.");
                    TempData["ToastError"] = Resources.Messages.Errors.PasswordIncorrect;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while changing the password.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
            }

            return View(model);
        }
    }
}