using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Trainings;
using Lurnyx.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Lurnyx.Data.Repositories
{
    /// <summary>
    /// Repository for handling data operations for Topic entities.
    /// Inherits from the generic Repository<T> to get common CRUD functionality.
    /// </summary>
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        public TopicRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Private helper method to create a base query with all necessary includes.
        /// This avoids repeating the Include statements and improves performance with AsNoTracking.
        /// </summary>
        private IQueryable<Topic> GetQueryWithDetails()
        {
            return this.GetDbSet<Topic>()
                       .Where(t => t.DeletedAt == null)
                       .Include(t => t.Training)
                            .ThenInclude(tr => tr!.TrainingCategory)
                       .Include(t => t.ResourceMaterials!.Where(rm => rm.DeletedAt == null))
                       .Include(t => t.CreatedByUser)
                       .Include(t => t.UpdatedByUser)
                       .AsNoTracking();
        }
        
        public async Task<PaginatedList<Topic>> GetPaginatedWithDetailsAsync(int pageNumber, int pageSize, string? searchQuery, int? trainingCategoryId, int? trainingId)
        {
            var query = GetQueryWithDetails();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(t => t.Title.Contains(searchQuery));
            }

            if (trainingCategoryId.HasValue)
            {
                query = query.Where(t => t.Training!.TrainingCategoryId == trainingCategoryId.Value);
            }

            if (trainingId.HasValue)
            {
                query = query.Where(t => t.TrainingId == trainingId.Value);
            }

            query = query.OrderByDescending(tp => tp.UpdatedAt);

            return await PaginatedList<Topic>.CreateAsync(query, pageNumber, pageSize);
        }
        
        public async Task<Topic> GetByIdWithDetailsAsync(int id)
        {
            var topic = await GetQueryWithDetails()
                       .FirstOrDefaultAsync(t => t.Id == id);

            return topic ?? throw new KeyNotFoundException(Resources.Messages.Errors.TopicDoesNotExist);
        }
        
        public async Task IncrementViewCountAsync(int topicId, int currentUserId)
        {
            var topic = await base.GetByIdAsync(topicId);
            topic.ViewCount++;
            base.Update(topic, currentUserId);
        }
    }
}
