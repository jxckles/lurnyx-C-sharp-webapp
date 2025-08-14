using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lurnyx.Services.ServiceModels
{
    public class TopicDto
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Order must be a positive number.")]
        [Required(ErrorMessage = "Order number is required.")]
        public int Order { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters.")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Title cannot be only whitespace.")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters.")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Description cannot be only whitespace.")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Duration must be a positive number.")]
        [Required(ErrorMessage = "Duration is required.")]
        public int DurationInMinutes { get; set; }

        [AllowNull]
        public string CoverImageUrl { get; set; } = string.Empty;

        // The file validation is done in the view.
        [DataType(DataType.Upload)]
        [AllowNull]
        public IFormFile ImageFile { get; set; }

        public int ViewCount { get; set; }

        public bool IsCompletedByUser { get; set; }

        [AllowNull]
        [DisplayName("Training Name")]
        public int TrainingId { get; set; }

        #region Navigation Properties
        public virtual UserDto UpdatedByUser { get; set; }

        public virtual TrainingDto Training { get; set; }

        public List<TrainingDto> TrainingList { get; set; }

        public List<ResourceMaterialDto> ResourceMaterials { get; set; }

        [AllowNull]
        public List<ResourceMaterialDto> NewResources { get; set; }

        #endregion
        
        #region Auditable Fields
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}