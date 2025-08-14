using System.Security.Claims;
using AutoMapper;
using Lurnyx.Resources.Constants;
using Lurnyx.Services.Interfaces;
using Lurnyx.Services.ServiceModels;
using Lurnyx.WebApp.Authentication;
using Lurnyx.WebApp.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.WebApp.Controllers.Admin
{
    [Authorize(Roles = "SUPER_ADMIN,ADMIN")]
    [Route("Admin/[controller]/[action]")]
    public class UsersController : ControllerBase<UsersController>
    {
        private readonly SignInManager _signInManager;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        /// <summary>
        /// Constructor
        /// </summary>
        public UsersController(
                            SignInManager signInManager,
                            IConfiguration configuration,
                            ILoggerFactory loggerFactory,
                            IHttpContextAccessor httpContextAccessor,
                            IUserService userService,
                            IEmailService emailService,
                            IMapper mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _signInManager = signInManager;
            _userService = userService;
            _emailService = emailService;
        }

        #region Create
        
        /// <summary>
        /// GET /Admin/Users/Create
        /// </summary>
        /// <returns>The view to create a new user.</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View(new UserDto());
        }

        /// <summary>
        /// Handles the user creation process by accepting user details in the form of a UserDto model.
        /// If creation is successful, redirects to the user list page; otherwise, displays error messages.
        /// </summary>
        /// <param name="model">The UserDto model containing user registration information.</param>
        /// <returns>A redirection to the user list page if successful, otherwise the registration view with error messages.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDto model)
        {
            try
            {
                await _userService.AddNewUserAsync(model);
                if (model.Role == UserRole.USER)
                {
                    var redirectLink = Url.Action("Login", "Account", "",Request.Scheme);
                    var subject = "Welcome to Lurnyx - Your Learning Journey Begins!";
                    var message = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 800px; margin: 0;'>
                        <h2 style='color: #2c3e50;'>Welcome to Lurnyx, {model.FirstName}!</h2>
    
                        <p>We're thrilled to have you join our community of lifelong learners. Here are your temporary login credentials:</p>
    
                        <div style='background: #f8f9fa; padding: 15px; border-radius: 5px; margin: 20px 0;'>
                            <p><strong>Email:</strong> {model.Email}</p>
                            <p><strong>Password:</strong> @deFaultPass12</p>
                        </div>
    
                        <p>
                            For security reasons, we strongly recommend resetting your password after first login at the user profile section
                        </p>
    
                        <a href='{redirectLink}' 
                           style='display: inline-block; background: #3498db; color: white; 
                                  padding: 10px 20px; text-decoration: none; border-radius: 5px; 
                                  margin: 15px 0;'>
                            Get Started Now
                        </a>
    
                        <h3 style='color: #2c3e50; margin-top: 25px;'>Getting Started Tips:</h3>
                        <ul>
                            <li>Explore different training categroies</li>
                            <li>Download learning resources</li>
                            <li>Customize your profile</li>
                        </ul>
                        </br>

                        <p>Happy learning!<br>
                        <strong>The Lurnyx Team</strong></p>
                        
                        <hr style='border: 0; border-top: 1px solid #eee; margin: 20px 0;'>
                        <p style='font-size: 12px; color: #7f8c8d;'>
                            For security reasons, never share your password. If you didn't request this account, 
                            please disiregard this.
                        </p>
                    </div>";
                    await _emailService.SendEmailAsync(model.Email, subject, message);
                }
                TempData["ToastSuccess"] = "User created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidDataException ex)
            {
                TempData["ToastError"] = ex.Message;
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new user.");
                TempData["ToastError"] = "An unexpected error occurred while creating the user.";
                return View(model);
            }
        }

        #endregion

        #region Read

        /// <summary>
        /// GET /Admin/Users
        /// Displays a paginated list of users, filtered by search query and user role.
        /// </summary>
        /// <param name="searchQuery">The search query to filter users by name or email.</param>
        /// <param name="userRoleFilter">The role to filter users by (e.g., Admin, User).</param>
        /// <param name="page">The page number to display.</param>
        /// <returns>The view to list all users, filtered by the provided criteria.</returns>
        [HttpGet]
        public async Task<IActionResult> Index(string searchQuery, string userRoleFilter, int page = 1)
        {
            try
            {
                Enum.TryParse<UserRole>(userRoleFilter, true, out var roleEnum);

                // Pass the filters to the service
                var paginatedUsers = await _userService.GetPaginatedUsersAsync(page, Const.PageSize, searchQuery, roleEnum);

                ViewData["CurrentSearch"] = searchQuery;
                ViewData["CurrentRoleFilter"] = userRoleFilter;

                return View(paginatedUsers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching users for admin panel.");
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// GET /Admin/Users/Details/{id}
        /// Displays the details of the user with the given ID.
        /// </summary>
        /// <param name="id">The ID of the user to display.</param>
        /// <returns>
        ///     The view with the user details, or a 404 if the user does not exist.
        ///     Logs an error and displays a generic error message when an unexpected error occurs.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                return View(user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching details for User ID {UserId}", id);
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(Index));
            }
        }

        #endregion

        #region Update

        /// <summary>
        /// GET /Admin/Users/Edit/{id}
        /// </summary>
        /// <param name="id">The ID of the user to edit.</param>
        /// <returns>The edit user view with the user data, or a 404 if the user does not exist.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                return View(user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading user for editing. ID: {UserId}", id);
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// Handles the HTTP POST request for updating a user.
        /// Checks that the IDs match, then attempts to update the user via the service.
        /// On success, sets a success message and redirects to the user details view.
        /// Handles and logs exceptions, setting error messages and redirecting to the edit view.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="userViewModel">The view model containing the updated user data.</param>
        /// <returns>A redirection to the user details view if successful, otherwise the edit view with an error message.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserDto userViewModel)
        {
            if (id != userViewModel.Id)
            {
                return BadRequest();
            }

            try
            {
                await _userService.UpdateUserAsync(userViewModel);
                TempData["ToastSuccess"] = "User updated successfully.";
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user. ID: {UserId}", id);
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;
                return View(userViewModel);
            }
        }

        #endregion

        #region Delete
        
        /// <summary>
        /// Handles the HTTP POST request for deleting a user by their ID.
        /// Calls the service to delete the user and logs errors if encountered.
        /// On success, sets a success message and redirects to the user index page.
        /// Handles and logs exceptions, returning a 404 for not found users and setting an error message for unexpected errors.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A redirect to the user index page.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var currentUserIdValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                await _userService.DeleteUserAsync(id);
                TempData["ToastSuccess"] = "User deleted successfully.";

                if (int.TryParse(currentUserIdValue, out int currentUserId) && id == currentUserId)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user. ID: {UserId}", id);
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;
            }
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
