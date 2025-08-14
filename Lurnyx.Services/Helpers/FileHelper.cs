using System.Text.RegularExpressions;

namespace Lurnyx.Services.Helpers
{
    public static class FileHelpers
    {
        /// <summary>
        /// Sanitizes the provided file name by replacing invalid characters and trimming whitespace.
        /// </summary>
        /// <param name="fileName">The original file name to be sanitized.</param>
        /// <returns>A sanitized version of the file name with invalid characters replaced by dashes
        /// and multiple whitespaces reduced to a single space.</returns>
        public static string SanitizeFileName(string fileName)
        {
            // Replace path and invalid chars with a single dash
            var sanitized = Regex.Replace(fileName, @"[^a-zA-Z0-9\s_.-]", "-");

            // Replace whitespaces with a single space character
            sanitized = Regex.Replace(sanitized.Trim(), @"\s+", " ");

            return sanitized;
        }
    }
}

