using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;

namespace Lurnyx.Services.ServiceModels
{
    /// <summary>
    /// Represents a downloadable resource material associated with a topic.
    /// </summary>
    public class ResourceMaterialDto
    {
        public int Id { get; set; }

        [AllowNull]
        public string Name { get; set; }

        [StringLength(15)]
        [AllowNull]
        // e.g., "1 page", "2 slides", "01:10:32"
        public string Metadata { get; set; }

        [AllowNull]
        public string FileAccessUrl { get; set; }

        [AllowNull]
        // e.g., PDF, PNG, PPTX
        public string FileType { get; set; }

        [AllowNull]
        public long FileSize { get; set; }

        // The file validation is done in the view.
        [DataType(DataType.Upload)]
        [AllowNull]
        public IFormFile File { get; set; }

        public bool IsMarkedForDeletion { get; set; }

        #region Navigation Properties
        public int TopicId { get; set; }
        
        public bool IsDownloaded { get; set; }

        #endregion

        #region Auditable Fields
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}
