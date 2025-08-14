using Lurnyx.Infrastructure.Helpers;
using Lurnyx.Resources.Messages;
using Lurnyx.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Lurnyx.Infrastructure.Services
{
    public class SupabaseStorageService : IFileStorageService
    {
        private readonly string _supabaseUrl;
        private readonly string _supabaseKey;
        private readonly string _imageBucketName;
        private readonly string _fileBucketName;

        // Image validation constants
        private const int MaxImageSize = 2 * 1024 * 1024; // 2MB
        private static readonly string[] AllowedImageExtensions = { ".png", ".jpg", ".jpeg", ".webp" };
        private static readonly string[] AllowedImageMimeTypes = { "image/png", "image/jpeg", "image/webp" };

        // File validation constants
        private const int MaxFileSize = 10 * 1024 * 1024; // 10MB
        private static readonly string[] AllowedFileExtensions = { ".png", ".jpg", ".jpeg", ".webp", ".pdf", ".pptx", ".mp4" };
        private static readonly string[] AllowedFileMimeTypes = { "image/png", "image/jpeg", "image/webp", "application/pdf", "application/vnd.openxmlformats-officedocument.presentationml.presentation", "video/mp4" };

        public SupabaseStorageService(IConfiguration configuration)
        {
            _supabaseUrl = configuration["Supabase:Url"] ?? throw new ArgumentNullException(nameof(configuration), "Supabase URL cannot be null.");
            _supabaseKey = configuration["Supabase:ApiKey"] ?? throw new ArgumentNullException(nameof(configuration), "Supabase API Key cannot be null.");
            _imageBucketName = configuration["Supabase:ImageBucketName"] ?? throw new ArgumentNullException(nameof(configuration), "Supabase ImageBucketName cannot be null.");
            _fileBucketName = configuration["Supabase:FileBucketName"] ?? throw new ArgumentNullException(nameof(configuration), "Supabase FileBucketName cannot be null.");
        }


        #region Helpers
        /// <summary>
        /// Uploads the specified file to the specified bucket within the Supabase storage using the specified folder path.
        /// </summary>
        /// <param name="file">The file to upload.</param>
        /// <param name="bucketName">The bucket name to upload to.</param>
        /// <param name="folder">The folder path within the bucket to upload to.</param>
        /// <returns>The public URL of the uploaded file.</returns>
        /// <exception cref="ArgumentException">Thrown if the file is invalid or exceeds size limits.</exception>
        /// <exception cref="Exception">Thrown if the upload fails or the public URL cannot be retrieved.</exception>
        private async Task<string> UploadAsync(IFormFile file, string bucketName, string folder)
        {
            var client = new Supabase.Client(_supabaseUrl, _supabaseKey);
            await client.InitializeAsync();

            var storage = client.Storage;
            var bucket = storage.From(bucketName);

            var now = DateTime.UtcNow;
            var yearMonth = now.ToString("yyyy-MM");
            var day = now.ToString("dd");
            var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            var supabasePath = Path.Combine(folder, yearMonth, day, randomFileName).Replace('\\', '/');

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                var response = await bucket.Upload(memoryStream.ToArray(), supabasePath, new Supabase.Storage.FileOptions { CacheControl = "3600", Upsert = false, ContentType = file.ContentType });

                if (response == null || !response.Contains(supabasePath))
                {
                    throw new Exception(Errors.FileUploadFailed);
                }
            }

            var publicUrl = bucket.GetPublicUrl(supabasePath);

            if (string.IsNullOrEmpty(publicUrl))
            {
                throw new Exception(Errors.FailedToGetPublicUrl);
            }

            return publicUrl;
        }

        #endregion

        #region Upload
        /// <summary>
        /// Uploads an image file to the specified folder within the Supabase storage bucket.
        /// </summary>
        /// <param name="file">The image file to upload.</param>
        /// <param name="folder">The folder path within the bucket where the image will be stored.</param>
        /// <returns>The public URL of the uploaded image.</returns>
        /// <exception cref="ArgumentException">Thrown if the file is invalid or exceeds size limits.</exception>
        /// <exception cref="Exception">Thrown if the upload fails or the public URL cannot be retrieved.</exception>
        public async Task<string> UploadImageAsync(IFormFile file, string folder)
        {
            FileHelper.ValidateFile(file, MaxImageSize, AllowedImageExtensions, AllowedImageMimeTypes, Errors.InvalidImage);

            return await UploadAsync(file, _imageBucketName, folder);
        }

        /// <summary>
        /// Uploads a file to the specified folder within the Supabase storage bucket.
        /// </summary>
        /// <param name="file">The file to upload.</param>
        /// <param name="folder">The folder path within the bucket where the file will be stored.</param>
        /// <returns>The public URL of the uploaded file.</returns>
        /// <exception cref="ArgumentException">Thrown if the file is invalid or exceeds size limits.</exception>
        /// <exception cref="Exception">Thrown if the upload fails or the public URL cannot be retrieved.</exception>
        public async Task<string> UploadFileAsync(IFormFile file, string folder)
        {
            FileHelper.ValidateFile(file, MaxFileSize, AllowedFileExtensions, AllowedFileMimeTypes, Errors.InvalidFile);

            return await UploadAsync(file, _fileBucketName, folder);
        }

        #endregion

        #region Delete
        /// <summary>
        /// Deletes an image from Supabase storage using its public URL.
        /// </summary>
        /// <param name="imageUrl">The public URL of the image to delete.</param>
        public async Task DeleteImageAsync(string imageUrl)
        {
            await DeleteFileAsync(imageUrl);
        }

        /// <summary>
        /// Deletes a file from Supabase storage using its public URL.
        /// </summary>
        /// <param name="fileUrl">The public URL of the file to be deleted.</param>
        /// <remarks>
        /// If the URL is invalid or parsing fails, the method logs a message and returns without performing any deletion.
        /// </remarks>
        /// <exception cref="Exception">Thrown if the Supabase client initialization or deletion process encounters an error.</exception>
        public async Task DeleteFileAsync(string fileUrl)
        {
            if (string.IsNullOrEmpty(fileUrl))
            {
                return;
            }

            var (bucketName, filePath) = FileHelper.ParseSupabaseUrl(fileUrl, new[] { _imageBucketName, _fileBucketName });

            if (string.IsNullOrEmpty(bucketName) || string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine($"Could not parse Supabase bucket and path from URL: {fileUrl}");
                return;
            }

            var client = new Supabase.Client(_supabaseUrl, _supabaseKey);
            await client.InitializeAsync();

            var bucket = client.Storage.From(bucketName);
            await bucket.Remove(new List<string> { filePath });
        }

        #endregion
    }
}
