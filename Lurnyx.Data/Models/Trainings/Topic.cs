using Lurnyx.Data.Interfaces;

namespace Lurnyx.Data.Models
{
    /// <summary>
    /// Represents a single topic or lesson within a training course.
    /// Implements IEntity to be compatible with the generic repository.
    /// </summary>
    public class Topic : SoftDeletableEntity, IEntity
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string? CoverImageUrl { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int DurationInMinutes { get; set; }
        public int TrainingId { get; set; }
        public int ViewCount { get; set; }

        // Navigation Properties
        public virtual Training? Training { get; set; }
        public virtual ICollection<ResourceMaterial>? ResourceMaterials { get; set; }
        public virtual ICollection<UserTopicProgress>? UserProgresses { get; set; }
    }
}