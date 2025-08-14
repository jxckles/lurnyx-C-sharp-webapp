using Lurnyx.Data.Models;
using Lurnyx.Services.ServiceModels;

namespace Lurnyx.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for the service layer that handles business logic for Topics.
    /// </summary>
    public interface ITopicService
    {
        /// <summary>
        /// Creates a new topic for a specific training.
        /// </summary>
        /// <param name="model"> The <see cref="TopicDto"/> containing topic details.</param>
        Task AddTopicAsync(TopicDto model);

        /// <summary>
        /// Retrieves a paginated list of all topics.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="searchQuery">The search query for filtering topics.</param>
        /// <param name="trainingCategoryId">The ID of the training category associated with the topics.</param>
        /// <param name="trainingId">The ID of the training associated with the topics.</param>
        /// <returns>A paginated list of <see cref="TopicDto"/>.</returns>
        Task<PaginatedList<TopicDto>> GetPaginatedTopicsAsync(int pageNumber, int pageSize, string searchQuery, int? trainingCategoryId, int? trainingId);

        /// <summary>
        /// Prepares the view model required for the 'Create Topic' view.
        /// </summary>
        /// <param name="trainingId">The ID of the training associated with the topic.</param>
        /// <returns>A new <see cref="TopicDto"/> pre-populated with necessary data.</returns>
        Task<TopicDto> GetCreateViewModelAsync(int trainingId);

        /// <summary>
        /// Retrieves a single topic by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the topic to retrieve.</param>
        /// <returns>A <see cref="TopicDto"/> representing the topic.</returns>
        Task<TopicDto> GetTopicByIdAsync(int id);

        /// <summary>
        /// Checks if a topic with a specific title already exists within a given training.
        /// </summary>
        /// <param name="title">The title of the topic to check.</param>
        /// <param name="trainingId">The ID of the training to check within.</param>
        /// <returns>True if the topic exists; otherwise, false.</returns>
        Task<bool> TopicExistsAsync(string title, int trainingId);

        /// <summary>
        /// Updates a topic's properties and manages its associated resource files (add/delete).
        /// </summary>
        /// <param name="model">The <see cref="TopicDto"/> containing updated topic details.</param>
        Task UpdateTopicAndResourcesAsync(TopicDto model);

        /// <summary>
        /// Increments the view count of a specific topic.
        /// </summary>
        /// <param name="topicId">The ID of the topic to increment the view count for.</param>
        Task IncrementViewCountAsync(int topicId);

        /// <summary>
        /// Deletes a topic and its associated resource materials.
        /// </summary>
        /// <param name="id">The ID of the topic to delete.</param>
        Task DeleteTopicAsync(int id);
    }
}
