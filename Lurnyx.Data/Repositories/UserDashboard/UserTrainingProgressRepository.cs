using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Users;
using Lurnyx.Data.Models;
using Microsoft.EntityFrameworkCore;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Data.Repositories.Users
{
    /// <summary>
    /// Repository for handling data operations for UserTrainingProgress entities.
    /// This repository inherits from BaseRepository as its entity is not soft-deletable.
    /// </summary>
    public class UserTrainingProgressRepository : BaseRepository, IUserTrainingProgressRepository
    {
        public UserTrainingProgressRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Create

        public async Task AddAsync(UserTrainingProgress progress, int currentUserId)
        {
            var now = DateTime.UtcNow;
            progress.CreatedBy = currentUserId;
            progress.CreatedAt = now;
            progress.UpdatedBy = currentUserId;
            progress.UpdatedAt = now;

            await this.GetDbSet<UserTrainingProgress>().AddAsync(progress);
        }

        #endregion

        #region Read

        public async Task<UserTrainingProgress?> GetTrainingProgressAsync(int userId, int trainingId)
        {
            return await this.GetDbSet<UserTrainingProgress>()
                             .FirstOrDefaultAsync(p => p.CreatedBy == userId && p.TrainingId == trainingId);
        }

        public async Task<List<UserTrainingProgress>> GetAllTrainingProgressAsync(int userId)
        {
            return await this.GetDbSet<UserTrainingProgress>()
                             .AsNoTracking()
                             .Where(p => p.CreatedBy == userId && p.Status != TrainingProgressStatusValue.VIEWED)
                             .ToListAsync();
        }

        public async Task<UserTrainingProgress?> GetMostViewedTrainingProgressAsync(int userId)
        {
            return await this.GetDbSet<UserTrainingProgress>()
                             .AsNoTracking()
                             .Include(p => p.Training)
                             .Where(p => p.CreatedBy == userId)
                             .OrderByDescending(p => p.ViewCount)
                             .FirstOrDefaultAsync();
        }

        public async Task<List<UserTrainingProgress>> GetRecentTrainingProgressAsync(int userId, int count)
        {
            return await this.GetDbSet<UserTrainingProgress>()
                             .AsNoTracking()
                             .Include(p => p.Training)
                             .Where(p => p.CreatedBy == userId)
                             .OrderByDescending(p => p.LastAccessedAt)
                             .Take(count)
                             .ToListAsync();
        }

        public async Task<List<DateTime>> GetTrainingActivityDatesAsync(int userId)
        {
            return await this.GetDbSet<UserTrainingProgress>()
                             .Where(p => p.CreatedBy == userId)
                             .Select(p => p.LastAccessedAt)
                             .ToListAsync();
        }

        #endregion

        #region Update

        public void Update(UserTrainingProgress progress, int currentUserId)
        {
            progress.UpdatedBy = currentUserId;
            progress.UpdatedAt = DateTime.UtcNow;

            this.GetDbSet<UserTrainingProgress>().Update(progress);
        }

        public async Task IncrementViewCountAsync(int userId, int trainingId)
        {
            var progress = await this.GetDbSet<UserTrainingProgress>()
                                     .FirstOrDefaultAsync(p => p.CreatedBy == userId && p.TrainingId == trainingId);

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
