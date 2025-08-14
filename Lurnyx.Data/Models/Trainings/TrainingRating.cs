using Lurnyx.Data.Interfaces;

namespace Lurnyx.Data.Models
{
    public class TrainingRating : SoftDeletableEntity, IEntity
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public int TrainingId { get; set; }

        // Navigation Properties
        public virtual Training? Training { get; set; }
    }
}