using Lurnyx.Data.Models;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Services.Interfaces.Users
{
    /// <summary>
    /// Defines the contract for the service layer that handles business logic for User Training Progress.
    /// </summary>
    public interface IUserTrainingProgressService
    {
        /// <summary>
        /// Increments the view count for a given training.
        /// </summary>
        /// <param name="trainingId">The ID of the training.</param>
        Task IncrementTrainingViewCountAsync(int trainingId);

        /// <summary>
        /// Records the training progress for the current user.
        /// </summary>
        /// <param name="trainingId">The ID of the training.</param>
        /// <param name="statusValue">The status of the training progress.</param>
        Task RecordTrainingProgressAsync(int trainingId, TrainingProgressStatusValue statusValue);

        /// <summary>
        /// Updates the status of a training to 'COMPLETED'.
        /// This method is responsible for the side effect of updating the database.
        /// </summary>
        /// <param name="trainingId">The ID of the training to mark as complete.</param>
        Task MarkTrainingAsCompleteAsync(int trainingId);

        /// <summary>
        /// Retrieves the training progress for a specific training by the current user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="trainingId">The ID of the training.</param>
        /// <returns>The training progress for the specified training and user.</returns>
        Task<UserTrainingProgress> GetTrainingProgressAsync(int userId, int trainingId);

        /// <summary>
        /// Checks if the current user has completed a given training.
        /// </summary>
        /// <param name="trainingId">The ID of the training to check.</param>
        /// <returns>True if the user has completed the training, otherwise false.</returns>
        Task<bool> CheckTrainingCompletionAsync(int trainingId);

        /// <summary>
        /// Retrieves the user's training status information, and updates the training to 'COMPLETED' if all topics are finished.
        /// </summary>
        /// <param name="trainingId">The ID of the training.</param>
        /// <returns>A tuple containing the user's final training progress status and a boolean indicating completion.</returns>
        Task<(TrainingProgressStatusValue? Status, bool IsCompleted)> GetUserTrainingStatusInfoAsync(int trainingId);
    }
}