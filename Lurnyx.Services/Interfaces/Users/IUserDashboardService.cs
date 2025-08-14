using Lurnyx.Services.ServiceModels;

namespace Lurnyx.Services.Interfaces.Users
{
    /// <summary>
    /// Defines the contract for a service that provides data for the user dashboard.
    /// </summary>
    public interface IUserDashboardService
    {
        /// <summary>
        /// Gets all the necessary data for the user dashboard.
        /// </summary>
        /// <returns>A DashboardDto populated with the user's stats, progress, and activities.</returns>
        Task<DashboardDto> GetDashboardDataAsync();
    }
}
