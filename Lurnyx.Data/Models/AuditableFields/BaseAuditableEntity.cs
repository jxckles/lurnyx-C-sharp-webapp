namespace Lurnyx.Data.Models
{
    /// <summary>
    /// A base class for entities that require Created and Updated audit fields.
    /// </summary>
    public abstract class BaseAuditableEntity
    {
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation Properties for core auditing
        public virtual User? CreatedByUser { get; set; }
        public virtual User? UpdatedByUser { get; set; }
    }
}