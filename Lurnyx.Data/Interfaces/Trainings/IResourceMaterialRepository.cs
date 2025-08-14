using Lurnyx.Data.Models;

namespace Lurnyx.Data.Interfaces.Trainings
{
    /// <summary>
    /// Defines the contract for the resource material repository.
    /// All functionality is inherited from the generic IRepository<T>.
    /// This interface exists for dependency injection purposes.
    /// </summary>
    public interface IResourceMaterialRepository : IRepository<ResourceMaterial>
    {
    }
}
