using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Users;
using Lurnyx.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Lurnyx.Data.Repositories.Users
{
    /// <summary>
    /// Repository for handling data operations for UserResourceDownload entities.
    /// This repository inherits from BaseRepository as its entity is not soft-deletable.
    /// </summary>
    public class UserResourceDownloadRepository : BaseRepository, IUserResourceDownloadRepository
    {
        public UserResourceDownloadRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Create

        public async Task AddAsync(UserResourceDownload download, int currentUserId)
        {
            var now = DateTime.UtcNow;
            download.CreatedBy = currentUserId;
            download.CreatedAt = now;
            download.UpdatedBy = currentUserId;
            download.UpdatedAt = now;
            download.FirstDownloadedAt = now;
            download.LastDownloadedAt = now;
            download.DownloadCount = 1;

            await this.GetDbSet<UserResourceDownload>().AddAsync(download);
        }

        #endregion

        #region Read

        public async Task<UserResourceDownload?> GetResourceDownloadAsync(int userId, int resourceMaterialId)
        {
            return await this.GetDbSet<UserResourceDownload>()
                             .AsNoTracking()
                             .FirstOrDefaultAsync(d => d.CreatedBy == userId && d.ResourceMaterialId == resourceMaterialId);
        }

        public async Task<List<UserResourceDownload>> GetAllResourceDownloadsAsync(int userId)
        {
            return await this.GetDbSet<UserResourceDownload>()
                             .AsNoTracking()
                             .Where(d => d.CreatedBy == userId)
                             .ToListAsync();
        }

        public async Task<List<UserResourceDownload>> GetRecentResourceDownloadsAsync(int userId, int count)
        {
            return await this.GetDbSet<UserResourceDownload>()
                             .AsNoTracking()
                             .Include(d => d.ResourceMaterial)
                             .Where(d => d.CreatedBy == userId)
                             .OrderByDescending(d => d.LastDownloadedAt)
                             .Take(count)
                             .ToListAsync();
        }

        public async Task<List<DateTime>> GetDownloadActivityDatesAsync(int userId)
        {
            return await this.GetDbSet<UserResourceDownload>()
                             .Where(d => d.CreatedBy == userId)
                             .Select(d => d.LastDownloadedAt)
                             .ToListAsync();
        }

        public async Task<List<UserResourceDownload>> GetDownloadsForTopicAsync(int userId, int topicId)
        {
            return await this.GetDbSet<UserResourceDownload>()
                            .AsNoTracking()
                            .Include(d => d.ResourceMaterial) 
                            .Where(d => d.CreatedBy == userId && d.ResourceMaterial!.TopicId == topicId)
                            .ToListAsync();
        }

        #endregion

        #region Update

        public void Update(UserResourceDownload download, int currentUserId)
        {
            download.UpdatedBy = currentUserId;
            download.UpdatedAt = DateTime.UtcNow;
            download.LastDownloadedAt = DateTime.UtcNow;
            download.DownloadCount++;

            this.GetDbSet<UserResourceDownload>().Update(download);
        }
        
        #endregion
    }
}
