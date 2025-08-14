using Microsoft.AspNetCore.Http;

namespace Lurnyx.Services.Interfaces
{
    /// <summary>
    /// Provides an interface for file storage operations.
    /// </summary>
    public interface IFileStorageService
    {
        /// <summary>
        /// Uploads an image to the configured image storage bucket within a specified folder.
        /// </summary>
        /// <param name="file">The image file to upload.</param>
        /// <param name="folder">The base folder path for the file (e.g., "training-category-images").</param>
        /// <returns>The public URL of the uploaded image.</returns>
        Task<string> UploadImageAsync(IFormFile file, string folder);

        /// <summary>
        /// Uploads a single file to the configured file storage bucket within a specified folder.
        /// </summary>
        /// <param name="file">The file to upload.</param>
        /// <param name="folder">The base folder path for the file (e.g., "resource-materials").</param>
        /// <returns>The public URL of the uploaded file.</returns>
        Task<string> UploadFileAsync(IFormFile file, string folder);

        /// <summary>
        /// Deletes an image from storage based on its public URL.
        /// </summary>
        /// <param name="imageUrl">The public URL of the image to delete.</param>
        Task DeleteImageAsync(string imageUrl);

        /// <summary>
        /// Deletes a file from storage based on its public URL.
        /// </summary>
        /// <param name="fileUrl">The public URL of the file to delete.</param>
        Task DeleteFileAsync(string fileUrl);
    }
}
