using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Data.Models
{
    public class UserTrainingProgress : BaseAuditableEntity
    {
        public int Id { get; set; }
        public TrainingProgressStatusValue Status { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime LastAccessedAt { get; set; }
        public int TrainingId { get; set; }
        public int ViewCount { get; set; }

        // Navigation Properties
        public virtual Training? Training { get; set; }
    }
}