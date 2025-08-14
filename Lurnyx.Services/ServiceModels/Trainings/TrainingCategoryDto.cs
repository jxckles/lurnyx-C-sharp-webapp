using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Lurnyx.Services.ServiceModels
{
    public class TrainingCategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Name cannot be only whitespace.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Description cannot be only whitespace.")]
        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
        public string Description { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string CoverImageUrl { get; set; }

        // The size validation is manually handled in the client-side, through script
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }

        #region Navigation Properties
        public double AverageRating { get; set; }
        public int RatingCount { get; set; }
        public List<TrainingDto> Trainings { get; set; } = new List<TrainingDto>();
        public int TrainingCount { get; set; }
        public int TopicCount { get; set; }

        #endregion

        #region Auditable Fields
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}
