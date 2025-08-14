using System.ComponentModel.DataAnnotations;

namespace Lurnyx.WebApp.Models
{
    /// <summary>
    /// View model for the Forgot Password page.
    /// </summary>
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
