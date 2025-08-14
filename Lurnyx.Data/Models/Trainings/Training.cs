using Lurnyx.Data.Interfaces;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Data.Models
{
    /// <summary>
    /// Represents a training course in the system.
    /// Implements IEntity to be compatible with the generic repository.
    /// </summary>
    public class Training : SoftDeletableEntity, IEntity
    {
        public int Id { get; set; }
        public string? CoverImageUrl { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TrainingDifficulty Difficulty { get; set; }
        public int? TrainingCategoryId { get; set; }
        public int ViewCount { get; set; }
        public bool IsFeatured { get; set; }

        // Navigation Properties
        public virtual TrainingCategory? TrainingCategory { get; set; }
        public virtual ICollection<Topic>? Topics { get; set; }
        public virtual ICollection<TrainingRating>? Ratings { get; set; }
        public virtual ICollection<UserTrainingProgress>? UserProgresses { get; set; }
    }
}