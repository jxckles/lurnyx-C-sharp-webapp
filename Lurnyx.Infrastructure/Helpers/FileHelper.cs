using Lurnyx.Resources.Messages;
using Microsoft.AspNetCore.Http;

namespace Lurnyx.Infrastructure.Helpers
{
    /// <summary>
    /// Provides static helper methods for file and URL manipulation.
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Validates a file against specified constraints for size, extension, and MIME type.
        /// </summary>
        /// <param name="file">The file to validate.</param>
        /// <param name="maxSize">The maximum allowed file size in bytes.</param>
        /// <param name="allowedExtensions">An array of allowed file extensions (e.g., ".jpg", ".pdf").</param>
        /// <param name="allowedMimeTypes">An array of allowed MIME types.</param>
        /// <param name="errorMessage">The base error message to use for validation failures.</param>
        public static void ValidateFile(IFormFile file, long maxSize, string[] allowedExtensions, string[] allowedMimeTypes, string errorMessage)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException(Errors.FileCannotBeEmpty);
            }

            if (file.Length > maxSize)
            {
                var maxSizeInMB = maxSize / (1024 * 1024);
                throw new ArgumentException(string.Format(Errors.FileExceedsSizeLimit, maxSizeInMB));
            }

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
            {
                throw new ArgumentException($"{errorMessage} {Errors.InvalidFileExtension}");
            }

            if (!allowedMimeTypes.Contains(file.ContentType.ToLowerInvariant()))
            {
                throw new ArgumentException($"{errorMessage} {Errors.InvalidMimeType}");
            }
        }

        /// <summary>
        /// Parses a Supabase public URL to extract the bucket name and the internal file path.
        /// </summary>
        /// <param name="url">The full public URL of the Supabase object.</param>
        /// <param name="validBucketNames">A list of valid bucket names to check against.</param>
        /// <returns>A tuple containing the bucket name and the file path.</returns>
        public static (string bucketName, string filePath) ParseSupabaseUrl(string url, string[] validBucketNames)
        {
            try
            {
                var uri = new Uri(url);
                // The path segment looks like: /storage/v1/object/public/{bucketName}/{filePath}
                var segments = uri.AbsolutePath.Split('/');

                var publicSegmentIndex = Array.IndexOf(segments, "public");
                if (publicSegmentIndex == -1 || publicSegmentIndex + 1 >= segments.Length)
                {
                    return (string.Empty, string.Empty);
                }

                var bucketName = segments[publicSegmentIndex + 1];
                var filePath = string.Join("/", segments.Skip(publicSegmentIndex + 2));

                if (validBucketNames.Contains(bucketName))
                {
                    return (bucketName, filePath);
                }
            }
            catch (UriFormatException)
            {
                return (string.Empty, string.Empty);
            }

            return (string.Empty, string.Empty);
        }
    }
}
