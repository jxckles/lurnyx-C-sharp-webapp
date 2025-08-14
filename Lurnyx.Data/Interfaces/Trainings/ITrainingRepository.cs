using Lurnyx.Data.Models;

namespace Lurnyx.Data.Interfaces.Trainings
{
    /// <summary>
    /// Defines the contract for the training repository.
    /// Inherits common CRUD operations and adds specific methods for Training.
    /// </summary>
    public interface ITrainingRepository : IRepository<Training>
    {
        /// <summary>
        /// Gets a paginated and filtered list of trainings with their details.
        /// </summary>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="searchQuery">The text to search for in training titles.</param>
        /// <param name="categoryId">The ID of the category to filter by.</param>
        /// <param name="rating">The minimum rating to filter by.</param>
        /// <returns>A paginated list of trainings.</returns>
        Task<PaginatedList<Training>> GetPaginatedAndFilteredWithDetailsAsync(
        int pageNumber, int pageSize, string searchQuery, int? categoryId, int? rating);

        /// <summary>
        /// Gets a single training by its ID with its associated details eagerly loaded.
        /// </summary>
        /// <param name="id">The ID of the training to retrieve.</param>
        /// <returns>The training with its details, or null if not found.</returns>
        Task<Training> GetByIdWithDetailsAsync(int id);

        /// <summary>
        /// Gets a list of suggested trainings for a user, typically based on ratings and what the user hasn't started.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The number of suggestions to return.</param>
        /// <returns>A list of suggested trainings.</returns>
        Task<List<Training>> GetSuggestedTrainingsForUserAsync(int userId, int count);

        /// <summary>
        /// Retrieves a list of trainings for a specific category.
        /// </summary>
        /// <param name="categoryId">The ID of the category to filter trainings by.</param>
        /// <returns>An enumerable collection of trainings for the specified category.</returns>
        Task<IEnumerable<Training>> GetTrainingsByCategoryAsync(int? categoryId);
        
        /// <summary>
        /// Increments the view count for a specific training.
        /// </summary>
        /// <param name="trainingId">The ID of the training to increment the view count for.</param>
        /// <param name="currentUserId">The ID of the user who is incrementing the view count.</param>
        Task IncrementViewCountAsync(int trainingId, int currentUserId);
    }
}
