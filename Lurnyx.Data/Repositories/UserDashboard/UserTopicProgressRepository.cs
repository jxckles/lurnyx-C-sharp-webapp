using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Users;
using Lurnyx.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Lurnyx.Data.Repositories.Users
{
    /// <summary>
    /// Repository for handling data operations for UserTopicProgress entities.
    /// This repository inherits from BaseRepository as its entity is not soft-deletable.
    /// </summary>
    public class UserTopicProgressRepository : BaseRepository, IUserTopicProgressRepository
    {
        public UserTopicProgressRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Create

        public async Task AddAsync(UserTopicProgress progress, int currentUserId)
        {
            var now = DateTime.UtcNow;
            progress.CreatedBy = currentUserId;
            progress.CreatedAt = now;
            progress.UpdatedBy = currentUserId;
            progress.UpdatedAt = now;

            await this.GetDbSet<UserTopicProgress>().AddAsync(progress);
        }

        #endregion

        #region Read

        public async Task<UserTopicProgress?> GetTopicProgressAsync(int userId, int topicId)
        {
            return await this.GetDbSet<UserTopicProgress>()
                             .FirstOrDefaultAsync(p => p.CreatedBy == userId && p.TopicId == topicId);
        }

        public async Task<List<UserTopicProgress>> GetRecentTopicProgressAsync(int userId, int count)
        {
            return await this.GetDbSet<UserTopicProgress>()
                             .AsNoTracking()
                             .Include(p => p.Topic)
                             .Where(p => p.CreatedBy == userId)
                             .OrderByDescending(p => p.LastAccessedAt)
                             .Take(count)
                             .ToListAsync();
        }

        public async Task<List<DateTime>> GetTopicActivityDatesAsync(int userId)
        {
            return await this.GetDbSet<UserTopicProgress>()
                             .Where(p => p.CreatedBy == userId)
                             .Select(p => p.LastAccessedAt)
                             .ToListAsync();
        }

        #endregion

        #region Update

        public void Update(UserTopicProgress progress, int currentUserId)
        {
            progress.UpdatedBy = currentUserId;
            progress.UpdatedAt = DateTime.UtcNow;

            this.GetDbSet<UserTopicProgress>().Update(progress);
        }
        
        public async Task IncrementViewCountAsync(int userId, int topicId)
        {
            var progress = await this.GetDbSet<UserTopicProgress>()
                                     .FirstOrDefaultAsync(p => p.CreatedBy == userId && p.TopicId == topicId);

            if (progress != null)
            {
                progress.ViewCount++;
                progress.LastAccessedAt = DateTime.UtcNow;
                Update(progress, userId);
            }
        }
        
        #endregion
    }
}
