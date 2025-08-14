namespace Lurnyx.Data.Models
{
    /// <summary>
    /// Inherits from BaseAuditableEntity and adds fields for soft-deleting.
    /// </summary>
    public abstract class SoftDeletableEntity : BaseAuditableEntity
    {
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Navigation Property for soft-delete auditing
        public virtual User? DeletedByUser { get; set; }
    }
}