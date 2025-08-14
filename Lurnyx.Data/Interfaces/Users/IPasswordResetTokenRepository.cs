
namespace Lurnyx.Data.Interfaces.Users
{
    /// <summary>
    /// Defines the contract for the password reset token repository.
    /// </summary>
    public interface IPasswordResetTokenRepository : IRepository<PasswordResetToken>
    {
        /// <summary>
        /// Retrieves a password reset token by its token string.
        /// </summary>
        /// <param name="token">The token string.</param>
        /// <returns>The token entity if found and valid; otherwise, null.</returns>
        Task<PasswordResetToken?> GetByTokenAsync(string token);
    }
}
