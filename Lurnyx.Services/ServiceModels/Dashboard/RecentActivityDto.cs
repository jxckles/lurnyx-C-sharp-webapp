
namespace Lurnyx.Services.ServiceModels
{
    /// <summary>
    /// DTO for a single item in the recent activity feed.
    /// </summary>
    public class RecentActivityDto
    {
        public string Action { get; set; }
        public string Training { get; set; }
        public string TimeAgo { get; set; }
        public string Icon { get; set; }
        public DateTime Timestamp { get; set; }
        public string Badge { get; set; }
    }
}
