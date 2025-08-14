namespace Lurnyx.Services.Interfaces.Users
{
    public interface IUserResourceDownloadService
    {
        /// <summary>
        /// Checks if the current user has already downloaded the given resource material.
        /// </summary>
        /// <param name="resourceMaterialId">The resource material ID.</param>
        /// <returns>true if the user has downloaded the resource material, false otherwise.</returns>
        Task<bool> IsDownloaded(int resourceMaterialId);
        
        /// <summary>
        /// Records a download event for the given resource material.
        /// </summary>
        /// <param name="resourceMaterialId">The resource material ID.</param>
        Task RecordDownloadAsync(int resourceMaterialId);
    }
}
