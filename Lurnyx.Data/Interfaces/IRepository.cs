using Lurnyx.Data.Models;
using System.Linq.Expressions;

namespace Lurnyx.Data.Interfaces
{
    /// <summary>
    /// A generic repository interface for common data access operations.
    /// </summary>
    /// <typeparam name="T">The entity type. Must be a class that inherits from SoftDeletableEntity and implements IEntity.</typeparam>
    public interface IRepository<T> where T : SoftDeletableEntity, IEntity
    {
        /// <summary>
        /// Adds a new entity to the database, setting its audit properties.
        /// </summary>
        Task AddAsync(T entity, int currentUserId);

        /// <summary>
        /// Gets all non-deleted entities of type T.
        /// </summary>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Gets a single entity by its ID. Throws KeyNotFoundException if the entity is not found.
        /// </summary>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Checks if any entity exists that matches the specified criteria.
        /// </summary>
        /// <param name="predicate">The expression to test each entity against.</param>
        /// <returns>True if an entity exists, otherwise false.</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Marks an entity for update, setting its audit properties.
        /// </summary>
        void Update(T entity, int currentUserId);

        /// <summary>
        /// Soft deletes an entity by its ID.
        /// </summary>
        Task DeleteAsync(int id, int currentUserId);
    }
}
