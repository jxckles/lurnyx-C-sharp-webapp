using Lurnyx.Data.Models;
using Lurnyx.Resources.Constants;

namespace Lurnyx.Data.Interfaces.Users
{
    /// <summary>
    /// Defines the contract for the user repository.
    // It inherits common CRUD operations from IRepository<T> and adds specific methods for User.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Gets a paginated list of users.
        /// </summary>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="searchQuery">The search query to filter users.</param>
        /// <param name="roleFilter">The role filter to filter users by role.</param>
        /// <returns>A paginated list of users.</returns>
        Task<PaginatedList<User>> GetPaginatedAsync(int pageNumber, int pageSize, string searchQuery, Enums.UserRole roleFilter);
        
        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user to retrieve.</param>
        /// <returns>The user entity if found; otherwise, null.</returns>
        Task<User?> GetByEmailAsync(string email);
    }
}
