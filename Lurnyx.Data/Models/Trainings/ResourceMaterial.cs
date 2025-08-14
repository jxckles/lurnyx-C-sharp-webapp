using Lurnyx.Data.Interfaces;

namespace Lurnyx.Data.Models
{
    /// <summary>
    /// Represents a single resource material in a topic.
    /// Implements IEntity to be compatible with the generic repository.
    /// </summary>
    public class ResourceMaterial : SoftDeletableEntity, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Metadata { get; set; }
        public string FileAccessUrl { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public int? FileSize { get; set; }
        public int TopicId { get; set; }
        // Navigation Properties
        public virtual Topic? Topic { get; set; }
    }
}