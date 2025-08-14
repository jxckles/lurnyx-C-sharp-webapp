using Lurnyx.Data.Models;
using Lurnyx.Services.ServiceModels;

namespace Lurnyx.WebApp.Models
{
    /// <summary>
    /// Represents the paginated view model for training ratings.
    /// Contains the list of training ratings and pagination metadata.
    /// </summary>
    public class PaginationTrainingRatingsViewModel
    {
        /// <summary>
        /// The list of training ratings for the current page.
        /// </summary>
        public PaginatedList<TrainingRatingDto> TrainingRatings { get; set; }

        /// <summary>
        /// The list of all available training categories for filtering.
        /// </summary>
        public List<TrainingCategoryDto> AllCategories { get; set; } = new List<TrainingCategoryDto>();

        /// <summary>
        /// The current search query used for filtering training ratings.
        /// </summary>
        public string CurrentSearchQuery { get; set; }

        /// <summary>
        /// The current rating filter applied to the training ratings.
        /// </summary>
        public string CurrentRatingFilter { get; set; }

        /// <summary>
        /// The current category filter applied to the training ratings.
        /// </summary>
        public string CurrentCategoryFilter { get; set; }
    }
}