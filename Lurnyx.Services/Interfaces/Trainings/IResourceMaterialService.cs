using Lurnyx.Services.ServiceModels;

namespace Lurnyx.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for the Resource Material service layer.
    /// </summary>
    public interface IResourceMaterialService
    {
        /// <summary>
        /// Adds multiple new resource materials to a topic, including uploading all associated files.
        /// </summary>
        /// <param name="models">A list of view models, each containing resource material data and a file.</param>
        Task AddMultipleResourceMaterialsAsync(List<ResourceMaterialDto> models);

        /// <summary>
        /// Adds multiple new resource materials to a topic from a list of URLs.
        /// </summary>
        /// <param name="topicId">The ID of the parent topic these resources will belong to.</param>
        /// <param name="resources">A list of input models, each containing a URL and its associated metadata.</param>
        Task AddMultipleResourceUrlsAsync(int topicId, List<ResourceMaterialDto> resources);

        /// <summary>
        /// Deletes multiple resource materials, including their associated files from storage.
        /// </summary>
        /// <param name="ids">A list of IDs of the resource materials to delete.</param>
        Task DeleteMultipleResourceMaterialsAsync(List<int> ids);
    }
}
