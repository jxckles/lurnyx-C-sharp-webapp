using Lurnyx.Data.Models;
using Lurnyx.Services.ServiceModels;

namespace Lurnyx.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for the service layer that handles business logic for Training Ratings.
    /// </summary>
    public interface ITrainingRatingService
    {

        /// <summary>
        /// Creates a new training rating.or update an existing rating
        /// </summary>
        Task SubmitRatingAsync(int trainingId, int rating, string comment);
       
        /// <summary>
        /// Retrieves a paginated list of all training ratings with ther details.
        /// </summary>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="searchQuery">The text to search for in training titles.</param>
        /// <param name="ratingFilter">The minimum average rating.</param>
        /// <param name="categoryFilter">The name of the category to filter by.</param>
        /// <returns>A paginated list of training rating view models.</returns>
        Task<PaginatedList<TrainingRatingDto>> GetPaginatedAndFilteredWithDetailsAsync(
            int pageNumber, int pageSize, string searchQuery, string ratingFilter, string categoryFilter);

        /// <summary>
        /// Retrieves a single training rating by its unique identifier, including its details.
        /// </summary>
        /// <param name="id">The ID of the training rating to retrieve.</param>
        /// <returns>A <see cref="TrainingRatingDto"/> representing the training rating.</returns>
        Task<TrainingRatingDto> GetTrainingRatingByIdAsync(int id);

        /// <summary>
        /// Retrieves a summary of ratings for a specific training, including the average, count, and the current user's rating.
        /// </summary>
        /// <param name="trainingId">The ID of the training.</param>
        /// <returns>A view model containing the rating summary.</returns>
        Task<TrainingRatingSummaryDto> GetRatingSummaryForTrainingAsync(int trainingId);

        /// <summary>
        /// Updates an existing training rating.
        /// </summary>
        /// <param name="model">The view model containing the updated training rating data.</param>
        Task UpdateTrainingRatingAsync(TrainingRatingDto model);
        
        /// <summary>
        /// Deletes a training rating.
        /// </summary>
        /// <param name="id">The ID of the training rating to delete.</param>
        Task DeleteTrainingRatingAsync(int id);
    }
}