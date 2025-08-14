using AutoMapper;
using Lurnyx.Resources.Constants;
using Lurnyx.Services.Interfaces;
using Lurnyx.Services.Interfaces.Users;
using Lurnyx.WebApp.Models;
using Lurnyx.WebApp.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.WebApp.Controllers.Users
{
    [Authorize(Roles = "SUPER_ADMIN,USER")]
    [Route("User/[controller]/[action]")]
    public class TrainingsController : ControllerBase<TrainingsController>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUserService _userService;
        private readonly ITrainingCategoryService _trainingCategoryService;
        private readonly ITrainingService _trainingService;
        private readonly ITopicService _topicService;
        private readonly IUserTrainingProgressService _userTrainingProgressService;
        private readonly IUserTopicProgressService _userTopicProgressService;
        private readonly IUserResourceDownloadService _userResourceDownloadService;

        public TrainingsController(
                            IConfiguration configuration,
                            ILoggerFactory loggerFactory,
                            IHttpClientFactory httpClientFactory,
                            IHttpContextAccessor httpContextAccessor,
                            IUserService userService,
                            ITrainingCategoryService trainingCategoryService,
                            ITrainingService trainingService,
                            ITopicService topicService,
                            IUserTopicProgressService userTopicProgressService,
                            IUserTrainingProgressService userTrainingProgressService,
                            IUserResourceDownloadService userResourceDownloadService,
                            IMapper mapper = null)
            : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _httpClientFactory = httpClientFactory;
            _userService = userService;
            _trainingCategoryService = trainingCategoryService;
            _trainingService = trainingService;
            _topicService = topicService;
            _userTopicProgressService = userTopicProgressService;
            _userTrainingProgressService = userTrainingProgressService;
            _userResourceDownloadService = userResourceDownloadService;
        }

        /// <summary>
        /// GET /User/Trainings
        /// Displays a paginated list of trainings, filtered by search query, category, and rating.
        /// </summary>
        /// <param name="searchQuery">The search query to filter trainings by.</param>
        /// <param name="ratingFilter">The rating filter to apply to trainings.</param>
        /// <param name="categoryFilter">The category filter to apply to trainings.</param>
        /// <param name="page">The page number to display.</param>
        /// <returns>The view to list all trainings, filtered by the provided criteria.</returns>
        [HttpGet]
        public async Task<IActionResult> Index(string searchQuery = "", string ratingFilter = "", string categoryFilter = "", int page = 1)
        {
            try
            {
                var createViewModel = await _trainingService.GetCreateViewModelAsync();
                var allCategories = createViewModel.CategoryList;

                int? categoryId = null;
                if (!string.IsNullOrEmpty(categoryFilter))
                {
                    var selectedCategory = allCategories.FirstOrDefault(c => c.Name.Equals(categoryFilter, StringComparison.OrdinalIgnoreCase));
                    if (selectedCategory != null)
                    {
                        categoryId = selectedCategory.Id;
                    }
                }

                int.TryParse(ratingFilter, out var rating);
                var ratingValue = string.IsNullOrEmpty(ratingFilter) ? (int?)null : rating;

                var paginatedTrainings = await _trainingService.GetPaginatedTrainingsAsync(page, Const.CardsPageSize, searchQuery, categoryId, ratingValue);

                var model = new PaginationTrainingsViewModel
                {
                    Trainings = paginatedTrainings,
                    AllCategories = allCategories,
                    CurrentSearchQuery = searchQuery,
                    CurrentRatingFilter = ratingFilter,
                    CurrentCategoryFilter = categoryFilter
                };

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching trainings for Browse action.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction("Index", "Dashboard");
            }
        }

        /// <summary>
        /// GET /User/Trainings/{id}
        /// </summary>
        /// <param name="id">The ID of the training to display.</param>
        /// <returns>The view with the training details, or a 404 if the training does not exist.</returns>
        /// <exception cref="Exception">Logs an error and displays a generic error message when an unexpected error occurs.</exception>
        [HttpGet]
        public async Task<IActionResult> Training(int id)
        {
            try
            {
                await _userTrainingProgressService.IncrementTrainingViewCountAsync(id);

                var trainingDto = await _trainingService.GetTrainingByIdAsync(id);
                var (userStatus, isCompleted) = await _userTrainingProgressService.GetUserTrainingStatusInfoAsync(id);

                if (trainingDto.Topics != null)
                {
                    foreach (var topic in trainingDto.Topics)
                    {
                        var topicProgress = await _userTopicProgressService.GetTopicProgressAsync(topic.Id);
                        topic.IsCompletedByUser = topicProgress?.Status == TopicProgressStatusValue.COMPLETED;
                    }
                }

                if ((userStatus == TrainingProgressStatusValue.ENROLLED || userStatus == TrainingProgressStatusValue.STARTED) && !isCompleted)
                {
                    isCompleted = await _userTrainingProgressService.CheckTrainingCompletionAsync(id);
                    if (isCompleted)
                    {
                        await _userTrainingProgressService.MarkTrainingAsCompleteAsync(id);
                        var (updatedStatus, _) = await _userTrainingProgressService.GetUserTrainingStatusInfoAsync(id);
                        userStatus = updatedStatus;
                    }
                }

                var progressViewModel = new UserTrainingProgressViewModel
                {
                    Status = userStatus,
                    IsStarted = userStatus == TrainingProgressStatusValue.STARTED,
                    IsEnrolled = userStatus == TrainingProgressStatusValue.ENROLLED,
                    IsCompleted = isCompleted || userStatus == TrainingProgressStatusValue.COMPLETED
                };

                var viewModel = new TrainingProgressDetailViewModel
                {
                    Training = trainingDto,
                    Progress = progressViewModel
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading training details for ID {TrainingId}", id);
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// Enrolls a user in a training, if the user has not already enrolled.
        /// </summary>
        /// <param name="id">The ID of the training to enroll in.</param>
        /// <returns>A redirect to the training view after updating progress, or an error message if an exception occurs.</returns>
        [HttpGet]
        public async Task<IActionResult> EnrollTraining(int id)
        {
            try
            {
                var (status, _) = await _userTrainingProgressService.GetUserTrainingStatusInfoAsync(id);

                if (status == TrainingProgressStatusValue.VIEWED)
                {
                    await _userTrainingProgressService.RecordTrainingProgressAsync(id, TrainingProgressStatusValue.ENROLLED);
                }

                return RedirectToAction("Training", new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error enrolling in training with ID {TrainingId}", id);
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction("Training", new { id });
            }
        }

        /// <summary>
        /// GET /User/Trainings/{trainingId}/Topic/{id}
        /// </summary>
        /// <param name="id">The ID of the topic to display training materials for.</param>
        /// <param name="trainingId">The ID of the parent training.</param>
        /// <returns>The view with the training materials, or a redirect to the training view if an exception occurs.</returns>
        /// <exception cref="Exception">Logs an error and displays a generic error message when an unexpected error occurs.</exception>
        [HttpGet]
        public async Task<IActionResult> TopicMaterials(int id, int trainingId)
        {
            try
            {
                await _userTopicProgressService.IncrementTopicViewCountAsync(id);

                var topic = await _topicService.GetTopicByIdAsync(id);

                // Get the user's progress for this topic
                var topicProgress = await _userTopicProgressService.GetTopicProgressAsync(id);

                topic.IsCompletedByUser = topicProgress?.Status == TopicProgressStatusValue.COMPLETED;

                return View(topic);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading training materials for Topic ID {TopicId}", id);
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction("Training", new { id = trainingId });
            }
        }

        /// <summary>
        /// GET /User/Trainings/ViewResource
        /// Records a user's interaction with a resource and redirects to the resource's URL.
        /// </summary>
        /// <param name="resourceId">The ID of the resource to access.</param>
        /// <param name="topicId">The ID of the topic the resource belongs to.</param>
        /// <param name="redirectUrl">The URL to redirect the user to.</param>
        /// <returns>A redirect to the specified resource URL.</returns>
        [HttpGet]
        public async Task<IActionResult> ViewResource(int resourceId, int topicId, string redirectUrl)
        {
            try
            {
                await _userResourceDownloadService.RecordDownloadAsync(resourceId);

                var topic = await _topicService.GetTopicByIdAsync(topicId);
                await _userTopicProgressService.UpdateProgressAfterInteractionAsync(topicId, topic.TrainingId);

                return Redirect(redirectUrl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing resource view for Resource ID {ResourceId}", resourceId);
                TempData["ToastError"] = "An error occurred while accessing the resource.";

                return RedirectToAction("TopicMaterials", new { id = topicId, trainingId = _topicService.GetTopicByIdAsync(topicId).Result.TrainingId });
            }
        }

        /// <summary>
        /// GET /User/Trainings/{trainingId}/Topic/{topicId}/DownloadResource/{resourceId}
        /// </summary>
        /// <param name="resourceId">The ID of the resource to download.</param>
        /// <param name="topicId">The ID of the topic that the resource belongs to.</param>
        /// <param name="trainingId">The ID of the parent training.</param>
        /// <param name="fileUrl">The URL of the resource to download.</param>
        /// <param name="fileName">The name of the file to download.</param>
        /// <returns>The file as a byte array, or a redirect to the topic materials view if an exception occurs.</returns>
        /// <exception cref="Exception">Logs an error and displays a generic error message when an unexpected error occurs.</exception>
        [HttpGet]
        public async Task<IActionResult> DownloadResource(int resourceId, int topicId, int trainingId, string fileUrl, string fileName)
        {
            try
            {
                await _userResourceDownloadService.RecordDownloadAsync(resourceId);
                await _userTopicProgressService.UpdateProgressAfterInteractionAsync(topicId, trainingId);

                var client = _httpClientFactory.CreateClient();
                var fileBytes = await client.GetByteArrayAsync(fileUrl);

                return File(fileBytes, "application/octet-stream", fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing resource download for Resource ID {ResourceId}", resourceId);
                TempData["ToastError"] = "An error occurred while accessing the resource.";

                return RedirectToAction("TopicMaterials", new { id = topicId, trainingId });
            }
        }
        
        /// <summary>
        /// GET /User/Trainings/{trainingId}/Topic/{topicId}/MarkTopicAsComplete
        /// </summary>
        /// <param name="topicId">The ID of the topic to mark as complete.</param>
        /// <param name="trainingId">The ID of the parent training.</param>
        /// <returns>A redirect to the training view after marking the topic as complete, or an error message if an exception occurs.</returns>
        /// <exception cref="Exception">Logs an error and displays a generic error message when an unexpected error occurs.</exception>
        [HttpGet]
        public async Task<IActionResult> MarkTopicAsComplete(int topicId, int trainingId)
        {
            await _userTopicProgressService.UpdateProgressAfterInteractionAsync(topicId, trainingId, isTopicExplicitlyCompleted: true);

            TempData["ToastSuccess"] = "Topic marked as complete!";
            return RedirectToAction("Training", new { id = trainingId });
        }
    }
}
