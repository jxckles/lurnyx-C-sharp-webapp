namespace Lurnyx.Services.ServiceModels
{
    /// <summary>
    /// Main DTO for the dashboard, containing all aggregated data.
    /// </summary>
    public class DashboardDto
    {
        public DashboardStatsDto Stats { get; set; }
        public List<RecentActivityDto> RecentActivities { get; set; }
        public LearningProgressDto Progress { get; set; }
        public List<SuggestedTrainingDto> SuggestedTrainings { get; set; }
    }
}