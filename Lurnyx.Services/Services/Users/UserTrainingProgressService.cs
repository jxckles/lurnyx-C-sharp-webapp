using Lurnyx.Data.Interfaces.Users;
using Lurnyx.Data.Interfaces.Trainings;
using Lurnyx.Services.Interfaces.Users;
using Microsoft.AspNetCore.Http;
using static Lurnyx.Resources.Constants.Enums;
using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Models;
using Microsoft.Extensions.Logging;
namespace Lurnyx.Services.Services.Users
{
    /// <summary>
    /// Implements the service layer for retrieving and composing data for the user dashboard.
    /// </summary>
    public class UserTrainingProgressService : ProgressServiceBase, IUserTrainingProgressService
    {
        public UserTrainingProgressService(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            ILoggerFactory loggerFactory,
            IUserTrainingProgressRepository userTrainingProgressRepo,
            ITrainingRepository trainingRepo,
            IUserTopicProgressRepository userTopicProgressRepository)
            : base(unitOfWork, httpContextAccessor, loggerFactory, trainingRepo, userTrainingProgressRepo, userTopicProgressRepository)
        {
        }

        #region Create / Update
        
        public async Task IncrementTrainingViewCountAsync(int trainingId)
        {
            var currentUserId = GetCurrentUserId(); 
            EnsureUserIsAuthenticated(currentUserId);

            await _trainingRepo.IncrementViewCountAsync(trainingId, currentUserId);

            var progress = await _userTrainingProgressRepo.GetTrainingProgressAsync(currentUserId, trainingId);

            if (progress != null)
            {
                await _userTrainingProgressRepo.IncrementViewCountAsync(currentUserId, trainingId);
            }
            else
            {
                var newProgress = new UserTrainingProgress
                {
                    TrainingId = trainingId,
                    Status = TrainingProgressStatusValue.VIEWED,
                    ViewCount = 1,
                    LastAccessedAt = DateTime.UtcNow
                };
                await _userTrainingProgressRepo.AddAsync(newProgress, currentUserId);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        Task IUserTrainingProgressService.MarkTrainingAsCompleteAsync(int trainingId)
        {
            return MarkTrainingAsCompleteAsync(trainingId);
        }

        Task IUserTrainingProgressService.RecordTrainingProgressAsync(int trainingId, TrainingProgressStatusValue statusValue)
        {
            return RecordTrainingProgressAsync(trainingId, statusValue);
        }

        #endregion

        #region Read

        public async Task<UserTrainingProgress> GetTrainingProgressAsync(int userId, int trainingId)
        {
            EnsureUserIsAuthenticated(userId);
            return await _userTrainingProgressRepo.GetTrainingProgressAsync(userId, trainingId);
        }

        public async Task<(TrainingProgressStatusValue? Status, bool IsCompleted)> GetUserTrainingStatusInfoAsync(int trainingId)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var progress = await _userTrainingProgressRepo.GetTrainingProgressAsync(currentUserId, trainingId);

            if (progress == null)
            {
                return (null, false);
            }

            bool isCompleted = false;

            if (progress.Status == TrainingProgressStatusValue.COMPLETED)
            {
                isCompleted = true;
            }
            else if (progress.Status == TrainingProgressStatusValue.ENROLLED)
            {
                isCompleted = await CheckTrainingCompletionAsync(trainingId);
                if (isCompleted)
                {
                    await MarkTrainingAsCompleteAsync(trainingId);
                    progress.Status = TrainingProgressStatusValue.COMPLETED;
                }
            }

            return (progress.Status, isCompleted);
        }

        Task<bool> IUserTrainingProgressService.CheckTrainingCompletionAsync(int trainingId)
        {
            return CheckTrainingCompletionAsync(trainingId);
        }

        #endregion
    }
}