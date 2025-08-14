using Lurnyx.Data.Models;

namespace Lurnyx.Data.Interfaces.Trainings
{
    /// <summary>
    /// Defines the contract for the training category repository.
    /// It inherits common CRUD operations from IRepository<T> and adds specific methods for TrainingCategory.
    /// </summary>
    public interface ITrainingCategoryRepository : IRepository<TrainingCategory>
    {
        /// <summary>
        /// Gets a paginated list of training categories with their details.
        /// </summary>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="searchQuery">The search query to filter categories.</param>
        /// <returns>A paginated list of training categories.</returns>
        Task<PaginatedList<TrainingCategory>> GetPaginatedWithDetailsAsync(int pageNumber, int pageSize, string searchQuery);

        /// <summary>
        /// Gets a single training category by its ID with its associated trainings and topics eagerly loaded.
        /// </summary>
        /// <param name="id">The ID of the category.</param>
        /// <returns>The training category entity with its details.</returns>
        Task<TrainingCategory> GetByIdWithDetailsAsync(int id);
    }
}
