using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Trainings;
using Lurnyx.Data.Models;

namespace Lurnyx.Data.Repositories
{
    /// <summary>
    /// Repository for handling data operations for ResourceMaterial entities.
    /// Inherits all its functionality from the generic Repository<T>.
    /// </summary>
    public class ResourceMaterialRepository : Repository<ResourceMaterial>, IResourceMaterialRepository
    {
        public ResourceMaterialRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
