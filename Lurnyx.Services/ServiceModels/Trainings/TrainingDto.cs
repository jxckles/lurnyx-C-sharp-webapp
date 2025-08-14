using Lurnyx.Data.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Services.ServiceModels
{
    public class TrainingDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Title cannot be only whitespace.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Description cannot be only whitespace.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 1000 characters.")]
        public string Description { get; set; } = string.Empty;

        [Url(ErrorMessage = "Invalid URL format.")]
        public string CoverImageUrl { get; set; } = null;

        // The file validation is done in the view.
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }

        [Required(ErrorMessage = "Training Difficulty is required.")]
        public TrainingDifficulty Difficulty { get; set; }

        public bool IsFeatured { get; set; }

        public int ViewCount { get; set; } 

        #region Navigation Properties
        public string Author { get; set; }

        [AllowNull]
        public int TrainingCategoryId { get; set; }
        public virtual TrainingCategoryDto TrainingCategory { get; set; }
        public List<TrainingCategoryDto> CategoryList { get; set; }
        public List<TopicDto> Topics { get; set; }
        public TrainingRatingDto UserRating { get; set; }
        public int RatingCount { get; set; }
        public double AverageRating { get; set; }
        public UserTrainingProgress UserTrainingProgress { get; set; }

        #endregion

        #region Auditable Fields
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}
