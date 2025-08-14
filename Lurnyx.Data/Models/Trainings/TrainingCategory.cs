using Lurnyx.Data.Interfaces;

namespace Lurnyx.Data.Models
{
    /// <summary>
    /// Represents a category for trainings.
    /// Implements IEntity to be compatible with the generic repository.
    /// </summary>
    public class TrainingCategory : SoftDeletableEntity, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? CoverImageUrl { get; set; }

        /// <summary>
        /// Navigation property for the one-to-many relationship.
        /// A TrainingCategory can have multiple Trainings.
        /// </summary>
        public virtual ICollection<Training>? Trainings { get; set; }
    }
}