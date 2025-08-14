using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Trainings;
using Lurnyx.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Lurnyx.Data.Repositories
{
    /// <summary>
    /// Repository for handling data operations for TrainingRating entities.
    /// Inherits from the generic Repository<T> to get common CRUD functionality.
    /// </summary>
    public class TrainingRatingRepository : Repository<TrainingRating>, ITrainingRatingRepository
    {
        public TrainingRatingRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Private helper method to create a base query with all necessary includes.
        /// </summary>
        private IQueryable<TrainingRating> GetQueryWithDetails()
        {
            return this.GetDbSet<TrainingRating>()
                        .Where(tr => tr.DeletedAt == null)
                        .Include(tr => tr.Training)
                            .ThenInclude(tr => tr!.TrainingCategory)
                        .Include(tr => tr.CreatedByUser)
                        .Include(tr => tr.UpdatedByUser)
                        .AsNoTracking(); 
        }

        public async Task<PaginatedList<TrainingRating>> GetPaginatedAndFilteredWithDetailsAsync(int pageNumber, int pageSize, string searchQuery, string ratingFilter, string categoryFilter, int currentUserId)
        {
            var query = GetQueryWithDetails();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(tr => tr.Training!.Title.Contains(searchQuery));
            }

            if (!string.IsNullOrEmpty(ratingFilter) && int.TryParse(ratingFilter, out var minRating))
            {
                query = query.Where(tr => tr.Rating >= minRating);
            }

            if (!string.IsNullOrEmpty(categoryFilter))
            {
                query = query.Where(tr => tr.Training!.TrainingCategory != null && tr.Training.TrainingCategory.Name == categoryFilter);
            }

            if (currentUserId > 0)
            {
                query = query.Where(tr => tr.CreatedBy == currentUserId);
            }

            query = query.OrderByDescending(tr => tr.UpdatedAt);

            return await PaginatedList<TrainingRating>.CreateAsync(query, pageNumber, pageSize);
        }
        
        public async Task<TrainingRating> GetByIdWithDetailsAsync(int id)
        {
            var trainingRating = await GetQueryWithDetails()
                                            .FirstOrDefaultAsync(tr => tr.Id == id);
            return trainingRating ?? throw new InvalidOperationException(Resources.Messages.Errors.RatingDoesNotExist);
        }
        
        public async Task<TrainingRating?> FindByUserAndTrainingAsync(int userId, int trainingId)
        {
            return await this.GetDbSet<TrainingRating>()
                                .FirstOrDefaultAsync(tr => tr.CreatedBy == userId && tr.TrainingId == trainingId && tr.DeletedAt == null);
        }
        
        public async Task<List<TrainingRating>> GetAllByTrainingIdAsync(int trainingId)
        {
            return await this.GetDbSet<TrainingRating>()
                                .Where(r => r.TrainingId == trainingId && r.DeletedAt == null)
                                .ToListAsync();
        }
        
        public async Task<List<TrainingRating>> GetRatingsByUserIdAsync(int userId)
        {
            return await this.GetDbSet<TrainingRating>()
                                .Where(r => r.CreatedBy == userId && r.DeletedAt == null)
                                .AsNoTracking()
                                .ToListAsync();
        }
        
        public async Task<double> GetAverageRatingByUserIdAsync(int userId)
        {
            var ratings = await this.GetDbSet<TrainingRating>()
                                    .Where(r => r.CreatedBy == userId && r.DeletedAt == null)
                                    .AsNoTracking()
                                    .ToListAsync();

            if (!ratings.Any())
            {
                return 0.0;
            }

            return ratings.Average(r => r.Rating);
        }
    }
}