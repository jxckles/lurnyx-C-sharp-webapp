using Lurnyx.Data.Models;
using Lurnyx.Services.ServiceModels;

namespace Lurnyx.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for the Training Category service layer.
    /// All methods are asynchronous and follow the async/await pattern.
    /// </summary>
    public interface ITrainingCategoryService
    {
        /// <summary>
        /// Creates a new training category.
        /// </summary>
        /// <param name="model">The view model containing the new category's data.</param>
        Task AddTrainingCategoryAsync(TrainingCategoryDto model);

        /// <summary>
        /// Retrieves a paginated list of all training categories with their details.
        /// </summary>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="searchQuery">The search query to filter categories.</param>
        /// <returns>A paginated list of training category view models.</returns>
        Task<PaginatedList<TrainingCategoryDto>> GetPaginatedTrainingCategoriesAsync(int pageNumber, int pageSize, string searchQuery);

        /// <summary>
        /// Retrieves a single training category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category to retrieve.</param>
        /// <returns>The training category view model.</returns>
        Task<TrainingCategoryDto> GetTrainingCategoryByIdAsync(int id);

        /// <summary>
        /// Updates an existing training category.
        /// </summary>
        /// <param name="model">The view model containing the updated category data.</param>
        Task UpdateTrainingCategoryAsync(TrainingCategoryDto model);

        /// <summary>
        /// Deletes a training category. This unlinks associated trainings before performing a soft delete.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        Task DeleteTrainingCategoryAsync(int id);
    }
}
