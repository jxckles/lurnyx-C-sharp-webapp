using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Users;
using Lurnyx.Data.Models;
using Lurnyx.Services.Interfaces.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Lurnyx.Services.Services.Users
{
    public class UserResourceDownloadService : ServiceBase, IUserResourceDownloadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserResourceDownloadRepository _userResourceDownloadRepository;

        /// <summary>
        /// Initializes a new instance of the UserResourceDownloadService class.
        /// </summary>
        public UserResourceDownloadService(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IUserResourceDownloadRepository userResourceDownloadRepository,
            ILoggerFactory loggerFactory 
            ) : base(httpContextAccessor, loggerFactory) 
        {
            _unitOfWork = unitOfWork;
            _userResourceDownloadRepository = userResourceDownloadRepository;
        }

        #region Create / Update

        public async Task RecordDownloadAsync(int resourceMaterialId)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);
            
            var existingDownload = await _userResourceDownloadRepository.GetResourceDownloadAsync(currentUserId, resourceMaterialId);

            if (existingDownload != null)
            {
                _userResourceDownloadRepository.Update(existingDownload, currentUserId);
            }
            else
            {
                var newDownload = new UserResourceDownload
                {
                    ResourceMaterialId = resourceMaterialId,
                };
                await _userResourceDownloadRepository.AddAsync(newDownload, currentUserId);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        #endregion

        #region Read

        public async Task<bool> IsDownloaded(int resourceMaterialId)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var downloadedResources = await _userResourceDownloadRepository.GetResourceDownloadAsync(currentUserId, resourceMaterialId);
            return downloadedResources != null;
        }

        #endregion
    }
}
