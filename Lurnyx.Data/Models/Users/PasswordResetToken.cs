using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Models;

public class PasswordResetToken : SoftDeletableEntity, IEntity
{
    public int Id { get; set; }
    public string UserEmail { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
}   