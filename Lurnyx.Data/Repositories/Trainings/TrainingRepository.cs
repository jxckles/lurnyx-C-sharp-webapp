using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Trainings;
using Lurnyx.Data.Models;
using Microsoft.EntityFrameworkCore;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Data.Repositories
{
    /// <summary>
    /// Repository for handling data operations for Training entities.
    /// Inherits from the generic Repository<T> to get common CRUD functionality.
    /// </summary>
    public class TrainingRepository : Repository<Training>, ITrainingRepository
    {
        public TrainingRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Private helper method to create a base query with all necessary includes.
        /// </summary>
        private IQueryable<Training> GetQueryWithDetails()
        {
            return this.GetDbSet<Training>()
                       .Where(t => t.DeletedAt == null)
                       .Include(t => t.TrainingCategory)
                       .Include(t => t.Topics!.Where(topic => topic.DeletedAt == null))
                       .Include(t => t.Ratings!.Where(rating => rating.DeletedAt == null))
                       .Include(t => t.CreatedByUser)
                       .Include(t => t.UpdatedByUser)
                       .AsNoTracking();
        }
        
        public async Task<PaginatedList<Training>> GetPaginatedAndFilteredWithDetailsAsync(
        int pageNumber, int pageSize, string searchQuery, int? categoryId, int? rating)
        {
            var query = GetQueryWithDetails();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(t => t.Title.Contains(searchQuery));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(t => t.TrainingCategoryId == categoryId.Value);
            }

            if (rating.HasValue)
            {
                query = query.Where(t => t.Ratings!.Any() && t.Ratings!.Average(r => r.Rating) >= rating.Value);
            }

            query = query.OrderByDescending(t => t.UpdatedAt);

            return await PaginatedList<Training>.CreateAsync(query, pageNumber, pageSize);
        }
        
        public async Task<Training> GetByIdWithDetailsAsync(int id)
        {
            var training = await GetQueryWithDetails()
                           .FirstOrDefaultAsync(t => t.Id == id);

            return training ?? throw new KeyNotFoundException(Resources.Messages.Errors.TrainingDoesNotExist);
        }
        
        public async Task<List<Training>> GetSuggestedTrainingsForUserAsync(int userId, int count)
        {
            var committedStatuses = new[]
            {
                TrainingProgressStatusValue.ENROLLED,
                TrainingProgressStatusValue.STARTED,
                TrainingProgressStatusValue.COMPLETED
            };

            var committedTrainingIds = await this.Context.Set<UserTrainingProgress>()
                                                .Where(p => p.CreatedBy == userId && committedStatuses.Contains(p.Status))
                                                .Select(p => p.TrainingId)
                                                .ToListAsync();

            return await GetQueryWithDetails()
                                .Where(t => !committedTrainingIds.Contains(t.Id))
                                .OrderByDescending(t => t.Ratings!.Any() ? t.Ratings!.Average(r => r.Rating) : 0)
                                .ThenByDescending(t => t.ViewCount)
                                .Take(count)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Training>> GetTrainingsByCategoryAsync(int? categoryId)
        {
            var query = this.GetDbSet<Training>()
                            .Where(t => t.DeletedAt == null);

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(t => t.TrainingCategoryId == categoryId.Value);
            }

            return await query
                        .OrderBy(t => t.Title)
                        .Select(t => new Training { Id = t.Id, Title = t.Title }) 
                        .ToListAsync();
        }
        
        public async Task IncrementViewCountAsync(int trainingId, int currentUserId)
        {
            var training = await base.GetByIdAsync(trainingId);
            training.ViewCount++;
            base.Update(training, currentUserId);
        }
    }
}
