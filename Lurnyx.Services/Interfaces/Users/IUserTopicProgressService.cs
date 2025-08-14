using Lurnyx.Data.Models;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Services.Interfaces.Users
{
    /// <summary>
    /// Defines the contract for the service layer that handles business logic for User Topic Progress.
    /// </summary>
    public interface IUserTopicProgressService
    {
        /// <summary>
        /// Increments the view count for a topic globally and for the current user's progress.
        /// Creates a progress record if it's the user's first view.
        /// </summary>
        /// <param name="topicId">The ID of the topic being viewed.</param>
        Task IncrementTopicViewCountAsync(int topicId);

        /// <summary>
        /// Records the topic progress for the current user.
        /// </summary>
        /// <param name="topicId">The ID of the topic.</param>
        /// <param name="statusValue">The status of the topic progress.</param>
        Task RecordTopicProgressAsync(int topicId, TopicProgressStatusValue statusValue);

        /// <summary>
        /// Updates the progress of a training after a user interaction.
        /// The method checks if the user has completed all topics in the training.
        /// If so, the training status is updated to 'COMPLETED'.
        /// </summary>
        /// <param name="topicId">The ID of the topic the user has interacted with.</param>
        /// <param name="trainingId">The ID of the training.</param>
        /// <param name="isTopicExplicitlyCompleted">Indicates whether the topic was explicitly marked as complete.</param>
        Task UpdateProgressAfterInteractionAsync(int topicId, int trainingId, bool isTopicExplicitlyCompleted = false);

        /// <summary>
        /// Retrieves the topic progress for a specific training by the current user.
        /// </summary>
        /// <param name="topicId">The ID of the topic to retrieve progress for.</param>
        /// <returns>The topic progress for the specified topic.</returns>
        Task<UserTopicProgress> GetTopicProgressAsync(int topicId);

        /// <summary>
        /// Checks if the current user has started a specific topic.
        /// </summary>
        /// <param name="topicId">The ID of the topic to check.</param>
        /// <returns>True if the user has started the training, otherwise false.</returns>
        Task<bool> HasUserStartedTopicAsync(int topicId);

        /// <summary>
        /// Records the topic progress for the current user when viewing a topic.
        /// </summary>
        /// <param name="trainingId">The ID of the training that the topics belong to.</param>
        Task ViewTopicsAsync(int trainingId);
    }
}
