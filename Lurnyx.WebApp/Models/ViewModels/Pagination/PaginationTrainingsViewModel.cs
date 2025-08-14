using Lurnyx.Data.Models;
using Lurnyx.Services.ServiceModels;

namespace Lurnyx.WebApp.Models
{
    /// <summary>
    /// Represents the complete view model for the 'Browse Trainings' page.
    /// It contains the paginated list of trainings and all necessary filter data.
    /// </summary>
    public class PaginationTrainingsViewModel
    {
        /// <summary>
        /// The paginated list of trainings. This object contains the items for the
        /// current page and all pagination metadata (TotalPages, HasNextPage, etc.).
        /// </summary>
        public PaginatedList<TrainingDto> Trainings { get; set; }

        /// <summary>
        /// The list of all available categories to populate the filter dropdown.
        /// </summary>
        public List<TrainingCategoryDto> AllCategories { get; set; } = new List<TrainingCategoryDto>();

        /// <summary>
        /// The current search query, used to repopulate the search box.
        /// </summary>
        public string CurrentSearchQuery { get; set; }

        /// <summary>
        /// The current rating filter, used to repopulate the rating filter dropdown.
        /// </summary>
        public string CurrentRatingFilter { get; set; }

        /// <summary>
        /// The current category filter, used to repopulate the category filter dropdown.
        /// </summary>
        public string CurrentCategoryFilter { get; set; }
    }
}
