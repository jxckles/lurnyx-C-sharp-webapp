using Lurnyx.Data.Models;
using Lurnyx.Services.ServiceModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lurnyx.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for the service layer that handles business logic for Trainings.
    /// </summary>
    public interface ITrainingService
    {
        /// <summary>
        /// Creates a new training.
        /// </summary>
        /// <param name="model">The view model containing the new training's data.</param>
        Task AddTrainingAsync(TrainingDto model);

        /// <summary>
        /// Retrieves a paginated list of all trainings with their details for the admin panel.
        /// </summary>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="searchQuery">The search query for filtering trainings.</param>
        /// <param name="categoryId">The ID of the category to filter by.</param>
        /// param name="rating">The rating to filter by.</param>
        /// <returns>A paginated list of training view models.</returns>
        Task<PaginatedList<TrainingDto>> GetPaginatedTrainingsAsync(int pageNumber, int pageSize, string searchQuery, int? categoryId, int? rating);

        /// <summary>
        /// Retrieves a single training by its unique identifier, including its details.
        /// </summary>
        /// <param name="id">The ID of the training to retrieve.</param>
        /// <returns>A <see cref="TrainingDto"/> representing the training.</returns>
        Task<TrainingDto> GetTrainingByIdAsync(int id);

        /// <summary>
        /// Prepares the view model required for the 'Create Training' view, including a list of categories.
        /// </summary>
        /// <returns>A new <see cref="TrainingDto"/> pre-populated with necessary data.</returns>
        Task<TrainingDto> GetCreateViewModelAsync();

        /// <summary>
        /// Retrieves all training categories as a SelectList for use in dropdowns.
        /// </summary>
        /// <param name="selectedId">The ID of the category to be pre-selected.</param>
        /// <returns>A <see cref="SelectList"/> of training categories.</returns>
        Task<SelectList> GetTrainingCategoriesAsSelectListAsync(int? selectedId = null);

        /// <summary>
        /// Retrieves all trainings as a SelectList for use in dropdowns.
        /// </summary>
        /// <param name="selectedId">The ID of the training to be pre-selected.</param>
        /// <param name="categoryId">The ID of the category to filter by.</param>
        /// <returns>A <see cref="SelectList"/> of trainings.</returns>
        Task<SelectList> GetTrainingsAsSelectListAsync(int? selectedId = null, int? categoryId = null);

        /// <summary>
        /// Retrieves a list of trainings filtered by the specified category.
        /// </summary>
        /// <param name="categoryId">The ID of the category to filter by.</param>
        /// <returns>An enumerable list of training view models.</returns>
        Task<IEnumerable<TrainingDto>> GetTrainingsByCategoryAsync(int? categoryId);

        /// <summary>
        /// Updates an existing training.
        /// </summary>
        /// <param name="model">The view model containing the updated training data.</param>
        Task UpdateTrainingAsync(TrainingDto model);

        /// <summary>
        /// Increments the view count of a specific training.
        /// </summary>
        /// <param name="trainingId">The ID of the training to update.</param>
        Task IncrementViewCountAsync(int trainingId);

        /// <summary>
        /// Deletes a training and all of its associated topics and resource materials.
        /// </summary>
        /// <param name="id">The ID of the training to delete.</param>
        Task DeleteTrainingAsync(int id);
    }
}
