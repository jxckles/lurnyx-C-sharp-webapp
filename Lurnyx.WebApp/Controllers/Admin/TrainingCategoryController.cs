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
    public class TrainingCategoryController : ControllerBase<TrainingCategoryController>
    {
        private readonly ITrainingCategoryService _trainingCategoryService;
       
        /// <summary>
        /// Constructor
        /// </summary>
        public TrainingCategoryController(IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              ITrainingCategoryService trainingCategoryService,
                              IMapper mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _trainingCategoryService = trainingCategoryService;
        }

        #region Create

        /// <summary>
        /// Displays the form for creating a new training category.
        /// Initializes a new instance of <see cref="TrainingCategoryDto"/> to be used in the view.
        /// Logs any exceptions encountered during navigation and displays a generic error message.
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                var trainingCat = new TrainingCategoryDto();
                return View(trainingCat);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error navigating to create training category page.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// Handles the HTTP POST request for creating a new training category.
        /// Saves the training category to the database via the service.
        /// Logs any exceptions encountered during saving and displays a generic error message.
        /// </summary>
        /// <param name="trainingCategory">The training category to be created.</param>
        /// <returns>The page to be redirected to after the operation is completed.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingCategoryDto trainingCategory)
        {
            try
            {
                await _trainingCategoryService.AddTrainingCategoryAsync(trainingCategory);
                TempData["ToastSuccess"] = $"Category '{trainingCategory.Name}' created successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidDataException ex)
            {
                TempData["ToastError"] = ex.Message;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Error creating training category.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
            }

            return View(trainingCategory);
        }

        #endregion


        #region Read
        
        /// <summary>
        /// Displays the list of all training categories, filtered by the <paramref name="searchQuery"/>.
        /// If the query is empty, all categories are displayed.
        /// Saves the search query to the ViewData to maintain state.
        /// Logs any exceptions encountered during navigation and displays a generic error message.
        /// </summary>
        /// <param name="searchQuery">The search query to filter the training categories by.</param>
        /// <param name="page">The page number to display.</param>
        /// <returns>The view to list all training categories, filtered by the search query.</returns>
        [HttpGet]
        public async Task<IActionResult> Index(string searchQuery, int page = 1)
        {
            try
            {
                var paginatedData = await _trainingCategoryService.GetPaginatedTrainingCategoriesAsync(page, Const.CardsPageSize, searchQuery);
                
                ViewData["CurrentFilter"] = searchQuery;
                
                return View(paginatedData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching training categories.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction("Index", "User");
            }
        }

        /// <summary>
        /// GET /Admin/TrainingCategory/Details/{id}
        /// </summary>
        /// <param name="id">The ID of the training category to display.</param>
        /// <returns>The view with the training category details, or a 404 if the category does not exist.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the training category does not exist.</exception>
        /// <exception cref="Exception">Logs an error and displays a generic error message when an unexpected error occurs.</exception>
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var trainingCategory = await _trainingCategoryService.GetTrainingCategoryByIdAsync(id);
                return View(trainingCategory);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching details for training category ID {id}.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return RedirectToAction(nameof(Index));
            }   
        }

        #endregion

        #region Update

        /// <summary>
        /// GET /Admin/TrainingCategory/Edit/{id}
        /// </summary>
        /// <param name="id">The ID of the training category to edit.</param>
        /// <returns>The edit view with the training category data, or a 404 if the category does not exist.
        /// Displays appropriate error messages for any exceptions encountered.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var trainingCategory = await _trainingCategoryService.GetTrainingCategoryByIdAsync(id);
                return View(trainingCategory);
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
                _logger.LogError(ex, $"Error loading edit page for training category ID {id}.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
            }

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// POST /Admin/TrainingCategory/Edit
        /// </summary>
        /// <param name="trainingCategory">The view model containing the training category data.</param>
        /// <returns>The training category details view if the update was successful, or the edit view with an error message if the update failed.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TrainingCategoryDto trainingCategory)
        {
            try
            {   
                await _trainingCategoryService.UpdateTrainingCategoryAsync(trainingCategory);
                TempData["ToastSuccess"] = $"Category '{trainingCategory.Name}' updated successfully";
                return RedirectToAction(nameof(Details), new { id = trainingCategory.Id });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Error updating training category.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
                return View(trainingCategory);
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// Handles the HTTP POST request for deleting a training category by its ID.
        /// Attempts to retrieve and delete the specified category via the service.
        /// On successful deletion, sets a success message in TempData.
        /// Logs and handles exceptions, returning a 404 for not found categories and setting an error message for unexpected errors.
        /// </summary>
        /// <param name="id">The ID of the training category to delete.</param>
        /// <returns>Redirects to the index view after the operation.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingCategory = await _trainingCategoryService.GetTrainingCategoryByIdAsync(id);
                await _trainingCategoryService.DeleteTrainingCategoryAsync(id); 
                TempData["ToastSuccess"] = $"Category '{existingCategory.Name}' deleted successfully";
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting training category ID {id}.");
                TempData["ToastError"] = Resources.Messages.Errors.GenericError;
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
