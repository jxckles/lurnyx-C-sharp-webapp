using Lurnyx.Data.Models;

namespace Lurnyx.Data.Interfaces.Users
{
    /// <summary>
    /// Defines the contract for a repository that handles data operations for UserTopicProgress entities.
    /// This entity is not soft-deletable.
    /// </summary>
    public interface IUserTopicProgressRepository
    {
        /// <summary>
        /// Adds a new UserTopicProgress record to the database.
        /// </summary>
        /// <param name="progress">The progress entity to add.</param>
        /// <param name="currentUserId">The ID of the user performing the action.</param>
        Task AddAsync(UserTopicProgress progress, int currentUserId);

        /// <summary>
        /// Gets a user's specific topic progress record.
        /// </summary>
        Task<UserTopicProgress?> GetTopicProgressAsync(int userId, int topicId);

        /// <summary>
        /// Gets a list of the most recent topic progress records for a user.
        /// </summary>
        Task<List<UserTopicProgress>> GetRecentTopicProgressAsync(int userId, int count);

        /// <summary>
        /// Gets a list of all dates a user had topic activity.
        /// </summary>
        Task<List<DateTime>> GetTopicActivityDatesAsync(int userId);

        /// <summary>
        /// Updates an existing UserTopicProgress record in the database.
        /// </summary>
        /// <param name="progress">The progress entity to update.</param>
        /// <param name="currentUserId">The ID of the user performing the action.</param>
        void Update(UserTopicProgress progress, int currentUserId);

        /// <summary>
        /// Increments the view count of a user's topic progress record.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="topicId">The ID of the topic.</param>
        Task IncrementViewCountAsync(int userId, int topicId);
    }
}
