using AutoMapper;
using Lurnyx.Services.Interfaces.Users;
using Lurnyx.Services.ServiceModels;
using Lurnyx.WebApp.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lurnyx.WebApp.Controllers.Users
{
    [Authorize(Roles = "SUPER_ADMIN,USER")]
    [Route("User/[controller]/[action]")]
    public class DashboardController : ControllerBase<DashboardController>
    {
        private readonly IUserDashboardService _userDashboardService;

        public DashboardController(
                            IHttpContextAccessor httpContextAccessor,
                            ILoggerFactory loggerFactory,
                            IConfiguration configuration,
                            IUserDashboardService userDashboardService,
                            IMapper mapper = null)
            : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _userDashboardService = userDashboardService ?? throw new ArgumentNullException(nameof(userDashboardService));
        }

        /// <summary>
        /// GET /User/Dashboard
        /// Displays the user's dashboard, showing stats, recent activities, learning progress, and suggested trainings.
        /// </summary>
        /// <returns>The view with the user's dashboard details, or a redirect to the dashboard with a toast error message if an unexpected error occurs.</returns>
        /// <exception cref="Exception">Logs an error and displays a generic error message when an unexpected error occurs.</exception>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var dashboardData = await _userDashboardService.GetDashboardDataAsync();

                var model = _mapper.Map<DashboardDto>(dashboardData);

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching dashboard data for current user.");
                TempData["ToastError"] = Lurnyx.Resources.Messages.Errors.GenericError;

                var emptyModel = new DashboardDto
                {
                    Stats = new(),
                    RecentActivities = new(),
                    Progress = new(),
                    SuggestedTrainings = new()
                };
                return View(emptyModel);
            }
        }
    }
}
