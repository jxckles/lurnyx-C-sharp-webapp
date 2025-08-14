namespace Lurnyx.Data.Models
{

    public class UserResourceDownload : BaseAuditableEntity
    {
        public int Id { get; set; }
        public int DownloadCount { get; set; }
        public DateTime FirstDownloadedAt { get; set; }
        public DateTime LastDownloadedAt { get; set; }
        public int ResourceMaterialId { get; set; }

        // Navigation Properties
        public virtual ResourceMaterial? ResourceMaterial { get; set; }
    }
}