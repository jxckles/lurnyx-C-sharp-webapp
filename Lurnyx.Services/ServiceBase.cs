using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Lurnyx.Services
{
    /// <summary>
    /// A foundational base class for services that provides common functionality 
    /// </summary>
    public abstract class ServiceBase
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the ServiceBase class.
        /// </summary>
        /// <param name="httpContextAccessor">Accessor to the current HTTP context, used for user authentication.</param>
        /// <param name="loggerFactory">Factory to create a logger instance for the service.</param>
        protected ServiceBase(IHttpContextAccessor httpContextAccessor, ILoggerFactory loggerFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = loggerFactory.CreateLogger(GetType());
        }

        /// <summary>
        /// Gets the ID of the currently authenticated user from the HttpContext.
        /// </summary>
        /// <returns>The user's ID, or 0 if not authenticated.</returns>
        protected int GetCurrentUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var currentUserId))
            {
                return 0;
            }
            return currentUserId;
        }

        /// <summary>
        /// Throws an UnauthorizedAccessException if the current user is not authenticated.
        /// </summary>
        protected void EnsureUserIsAuthenticated(int userId)
        {
            if (userId == 0)
            {
                throw new UnauthorizedAccessException(Resources.Messages.Errors.UserNotAuth);
            }
        }
    }
}
