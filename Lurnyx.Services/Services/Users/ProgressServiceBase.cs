using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Trainings;
using Lurnyx.Data.Interfaces.Users;
using Lurnyx.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Services.Services.Users
{
    /// <summary>
    /// A base class for progress-related services to share common logic and dependencies.
    /// Inherits from ServiceBase to gain access to authentication helpers and logging.
    /// </summary>
    public abstract class ProgressServiceBase : ServiceBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ITrainingRepository _trainingRepo;
        protected readonly IUserTrainingProgressRepository _userTrainingProgressRepo;
        protected readonly IUserTopicProgressRepository _userTopicProgressRepo;

        protected ProgressServiceBase(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            ILoggerFactory loggerFactory,
            ITrainingRepository trainingRepo,
            IUserTrainingProgressRepository userTrainingProgressRepo,
            IUserTopicProgressRepository userTopicProgressRepo) : base(httpContextAccessor, loggerFactory)
        {
            _unitOfWork = unitOfWork;
            _trainingRepo = trainingRepo;
            _userTrainingProgressRepo = userTrainingProgressRepo;
            _userTopicProgressRepo = userTopicProgressRepo;
        }

        #region Common Progress Helpers

        // The GetCurrentUserId() and EnsureUserIsAuthenticated() methods are now inherited from ServiceBase.

        /// <summary>
        /// Checks if all topics within a training are completed by the user.
        /// </summary>
        protected async Task<bool> CheckTrainingCompletionAsync(int trainingId)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var training = await _trainingRepo.GetByIdWithDetailsAsync(trainingId);
            var topics = training?.Topics;

            if (topics == null || !topics.Any())
                return true;

            foreach (var topic in topics)
            {
                var topicProgress = await _userTopicProgressRepo.GetTopicProgressAsync(currentUserId, topic.Id);
                if (topicProgress == null || topicProgress.Status != TopicProgressStatusValue.COMPLETED)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Marks a training as completed for the current user.
        /// </summary>
        protected async Task MarkTrainingAsCompleteAsync(int trainingId)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var progress = await _userTrainingProgressRepo.GetTrainingProgressAsync(currentUserId, trainingId);
            if (progress != null && progress.Status != TrainingProgressStatusValue.COMPLETED)
            {
                progress.Status = TrainingProgressStatusValue.COMPLETED;
                progress.CompletedAt = DateTime.UtcNow;
                _userTrainingProgressRepo.Update(progress, currentUserId);
                await _unitOfWork.SaveChangesAsync();
            }
        }
        
        /// <summary>
        /// Records or updates the training progress status for the current user. 
        /// If no existing progress is found, a new record is created. 
        /// If the progress status changes to STARTED, the start time is recorded. 
        /// Changes are persisted to the database.
        /// </summary>
        /// <param name="trainingId">The ID of the training for which progress is being recorded.</param>
        /// <param name="statusValue">The new status value to be recorded for the training progress.</param>
        protected async Task RecordTrainingProgressAsync(int trainingId, TrainingProgressStatusValue statusValue)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var progress = await _userTrainingProgressRepo.GetTrainingProgressAsync(currentUserId, trainingId);
            if (progress == null)
            {
                progress = new UserTrainingProgress
                {
                    TrainingId = trainingId,
                    Status = statusValue,
                    StartedAt = DateTime.UtcNow
                };
                await _userTrainingProgressRepo.AddAsync(progress, currentUserId);
            }
            else if (progress.Status != statusValue)
            {
                progress.Status = statusValue;
                if (statusValue == TrainingProgressStatusValue.STARTED && progress.StartedAt == null)
                {
                    progress.StartedAt = DateTime.UtcNow;
                }
                _userTrainingProgressRepo.Update(progress, currentUserId);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        #endregion
    }
}
