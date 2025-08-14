using Lurnyx.Data.Models;

namespace Lurnyx.Data.Interfaces.Trainings
{
    /// <summary>
    /// Defines the contract for the topic repository.
    /// Inherits common CRUD operations and adds specific methods for Topic.
    /// </summary>
    public interface ITopicRepository : IRepository<Topic>
    {
        /// <summary>
        /// Gets a paginated list of topics with their details.
        /// </summary>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="searchQuery">The search query to filter topics.</param>
        /// <param name="trainingCategoryId">The ID of the training category to filter topics by.</param>
        /// <param name="trainingId">The ID of the training to filter topics by.</param>
        /// <returns>A paginated list of topics.</returns>
        Task<PaginatedList<Topic>> GetPaginatedWithDetailsAsync(int pageNumber, int pageSize, string? searchQuery, int? trainingCategoryId, int? trainingId);

        /// <summary>
        /// Gets a single topic by its ID with its associated details eagerly loaded.
        /// </summary>
        /// <param name="id">The ID of the topic to retrieve.</param>
        /// <returns>The topic with its details, or null if not found.</returns>
        Task<Topic> GetByIdWithDetailsAsync(int id);

        /// <summary>
        /// Increments the view count for a specific topic.
        /// </summary>
        /// <param name="topicId">The ID of the topic to increment the view count for.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        Task IncrementViewCountAsync(int topicId, int currentUserId);
    }
}
