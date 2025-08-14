using Lurnyx.Data.Models;

namespace Lurnyx.Data.Interfaces.Users
{
    /// <summary>
    /// Defines the contract for a repository that handles data operations for UserTrainingProgress entities.
    /// This entity is not soft-deletable.
    /// </summary>
    public interface IUserTrainingProgressRepository
    {
        /// <summary>
        /// Adds a new UserTrainingProgress record to the database.
        /// </summary>
        /// <param name="progress">The progress entity to add.</param>
        /// <param name="currentUserId">The ID of the user performing the action.</param>
        Task AddAsync(UserTrainingProgress progress, int currentUserId);

        /// <summary>
        /// Updates an existing UserTrainingProgress record in the database.
        /// </summary>
        /// <param name="progress">The progress entity to update.</param>
        /// <param name="currentUserId">The ID of the user performing the action.</param>
        void Update(UserTrainingProgress progress, int currentUserId);

        /// <summary>
        /// Gets a user's specific training progress record.
        /// </summary>
        Task<UserTrainingProgress?> GetTrainingProgressAsync(int userId, int trainingId);

        /// <summary>
        /// Gets all training progress records for a specific user.
        /// </summary>
        Task<List<UserTrainingProgress>> GetAllTrainingProgressAsync(int userId);

        /// <summary>
        /// Gets the most viewed training progress record for a user.
        /// </summary>
        Task<UserTrainingProgress?> GetMostViewedTrainingProgressAsync(int userId);

        /// <summary>
        /// Gets a list of the most recent training progress records for a user.
        /// </summary>
        Task<List<UserTrainingProgress>> GetRecentTrainingProgressAsync(int userId, int count);

        /// <summary>
        /// Gets a list of all dates a user had training activity.
        /// </summary>
        Task<List<DateTime>> GetTrainingActivityDatesAsync(int userId);

        /// <summary>
        /// Increments the view count for a specific training progress record.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="trainingId">The ID of the training.</param>
        Task IncrementViewCountAsync(int userId, int trainingId);
    }
}
