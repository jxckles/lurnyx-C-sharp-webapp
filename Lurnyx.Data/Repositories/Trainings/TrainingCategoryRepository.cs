using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Trainings;
using Lurnyx.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Lurnyx.Data.Repositories
{
    /// <summary>
    /// Repository for handling data operations for TrainingCategory entities.
    /// Inherits from the generic Repository<T> to get common CRUD functionality.
    /// </summary>
    public class TrainingCategoryRepository : Repository<TrainingCategory>, ITrainingCategoryRepository
    {
        public TrainingCategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Private helper method to create a base query with all necessary includes.
        /// This avoids repeating the Include statements.
        /// </summary>
        private IQueryable<TrainingCategory> GetQueryWithDetails()
        {
            return this.GetDbSet<TrainingCategory>()
                       .Where(t => t.DeletedAt == null)
                       .Include(tc => tc.Trainings!.Where(t => t.DeletedAt == null))
                            .ThenInclude(t => t.Topics!.Where(tp => tp.DeletedAt == null))
                       .AsNoTracking(); 
        }

        public async Task<PaginatedList<TrainingCategory>> GetPaginatedWithDetailsAsync(int pageNumber, int pageSize, string searchQuery)
        {
            var query = GetQueryWithDetails();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(t => t.Name.Contains(searchQuery));
            }

            query = query.OrderByDescending(tc => tc.UpdatedAt);

            return await PaginatedList<TrainingCategory>.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<TrainingCategory> GetByIdWithDetailsAsync(int id)
        {
            var category = await GetQueryWithDetails()
                           .FirstOrDefaultAsync(t => t.Id == id);
            
            return category ?? throw new KeyNotFoundException(Resources.Messages.Errors.TrainingCategoryDoesNotExist);
        }
    }
}
