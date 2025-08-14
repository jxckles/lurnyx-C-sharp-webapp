using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Trainings;
using Lurnyx.Data.Interfaces.Users;
using Lurnyx.Data.Models;
using Lurnyx.Services.Interfaces.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Services.Services.Users
{
    public class UserTopicProgressService : ProgressServiceBase, IUserTopicProgressService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IUserResourceDownloadRepository _userResourceDownloadRepository;

        public UserTopicProgressService(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            ILoggerFactory loggerFactory,
            ITrainingRepository trainingRepository,
            IUserTrainingProgressRepository userTrainingProgressRepository,
            IUserTopicProgressRepository userTopicProgressRepository,
            ITopicRepository topicRepository,
            IUserResourceDownloadRepository userResourceDownloadRepository
            ) : base(unitOfWork, httpContextAccessor, loggerFactory, trainingRepository, userTrainingProgressRepository, userTopicProgressRepository)
        {
            _topicRepository = topicRepository;
            _userResourceDownloadRepository = userResourceDownloadRepository;
        }

        #region Create / Update

        public async Task IncrementTopicViewCountAsync(int topicId)
        {
            var currentUserId = GetCurrentUserId(); 
            EnsureUserIsAuthenticated(currentUserId);

            await _topicRepository.IncrementViewCountAsync(topicId, currentUserId);

            var topicProgress = await _userTopicProgressRepo.GetTopicProgressAsync(currentUserId, topicId);

            if (topicProgress != null)
            {
                await _userTopicProgressRepo.IncrementViewCountAsync(currentUserId, topicId);
            }
            else
            {
                var newProgress = new UserTopicProgress
                {
                    TopicId = topicId,
                    Status = TopicProgressStatusValue.VIEWED,
                    ViewCount = 1,
                    LastAccessedAt = DateTime.UtcNow
                };
                await _userTopicProgressRepo.AddAsync(newProgress, currentUserId);
            }

            await _unitOfWork.SaveChangesAsync();
        }
        
        public async Task RecordTopicProgressAsync(int topicId, TopicProgressStatusValue statusValue)
        {
            var currentUserId = GetCurrentUserId(); 
            EnsureUserIsAuthenticated(currentUserId);

            var topicProgress = await _userTopicProgressRepo.GetTopicProgressAsync(currentUserId, topicId);
            if (topicProgress != null)
            {
                topicProgress.Status = statusValue;
                topicProgress.LastAccessedAt = DateTime.UtcNow;
                topicProgress.ViewCount++;
                if (statusValue == TopicProgressStatusValue.STARTED)
                {
                    topicProgress.StartedAt = DateTime.UtcNow;
                }
                else if (statusValue == TopicProgressStatusValue.COMPLETED)
                {
                    topicProgress.CompletedAt = DateTime.UtcNow;
                }
                _userTopicProgressRepo.Update(topicProgress, currentUserId);
            }
            else
            {
                var progress = new UserTopicProgress
                {
                    TopicId = topicId,
                    Status = TopicProgressStatusValue.VIEWED,
                    LastAccessedAt = DateTime.UtcNow,
                    ViewCount = 1
                };
                await _userTopicProgressRepo.AddAsync(progress, currentUserId);
            }

            await _unitOfWork.SaveChangesAsync();
        }
        
        public async Task UpdateProgressAfterInteractionAsync(int topicId, int trainingId, bool isTopicExplicitlyCompleted = false)
        {
            var currentUserId = GetCurrentUserId(); 
            EnsureUserIsAuthenticated(currentUserId);

            var trainingProgress = await _userTrainingProgressRepo.GetTrainingProgressAsync(currentUserId, trainingId);
            if (trainingProgress?.Status == TrainingProgressStatusValue.ENROLLED)
            {
                await RecordTrainingProgressAsync(trainingId, TrainingProgressStatusValue.STARTED);
            }

            var topicProgress = await _userTopicProgressRepo.GetTopicProgressAsync(currentUserId, topicId);
            if (topicProgress?.Status == TopicProgressStatusValue.VIEWED)
            {
                await RecordTopicProgressAsync(topicId, TopicProgressStatusValue.STARTED);
                topicProgress = await _userTopicProgressRepo.GetTopicProgressAsync(currentUserId, topicId);
            }

            bool isTopicNowCompleted = isTopicExplicitlyCompleted;

            if (!isTopicNowCompleted)
            {
                var topic = await _topicRepository.GetByIdWithDetailsAsync(topicId);
                var allMaterialIds = topic.ResourceMaterials.Select(r => r.Id).ToHashSet();

                if (allMaterialIds.Any())
                {
                    var interactedResourceIds = (await _userResourceDownloadRepository.GetDownloadsForTopicAsync(currentUserId, topicId))
                                                .Select(d => d.ResourceMaterialId).ToHashSet();
                    
                    if (allMaterialIds.IsSubsetOf(interactedResourceIds))
                    {
                        isTopicNowCompleted = true;
                    }
                }
            }

            if (isTopicNowCompleted && topicProgress?.Status != TopicProgressStatusValue.COMPLETED)
            {
                await RecordTopicProgressAsync(topicId, TopicProgressStatusValue.COMPLETED);

                bool isTrainingNowCompleted = await CheckTrainingCompletionAsync(trainingId);
                if (isTrainingNowCompleted)
                {
                    await MarkTrainingAsCompleteAsync(trainingId);
                }
            }
        }

        #endregion

        #region Read

        public async Task<bool> HasUserStartedTopicAsync(int topicId)
        {
            var currentUserId = GetCurrentUserId(); 
            EnsureUserIsAuthenticated(currentUserId);

            var progress = await _userTopicProgressRepo.GetTopicProgressAsync(currentUserId, topicId);
            return progress != null && progress.Status != TopicProgressStatusValue.VIEWED;
        }

        public async Task ViewTopicsAsync(int trainingId)
        {
            var currentUserId = GetCurrentUserId(); 
            EnsureUserIsAuthenticated(currentUserId);

            var training = await _trainingRepo.GetByIdWithDetailsAsync(trainingId);
            foreach(var topic in training.Topics)
            {
                if(await _userTopicProgressRepo.GetTopicProgressAsync(currentUserId, topic.Id) != null)
                {
                    continue;
                }
                var progress = new UserTopicProgress
                {
                    TopicId = topic.Id,
                    Status = TopicProgressStatusValue.VIEWED,
                    LastAccessedAt = DateTime.UtcNow,
                    ViewCount = 1,
                };
                await _userTopicProgressRepo.AddAsync(progress, currentUserId);
            }
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserTopicProgress> GetTopicProgressAsync(int topicId)
        {
            var currentUserId = GetCurrentUserId(); 
            EnsureUserIsAuthenticated(currentUserId);

            var progress = await _userTopicProgressRepo.GetTopicProgressAsync(currentUserId, topicId);

            return progress;
        }

        #endregion
    }
}
