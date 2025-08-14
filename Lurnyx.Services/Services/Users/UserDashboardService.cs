using AutoMapper;
using Lurnyx.Data.Interfaces.Users;
using Lurnyx.Data.Interfaces.Trainings;
using Lurnyx.Services.Interfaces.Users;
using Lurnyx.Services.ServiceModels;
using Microsoft.AspNetCore.Http;
using static Lurnyx.Resources.Constants.Enums;
using Microsoft.Extensions.Logging;

namespace Lurnyx.Services.Services
{
    /// <summary>
    /// Implements the service layer for retrieving and composing data for the user dashboard.
    /// </summary>
    public class UserDashboardService : ServiceBase, IUserDashboardService
    {
        private readonly IMapper _mapper;
        private readonly IUserTrainingProgressRepository _userTrainingProgressRepo;
        private readonly IUserTopicProgressRepository _userTopicProgressRepo;
        private readonly IUserResourceDownloadRepository _userResourceDownloadRepo;
        private readonly ITrainingRepository _trainingRepo;
        private readonly ITrainingRatingRepository _ratingRepo;

        public UserDashboardService(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IUserTrainingProgressRepository userTrainingProgressRepo,
            IUserTopicProgressRepository userTopicProgressRepo,
            IUserResourceDownloadRepository userResourceDownloadRepo,
            ITrainingRepository trainingRepo,
            ITrainingRatingRepository ratingRepo,
            ILoggerFactory loggerFactory) : base(httpContextAccessor, loggerFactory)
        {
            _mapper = mapper;
            _userTrainingProgressRepo = userTrainingProgressRepo;
            _userTopicProgressRepo = userTopicProgressRepo;
            _userResourceDownloadRepo = userResourceDownloadRepo;
            _trainingRepo = trainingRepo;
            _ratingRepo = ratingRepo;
        }

        #region Read
        public async Task<DashboardDto> GetDashboardDataAsync()
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var stats = await GetStatsAsync(currentUserId);
            var progress = await GetLearningProgressAsync(currentUserId);
            var recentActivities = await GetRecentActivitiesAsync(currentUserId);
            var suggestedTrainings = await GetSuggestedTrainingsAsync(currentUserId);

            return new DashboardDto
            {
                Stats = stats,
                Progress = progress,
                RecentActivities = recentActivities,
                SuggestedTrainings = suggestedTrainings
            };
        }

        #endregion

        #region Private Helpers
        private async Task<DashboardStatsDto> GetStatsAsync(int userId)
        {
            var mostViewed = await _userTrainingProgressRepo.GetMostViewedTrainingProgressAsync(userId);
            var downloads = await _userResourceDownloadRepo.GetAllResourceDownloadsAsync(userId);
            var ratings = await _ratingRepo.GetRatingsByUserIdAsync(userId);

            return new DashboardStatsDto
            {
                TotalTrainingsDownloaded = downloads.Sum(d => d.DownloadCount),
                TrainingsRated = ratings.Count,
                MostViewedTraining = mostViewed?.Training?.Title ?? "N/A",
                MostViewedTrainingViews = $"{mostViewed?.ViewCount ?? 0} views",
                TotalTrainingsDownloadedChange = "", // TODO: Make this dynamic
                TrainingsRatedChange = "" // TODO: Make this dynamic
            };
        }

        private async Task<LearningProgressDto> GetLearningProgressAsync(int userId)
        {
            var allProgress = await _userTrainingProgressRepo.GetAllTrainingProgressAsync(userId);
            var streak = await CalculateStudyStreakAsync(userId);
            var avgRating = await _ratingRepo.GetAverageRatingByUserIdAsync(userId);

            int completionRate = 0;
            if (allProgress.Any())
            {
                var completedCount = allProgress.Count(p => p.Status == TrainingProgressStatusValue.COMPLETED);
                completionRate = (int)Math.Round((double)completedCount / allProgress.Count * 100);
            }

            return new LearningProgressDto
            {
                CompletionRate = completionRate,
                TotalCompletedTrainings = allProgress.Count(p => p.Status == TrainingProgressStatusValue.COMPLETED),
                TotalTrainings = allProgress.Count,    
                StudyStreak = streak,
                AverageRating = avgRating
            };
        }

        /// <summary>
        /// Retrieves a list of the user's recent activities including training progress, topic progress, and resource downloads.
        /// Combines these activities into a single list ordered by the most recent timestamp.
        /// </summary>
        /// <param name="userId">The user id for whom to retrieve recent activities.</param>
        /// <returns>A list of recent activities represented by <see cref="RecentActivityDto"/>.</returns>
        private async Task<List<RecentActivityDto>> GetRecentActivitiesAsync(int userId)
        {
            var recentTrainingProgress = await _userTrainingProgressRepo.GetRecentTrainingProgressAsync(userId, 5);
            var recentTopicProgress = await _userTopicProgressRepo.GetRecentTopicProgressAsync(userId, 5);
            var recentDownloads = await _userResourceDownloadRepo.GetRecentResourceDownloadsAsync(userId, 5);
            
            var activities = new List<RecentActivityDto>();
            activities.AddRange(recentTrainingProgress.Select(p => new RecentActivityDto { Action = $"{p.Status}", Training = p.Training?.Title ?? "a training", TimeAgo = GetTimeAgo(p.LastAccessedAt), Icon = "play.svg", Timestamp = p.LastAccessedAt, Badge = "Training" }));
            activities.AddRange(recentTopicProgress.Select(p => new RecentActivityDto { Action = $"{p.Status}", Training = p.Topic?.Title ?? "a topic", TimeAgo = GetTimeAgo(p.LastAccessedAt), Icon = "completecookie.svg", Timestamp = p.LastAccessedAt, Badge = "Topic" }));
            activities.AddRange(recentDownloads.Select(d => new RecentActivityDto { Action = "ACCESSED", Training = d.ResourceMaterial?.Name ?? "a resource", TimeAgo = GetTimeAgo(d.LastDownloadedAt), Icon = "downloadwhite.svg", Timestamp = d.LastDownloadedAt, Badge = "Resource" }));

            return activities.OrderByDescending(a => a.Timestamp).Take(5).ToList();
        }

        /// <summary>
        /// Retrieves the suggested trainings for the user based on their past engagement. The suggested trainings
        /// are the ones that the user has not engaged with yet, sorted by their average rating.
        /// </summary>
        /// <param name="userId">The user id to retrieve suggested trainings for.</param>
        /// <returns>A list of suggested trainings.</returns>
        private async Task<List<SuggestedTrainingDto>> GetSuggestedTrainingsAsync(int userId)
        {
            var trainings = await _trainingRepo.GetSuggestedTrainingsForUserAsync(userId, 4);
            return _mapper.Map<List<SuggestedTrainingDto>>(trainings);
        }

        /// <summary>
        /// Calculates the number of consecutive days the user has been active in doing something on the platform.
        /// </summary>
        /// <param name="userId">The user id to calculate the streak for.</param>
        /// <returns>The number of consecutive days the user has been active.</returns>
        private async Task<int> CalculateStudyStreakAsync(int userId)
        {
            var trainingDates = await _userTrainingProgressRepo.GetTrainingActivityDatesAsync(userId);
            var topicDates = await _userTopicProgressRepo.GetTopicActivityDatesAsync(userId);
            var downloadDates = await _userResourceDownloadRepo.GetDownloadActivityDatesAsync(userId);

            var activityDates = trainingDates
                .Concat(topicDates)
                .Concat(downloadDates)
                .Select(d => d.Date)
                .Distinct()
                .OrderByDescending(d => d)
                .ToList();

            if (!activityDates.Any()) return 0;

            var today = DateTime.UtcNow.Date;
            var streak = 0;

            if (activityDates.FirstOrDefault() == today || activityDates.FirstOrDefault() == today.AddDays(-1))
            {
                streak = 1;
                for (int i = 0; i < activityDates.Count - 1; i++)
                {
                    if ((activityDates[i] - activityDates[i + 1]).TotalDays == 1)
                    {
                        streak++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return streak;
        }

        /// <summary>
        /// Returns a human-readable string representing how much time has passed since the given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime to calculate the time ago from.</param>
        /// <returns>A string indicating the time elapsed, such as "Just now", "Xm ago", "Xh ago", or "Xd ago".</returns>
        private string GetTimeAgo(DateTime dateTime)
        {
            var timeSpan = DateTime.UtcNow - dateTime;
            if (timeSpan.TotalMinutes < 1) return "Just now";
            if (timeSpan.TotalMinutes < 60) return $"{Math.Floor(timeSpan.TotalMinutes)}m ago";
            if (timeSpan.TotalHours < 24) return $"{Math.Floor(timeSpan.TotalHours)}h ago";
            return $"{Math.Floor(timeSpan.TotalDays)}d ago";
        }

        #endregion
    }
}
