using AutoMapper;
using Lurnyx.Resources.Constants;
using Lurnyx.Services.Interfaces;
using Lurnyx.Services.ServiceModels;
using Lurnyx.WebApp.Models;
using Lurnyx.WebApp.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lurnyx.WebApp.Controllers.Users
{
    [Authorize(Roles = "SUPER_ADMIN,USER")]
    [Route("User/[controller]/[action]")]
    public class TrainingRatingsController : ControllerBase<TrainingRatingsController>
    {
        private readonly ITrainingService _trainingService;
        private readonly ITrainingRatingService _trainingRatingService;

        public TrainingRatingsController(
                            ITrainingService trainingService,
                            ITrainingRatingService trainingRatingService,
                            IHttpContextAccessor httpContextAccessor,
                            ILoggerFactory loggerFactory,
                            IConfiguration configuration,
                            IMapper mapper = null)
            : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _trainingService = trainingService ?? throw new ArgumentNullException(nameof(trainingService));
            _trainingRatingService = trainingRatingService ?? throw new ArgumentNullException(nameof(trainingRatingService));
        }

        /// <summary>
        /// GET /User/TrainingRatings
        /// Displays a paginated list of ratings, filtered by search query, category, and rating.
        /// </summary>
        /// <param name="searchQuery">The search query to filter ratings by.</param>
        /// <param name="ratingFilter">The rating filter to apply to ratings.</param>
        /// <param name="categoryFilter">The category filter to apply to ratings.</param>
        /// <param name="page">The page number to display.</param>
        /// <returns>The view to list all ratings, filtered by the provided criteria.</returns>
        [HttpGet]
        public async Task<IActionResult> Index(string searchQuery = "", string ratingFilter = "", string categoryFilter = "", int page = 1)
        {
            try
            {
                var paginatedRatings = await _trainingRatingService.GetPaginatedAndFilteredWithDetailsAsync(page, Const.HorizontalCardPageSize, searchQuery, ratingFilter, categoryFilter);

                var createViewModel = await _trainingService.GetCreateViewModelAsync();
                var allCategories = createViewModel.CategoryList;

                var model = new PaginationTrainingRatingsViewModel
                {
                    TrainingRatings = paginatedRatings,
                    AllCategories = allCategories,
                    CurrentSearchQuery = searchQuery,
                    CurrentRatingFilter = ratingFilter,
                    CurrentCategoryFilter = categoryFilter
                };

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching ratings.");
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;
                return RedirectToAction("Index", "Dashboard");
            }
        }

        /// <summary>
        /// GET /User/TrainingRatings/Edit/{id}
        /// Retrieves the training rating for the specified ID and returns the edit view.
        /// </summary>
        /// <param name="id">The ID of the training rating to edit.</param>
        /// <returns>The edit view with the rating data, or redirects to the index with an error message if an exception occurs.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var rating = await _trainingRatingService.GetTrainingRatingByIdAsync(id);
                return View(rating);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading rating for ID {RatingId}", id);
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// POST /User/TrainingRatings/Edit
        /// Updates a training rating with the provided model data.
        /// </summary>
        /// <param name="model">The <see cref="TrainingRatingDto"/> containing the updated rating data.</param>
        /// <returns>
        /// Redirects to the <see cref="Index"/> action if successful, or
        /// returns a 404 if the rating ID is not valid, or
        /// redirects to the <see cref="EditRatings"/> action with an error message if an unexpected error occurs.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Edit(TrainingRatingDto model)
        {
            try
            {
                await _trainingRatingService.UpdateTrainingRatingAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating rating of {model.Training.Title}!");
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;
                return RedirectToAction("EditRatings", new { id = model.Id });
            }
        }


        /// <summary>
        /// Submits a rating for a training asynchronously.
        /// </summary>
        /// <param name="trainingId">The ID of the training to submit the rating for.</param>
        /// <param name="ratingValue">The rating value to submit, between 1 and 5.</param>
        /// <param name="comment">The rating comment to submit.</param>
        /// <returns>
        /// Redirects to the <see cref="Index"/> action of the <see cref="TrainingsController"/> if successful, or
        /// redirects to the <see cref="Index"/> action of the <see cref="TrainingsController"/> with an error message
        /// if an unexpected error occurs.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitRating(int trainingId, int ratingValue, string comment)
        {
            try
            {
                if (trainingId <= 0)
                {
                    TempData["ToastError"] = "Could not submit rating for an invalid training.";
                    return RedirectToAction("Index", "Trainings");
                }

                await _trainingRatingService.SubmitRatingAsync(trainingId, ratingValue, comment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error submitting the rating for Training ID {TrainingId}", trainingId);
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;
            }

            return RedirectToAction("Index", "Trainings", new { id = trainingId });
        }

    }
}
