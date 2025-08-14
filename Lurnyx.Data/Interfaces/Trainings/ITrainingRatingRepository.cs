using Lurnyx.Data.Models;

namespace Lurnyx.Data.Interfaces.Trainings
{
    /// <summary>
    /// Defines the contract for the training rating repository.
    /// Inherits common CRUD operations and adds specific methods for TrainingRating.
    /// </summary>
    public interface ITrainingRatingRepository : IRepository<TrainingRating>
    {
        /// <summary>
        /// Gets a paginated and filtered list of training ratings with their details.
        /// </summary>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="searchQuery">The text to search for in training titles.</param>
        /// <param name="ratingFilter">The minimum average rating.</param>
        /// <param name="categoryFilter">The name of the category to filter by.</param>
        /// <param name="currentUserId">The ID of the current user</param>
        /// <returns>A paginated list of training ratings.</returns>
        Task<PaginatedList<TrainingRating>> GetPaginatedAndFilteredWithDetailsAsync(
            int pageNumber, int pageSize, string searchQuery, string ratingFilter, string categoryFilter, int currentUserId);

        /// <summary>
        /// Gets a single training rating by its ID with its associated details eagerly loaded.
        /// </summary>
        /// <param name="id">The ID of the training rating.</param>
        /// <returns>The training rating with its details.</returns>
        Task<TrainingRating> GetByIdWithDetailsAsync(int id);

        /// <summary>
        /// Finds a training rating by its user ID and training ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="trainingId"></param>
        /// <returns>The training rating if found; otherwise, null.</returns>
        Task<TrainingRating?> FindByUserAndTrainingAsync(int userId, int trainingId);

        /// <summary>
        /// Gets all ratings for a specific training.
        /// </summary>
        /// <param name="trainingId">The ID of the training.</param>
        /// <returns>A list of ratings for the specified training.</returns>
        Task<List<TrainingRating>> GetAllByTrainingIdAsync(int trainingId);
        
        /// <summary>
        /// Gets all ratings submitted by a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A list of the user's ratings.</returns>
        Task<List<TrainingRating>> GetRatingsByUserIdAsync(int userId);

        /// <summary>
        /// Calculates the average rating given by a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The user's average rating.</returns>
        Task<double> GetAverageRatingByUserIdAsync(int userId);
    }
}   