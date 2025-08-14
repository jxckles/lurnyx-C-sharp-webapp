using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lurnyx.Data.Repositories
{
    /// <summary>
    /// A generic repository providing common data access operations for entities.
    /// It handles the setting of auditable properties automatically.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public class Repository<T> : BaseRepository, IRepository<T> where T : SoftDeletableEntity, IEntity
    {
        public Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task AddAsync(T entity, int currentUserId)
        {
            var now = DateTime.UtcNow;
            entity.CreatedBy = currentUserId;
            entity.UpdatedBy = currentUserId;
            entity.CreatedAt = now;
            entity.UpdatedAt = now;

            await this.GetDbSet<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.GetDbSet<T>().Where(e => e.DeletedAt == null).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await this.GetDbSet<T>().FirstOrDefaultAsync(e => e.Id == id && e.DeletedAt == null);
            return entity ?? throw new KeyNotFoundException($"{typeof(T).Name} with ID {id} not found.");
        }
        
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await this.GetDbSet<T>().Where(e => e.DeletedAt == null).AnyAsync(predicate);
        }
        
        public void Update(T entity, int currentUserId)
        {
            entity.UpdatedBy = currentUserId;
            entity.UpdatedAt = DateTime.UtcNow;

            this.GetDbSet<T>().Update(entity);
        }
        
        public async Task DeleteAsync(int id, int currentUserId)
        {
            var entity = await GetByIdAsync(id);

            var now = DateTime.UtcNow;
            entity.DeletedBy = currentUserId;
            entity.DeletedAt = now;
            entity.UpdatedBy = currentUserId;
            entity.UpdatedAt = now;

            this.GetDbSet<T>().Update(entity);
        }
    }
}
