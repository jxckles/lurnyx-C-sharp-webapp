using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Data.Models
{
    public class UserTopicProgress: BaseAuditableEntity
    {
        public int Id { get; set; }
        public TopicProgressStatusValue Status { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime LastAccessedAt { get; set; }
        public int TopicId { get; set; }
        public int ViewCount { get; set; }
        
        // Navigation Properties
        public virtual Topic? Topic { get; set; }
    }
}