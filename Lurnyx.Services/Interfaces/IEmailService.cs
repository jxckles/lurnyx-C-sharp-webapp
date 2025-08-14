namespace Lurnyx.Services.Interfaces
{
    public interface IEmailService
    {
        /// <summary>
        /// Sends an email asynchronously.
        /// </summary>
        /// <param name="toEmail">The recipient's email address.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="message">The email body.</param>
        /// <returns>A task that completes when the email is sent.</returns>
        Task SendEmailAsync(string toEmail, string subject, string message);
    }
}