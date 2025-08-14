
namespace Lurnyx.Services.ServiceModels
{
    /// <summary>
    /// DTO for the high-level statistics cards.
    /// </summary>
    public class DashboardStatsDto
    {
        public int TotalTrainingsDownloaded { get; set; }
        public string TotalTrainingsDownloadedChange { get; set; }
        public int TrainingsRated { get; set; }
        public string TrainingsRatedChange { get; set; }
        public string MostViewedTraining { get; set; }
        public string MostViewedTrainingViews { get; set; }
    }
}
