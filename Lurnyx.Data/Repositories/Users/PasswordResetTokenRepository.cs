using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace Lurnyx.Data.Repositories
{
    /// <summary>
    /// Repository for handling data operations for PasswordResetToken entities.
    /// </summary>
    public class PasswordResetTokenRepository : Repository<PasswordResetToken>, IPasswordResetTokenRepository
    {
        public PasswordResetTokenRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<PasswordResetToken?> GetByTokenAsync(string token)
        {
            return await this.GetDbSet<PasswordResetToken>()
                             .FirstOrDefaultAsync(t => t.Token == token && t.DeletedAt == null && t.ExpirationDate > DateTime.UtcNow);
        }
    }
}
