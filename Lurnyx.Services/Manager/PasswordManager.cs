using Microsoft.Extensions.Configuration;

namespace Lurnyx.Services.Manager
{
    /// <summary>
    /// Manages password hashing and verification using BCrypt.
    /// </summary>
    public static class PasswordManager
    {
        private static int _workFactor = 12;

        /// <summary>
        /// Configures the PasswordManager with settings from IConfiguration.
        /// </summary>
        /// <param name="configSection">The configuration section containing security settings.</param>
        public static void SetUp(IConfigurationSection configSection)
        {
            // Read the work factor from config, otherwise use the default.
            _workFactor = configSection.GetValue<int?>("BcryptWorkFactor") ?? _workFactor;
        }

        /// <summary>
        /// Hashes a password with a randomly generated salt and a configured work factor.
        /// </summary>
        /// <param name="password">The plaintext password to hash.</param>
        /// <returns>The salted password hash.</returns>
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, _workFactor);
        }

        /// <summary>
        /// Verifies that a plaintext password matches a stored hash.
        /// </summary>
        /// <param name="password">The plaintext password to verify.</param>
        /// <param name="storedHash">The hash stored in the database.</param>
        /// <returns>True if the password matches the hash, otherwise false.</returns>
        public static bool VerifyPassword(string password, string storedHash)
        {
            // BCrypt.Verify automatically extracts the salt from the storedHash and compares.
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }
}