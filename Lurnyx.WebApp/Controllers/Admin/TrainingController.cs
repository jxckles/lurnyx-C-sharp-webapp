using AutoMapper;
using Lurnyx.Resources.Constants;
using Lurnyx.Services.Interfaces;
using Lurnyx.Services.ServiceModels;
using Lurnyx.WebApp.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lurnyx.WebApp.Controllers.Admin
{
    [Authorize(Roles = "SUPER_ADMIN,ADMIN")]
    [Route("Admin/[controller]/[action]")]
    public class TrainingController : ControllerBase<TrainingController>
    {
        private readonly ITrainingService _trainingService;

        /// <summary>
        /// Constructor
        /// </summary>
        public TrainingController(
            IHttpContextAccessor httpContextAccessor,
            ILoggerFactory loggerFactory,
            IConfiguration configuration,
            ITrainingService trainingService,
            IMapper mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _trainingService = trainingService ?? throw new ArgumentNullException(nameof(trainingService));
        }

        #region Create
        
        /// <summary>
        /// GET: /Admin/Training/Create
        /// </summary>
        /// <returns>The Create Training page.</returns>
        /// <remarks>
        /// This action displays the form for creating a new training.
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var model = await _trainingService.GetCreateViewModelAsync();
                return View(model);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error loading the Create Training page.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// Handles the HTTP POST request to create a new training.
        /// Validates the model, and if valid, attempts to add the new training via the service.
        /// On successful creation, sets a success message in TempData and redirects to the index view.
        /// If the model state is invalid, reloads the form with the current model data.
        /// Catches and handles specific exceptions, logging errors and setting appropriate error messages in TempData.
        /// </summary>
        /// <param name="training">The TrainingDto containing the details of the training to be created.</param>
        /// <returns>Redirects to the index view on success; otherwise, returns the create view with the current model data.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create(TrainingDto training)
        {
            if (!ModelState.IsValid)
            {
                var vm = await _trainingService.GetCreateViewModelAsync();
                training.CategoryList = vm.CategoryList;
                return View(training);
            }   

            try
            {
                await _trainingService.AddTrainingAsync(training);
                TempData["ToastSuccess"] = $"Training '{training.Title}' created successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidDataException ex)
            {
                TempData["ToastError"] = ex.Message;
                var vm = await _trainingService.GetCreateViewModelAsync();
                training.CategoryList = vm.CategoryList;
                return View(training);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Error creating training.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                var vm = await _trainingService.GetCreateViewModelAsync();
                training.CategoryList = vm.CategoryList;
                return View(training);
            }
        }
        #endregion

        #region Read

        /// <summary>
        /// GET /Admin/Training
        /// Displays a paginated list of trainings, filtered by search query, category, and rating.
        /// </summary>
        /// <param name="searchQuery">The search query to filter trainings by.</param>
        /// <param name="categoryId">The ID of the category to filter trainings by.</param>
        /// <param name="rating">The rating to filter trainings by.</param>
        /// <param name="page">The page number to display.</param>
        /// <returns>The view to list all trainings, filtered by the provided criteria.</returns>
        [HttpGet]
        public async Task<IActionResult> Index(string searchQuery, int? categoryId, int? rating, int page = 1)
        {
            try
            {
                // Pass all filter parameters to the service
                var paginatedTrainings = await _trainingService.GetPaginatedTrainingsAsync(page, Const.CardsPageSize, searchQuery, categoryId, rating);

                // Populate ViewData for filter dropdowns
                ViewData["TrainingCategories"] = await _trainingService.GetTrainingCategoriesAsSelectListAsync(categoryId);
                ViewData["Ratings"] = new SelectList(
                    new[] {
                        new { Value = 1, Text = "1+ Star Rating" },
                        new { Value = 2, Text = "2+ Stars Rating" },
                        new { Value = 3, Text = "3+ Stars Rating" },
                        new { Value = 4, Text = "4+ Stars Rating" },
                        new { Value = 5, Text = "5 Star Rating" }
                    }, "Value", "Text", rating);
                
                ViewData["CurrentSearch"] = searchQuery;

                return View(paginatedTrainings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading trainings index page.");
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;
                return RedirectToAction("Index", "User");
            }
        }

        /// <summary>
        /// GET /Admin/Training/Details/{id}
        /// </summary>
        /// <param name="id">The ID of the training to display.</param>
        /// <returns>The view with the training details, or a 404 if the training does not exist.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the training does not exist.</exception>
        /// <exception cref="Exception">Logs an error and displays a generic error message when an unexpected error occurs.</exception>
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                await _trainingService.IncrementViewCountAsync(id);
                var training = await _trainingService.GetTrainingByIdAsync(id);
                return View(training);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error loading training details for ID {TrainingId}", id);
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(Index));
            }
        }
        #endregion

        #region Update
        
        /// <summary>
        /// GET /Admin/Training/Edit/{id}
        /// </summary>
        /// <param name="id">The ID of the training to edit.</param>
        /// <returns>The edit view with the training data, or a 404 if the training does not exist.
        /// Displays appropriate error messages for any exceptions encountered.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var training = await _trainingService.GetTrainingByIdAsync(id);
                return View(training);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading training for editing. ID: {TrainingId}", id);
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// Handles the HTTP POST request for editing a training.
        /// Validates the incoming model, checks for matching IDs, and updates the training.
        /// On success, sets a success message and redirects to the details page.
        /// Handles and logs exceptions, setting error messages and returning appropriate responses.
        /// </summary>
        /// <param name="id">The ID of the training to edit.</param>
        /// <param name="model">The training data transfer object containing the updated training details.</param>
        /// <returns>The edit view with the training data if the model is invalid, a 404 if the training does not exist, or a redirect to the details page on successful update.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TrainingDto model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                var vm = await _trainingService.GetCreateViewModelAsync();
                model.CategoryList = vm.CategoryList;
                return View(model);
            }
            
            try
            {
                await _trainingService.UpdateTrainingAsync(model);
                TempData["ToastSuccess"] = "Training updated successfully.";
                return RedirectToAction(nameof(Details), new { id = model.Id });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating training. ID: {TrainingId}", model.Id);
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;

                var errorVm = await _trainingService.GetCreateViewModelAsync();
                model.CategoryList = errorVm.CategoryList;
                return View(model);
            }
        }
        #endregion

        #region Delete

        /// <summary>
        /// Handles the HTTP POST request for deleting a training.
        /// Calls the service to delete the training and logs errors.
        /// On success, sets a success message and redirects to the index page.
        /// Handles and logs exceptions, setting error messages and redirecting to the index page.
        /// </summary>
        /// <param name="id">The ID of the training to delete.</param>
        /// <returns>A redirect to the index page.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _trainingService.DeleteTrainingAsync(id);
                TempData["ToastSuccess"] = "Training and its topics were deleted successfully.";
            }
            catch (KeyNotFoundException)
            {
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.TrainingDoesNotExist;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting training. ID: {TrainingId}", id);
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
