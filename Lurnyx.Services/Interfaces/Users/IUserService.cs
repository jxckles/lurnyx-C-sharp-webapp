using Lurnyx.Data.Models;
using Lurnyx.Resources.Constants;
using Lurnyx.Services.ServiceModels;

namespace Lurnyx.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for the service layer that handles business logic for Users.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="model">The view model containing the new user's data.</param>
        Task RegisterUserAsync(UserDto model);

        /// <summary>
        /// Adds a new user, typically by an administrator.
        /// </summary>
        /// <param name="model">The view model containing the new user's data.</param>
        Task AddNewUserAsync(UserDto model);

        /// <summary>
        /// Generates a password reset token for a user.
        /// </summary>
        /// <param name="email">The email of the user requesting a password reset.</param>
        /// <returns>The generated password reset token.</returns>
        Task<string> GeneratePasswordResetTokenAsync(string email);

        /// <summary>
        /// Authenticates a user based on email and password.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The authenticated user's view model if successful; otherwise, null.</returns>
        Task<User> AuthenticateUserAsync(string email, string password);

        /// <summary>
        /// Retrieves a paginated list of all users.
        /// </summary>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="searchQuery">The search query to filter users.</param>
        /// <param name="roleFilter">The role to filter users by.</param>
        /// <returns>A paginated list of <see cref="UserDto"/>.</returns>
        Task<PaginatedList<UserDto>> GetPaginatedUsersAsync(int pageNumber, int pageSize, string searchQuery, Enums.UserRole roleFilter);

        /// <summary>
        /// Retrieves a single user by their unique identifier.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>A <see cref="UserDto"/> representing the user.</returns>
        Task<UserDto> GetUserByIdAsync(int id);

        /// <summary>
        /// Retrieves the details of the currently logged-in user.
        /// </summary>
        Task<UserDto> GetCurrentUserDetailsAsync();

        /// <summary>
        /// Updates an existing user's profile information.
        /// </summary>
        /// <param name="model">The view model containing the updated user data.</param>
        Task UpdateUserAsync(UserDto model);

        /// <summary>
        /// Updates the details of the currently logged-in user.
        /// </summary>
        /// <param name="model">The view model containing the updated user data.</param>
        /// <returns>The updated <see cref="User"/> object.</returns>
        Task<User> UpdateCurrentUserProfileAsync(UserDto model);

        /// <summary>
        /// Resets a user's password using a valid reset token.
        /// </summary>
        /// <param name="token">The password reset token.</param>
        /// <param name="newPassword">The new password for the user.</param>
        /// <returns>True if the password was reset successfully; otherwise, false.</returns>
        Task<bool> ResetPasswordAsync(string token, string newPassword);

        /// <summary>
        /// Changes the password for the currently logged-in user.
        /// </summary>
        /// <param name="currentPassword">The user's current password.</param>
        /// <param name="newPassword">The new password to set.</param>
        /// <returns>True if the password was changed successfully; otherwise, false.</returns>
        Task<bool> ChangePasswordAsync(string currentPassword, string newPassword);

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        Task DeleteUserAsync(int id);
    }
}
