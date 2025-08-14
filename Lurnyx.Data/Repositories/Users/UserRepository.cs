using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Users;
using Lurnyx.Data.Models;
using Microsoft.EntityFrameworkCore;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Data.Repositories
{
    /// <summary>
    /// Repository for handling data operations for User entities.
    /// Inherits from the generic Repository<T> to get common CRUD functionality.
    /// </summary>
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork) 
        {
        }

        
        public async Task<PaginatedList<User>> GetPaginatedAsync(int pageNumber, int pageSize, string searchQuery, UserRole roleFilter)
        {
            var query = this.GetDbSet<User>()
                            .Where(u => u.DeletedAt == null)
                            .Where(u => u.Role != UserRole.SUPER_ADMIN)
                            .AsNoTracking();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(u =>
                    (u.FirstName != null && u.FirstName.Contains(searchQuery)) ||
                    (u.LastName != null && u.LastName.Contains(searchQuery)) ||
                    u.Email.Contains(searchQuery)
                );
            }

             if (roleFilter != default)
            {
                query = query.Where(u => u.Role == roleFilter);
            }

            query = query.OrderByDescending(u => u.UpdatedAt);

            return await PaginatedList<User>.CreateAsync(query, pageNumber, pageSize);
        }

        
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await this.GetDbSet<User>()
                             .AsNoTracking()
                             .FirstOrDefaultAsync(u => u.Email == email && u.DeletedAt == null);
        }

    }
}
