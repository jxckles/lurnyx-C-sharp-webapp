using AutoMapper;
using Lurnyx.Resources.Constants;
using Lurnyx.Services.Interfaces;
using Lurnyx.Services.ServiceModels;
using Lurnyx.WebApp.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lurnyx.WebApp.Controllers.Admin
{
    [Authorize(Roles = "SUPER_ADMIN,ADMIN")]
    [Route("Admin/[controller]/[action]")]
    public class TopicController : ControllerBase<TopicController>
    {
        private readonly ITopicService _topicService;
        private readonly ITrainingService _trainingService; 

        /// <summary>
        /// Constructor
        /// </summary>
        public TopicController(
            IHttpContextAccessor httpContextAccessor,
            ILoggerFactory loggerFactory,
            IConfiguration configuration,
            ITopicService topicService,
            ITrainingService trainingService, 
            IMapper mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _topicService = topicService ?? throw new ArgumentNullException(nameof(topicService));
            _trainingService = trainingService ?? throw new ArgumentNullException(nameof(trainingService)); 
        }

        #region Create

        /// <summary>
        /// GET /Admin/Topic/Create
        /// </summary>
        /// <param name="trainingId">The ID of the training to which the topic belongs.</param>
        /// <returns>The view to create a new topic.</returns>
        [HttpGet]
        public async Task<IActionResult> Create(int trainingId = 0)
        {
            try
            {
                var vm = await _topicService.GetCreateViewModelAsync(trainingId);
                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading the create topic form for Training ID {TrainingId}.", trainingId);
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                // If the user was trying to create a topic for a specific training, redirect there.
                if (trainingId > 0)
                {
                    return RedirectToAction("Details", "Training", new { id = trainingId });
                }
                // Otherwise, go back to the main topic list.
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// POST /Admin/Topic/Create
        /// </summary>
        /// <param name="model">The view model containing the topic data.</param>
        /// <returns>The view to create a new topic, or the topic list if the topic was created successfully.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TopicDto model)
        {
            try
            {
                await _topicService.AddTopicAsync(model);
                TempData["ToastSuccess"] = "Topic created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidDataException ex)
            {
                TempData["ToastError"] = ex.Message;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating topic for Training ID {TrainingId}.", model.TrainingId);
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
            }

            var errorVm = await _topicService.GetCreateViewModelAsync(model.TrainingId);
            model.TrainingList = errorVm.TrainingList;
            return View(model);
        }

        #endregion

        #region Read

        /// <summary>
        /// GET /Admin/Topic
        /// </summary>
        /// <param name="page">The page number to display.</param>
        /// <param name="searchQuery">The search query to filter topics by.</param>
        /// <param name="trainingCategoryId">The ID of the training category to filter topics by.</param>
        /// <param name="trainingId">The ID of the training to filter topics by.</param>
        /// <returns>The view to list all topics, filtered by the provided criteria.</returns>
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, string searchQuery = null, int? trainingCategoryId = null, int? trainingId = null)
        {
            try
            {
                var paginatedTopics = await _topicService.GetPaginatedTopicsAsync(page, Const.HorizontalCardPageSize, searchQuery, trainingCategoryId, trainingId);

                ViewData["TrainingCategories"] = await _trainingService.GetTrainingCategoriesAsSelectListAsync(trainingCategoryId);
                ViewData["Trainings"] = await _trainingService.GetTrainingsAsSelectListAsync(trainingId, trainingCategoryId);
                
                ViewData["CurrentFilter"] = searchQuery;

                return View(paginatedTopics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading topics index page.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction("Index", "User");
            }
        }

        /// <summary>
        /// API endpoint to get a list of trainings for a specific category.
        /// Used by the cascading filter on the Topic index page.
        /// </summary>
        /// <param name="categoryId">The ID of the selected training category.</param>
        /// <returns>A JSON list of trainings.</returns>
        [HttpGet]
        public async Task<IActionResult> GetTrainingsForCategory(int? categoryId)
        {
            var filteredTrainings = await _trainingService.GetTrainingsByCategoryAsync(categoryId);

            var result = filteredTrainings.Select(t => new { t.Id, t.Title });

            return Json(result);
        }

        /// <summary>
        /// API endpoint to get the category for a specific training.
        /// Used by the cascading filter on the Topic index page.
        /// </summary>
        /// <param name="trainingId">The ID of the selected training.</param>
        /// <returns>A JSON object containing the category ID.</returns>
        [HttpGet]
        public async Task<IActionResult> GetCategoryForTraining(int trainingId)
        {
            if (trainingId == 0)
            {
                return Json(new { categoryId = "" });
            }

            var training = await _trainingService.GetTrainingByIdAsync(trainingId);
            if (training == null)
            {
                return NotFound();
            }

            return Json(new { categoryId = training.TrainingCategoryId });
        } 

        /// <summary>
        /// GET /Admin/Topic/Details/{id}
        /// </summary>
        /// <param name="id">The ID of the topic to display.</param>
        /// <returns>The view with the topic details, or a 404 if the topic does not exist.</returns>
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                await _topicService.IncrementViewCountAsync(id);
                var topic = await _topicService.GetTopicByIdAsync(id);
                return View(topic);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading topic details for ID {TopicId}", id);
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(Index));
            }
        }

        #endregion

        #region Update
        
        /// <summary>
        /// GET /Admin/Topic/Edit/{id}
        /// </summary>
        /// <param name="id">The ID of the topic to edit.</param>
        /// <returns>The edit topic view with the topic data, or a 404 if the topic does not exist.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var topic = await _topicService.GetTopicByIdAsync(id);
                return View(topic);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading topic for editing. ID: {TopicId}", id);
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// POST /Admin/Topic/Edit/{id}
        /// </summary>
        /// <param name="id">The ID of the topic to update.</param>
        /// <param name="model">The topic data to update the topic with.</param>
        /// <returns>The topic details view if the update was successful, a 404 if the topic does not exist, or the edit view with error messages if the update failed.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TopicDto model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                await _topicService.UpdateTopicAndResourcesAsync(model);
                TempData["ToastSuccess"] = "Topic updated successfully.";
                return RedirectToAction(nameof(Details), new { id = model.Id });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidDataException ex)
            {
                TempData["ToastError"] = ex.Message;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating topic. ID: {TopicId}", model.Id);
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
            }
            
            var errorVm = await _topicService.GetTopicByIdAsync(id);
            model.TrainingList = errorVm.TrainingList;
            model.ResourceMaterials = errorVm.ResourceMaterials;
            return View(model);
        }

        #endregion

        #region Delete
        
        /// <summary>
        /// POST /Admin/Topic/DeleteConfirmed/{id}
        /// </summary>
        /// <param name="id">The ID of the topic to delete.</param>
        /// <param name="trainingId">The ID of the training to which the topic belongs.</param>
        /// <returns>The topic list view if the delete was successful, or the same view with an error message if the delete failed.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int trainingId)
        {
            try
            {
                await _topicService.DeleteTopicAsync(id);
                TempData["ToastSuccess"] = "Topic deleted successfully.";
            }
            catch (KeyNotFoundException)
            {
                TempData["ToastError"] = "Topic not found.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting topic. ID: {TopicId}", id);
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
