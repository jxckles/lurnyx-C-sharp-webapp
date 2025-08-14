using Lurnyx.Data.Interfaces;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Data.Models
{
    public partial class User : SoftDeletableEntity, IEntity
    {   
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public UserRole Role { get; set; }
    }
}