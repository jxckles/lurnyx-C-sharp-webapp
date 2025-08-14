using Lurnyx.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Lurnyx.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var smtpSettings = _configuration.GetSection("SmtpSettings");
            var server = smtpSettings["Server"] ?? throw new ArgumentNullException(nameof(smtpSettings), "SmtpSettings:Server is not configured.");
            var portString = smtpSettings["Port"] ?? throw new ArgumentNullException(nameof(smtpSettings), "SmtpSettings:Port is not configured.");
            var senderName = smtpSettings["SenderName"] ?? throw new ArgumentNullException(nameof(smtpSettings), "SmtpSettings:SenderName is not configured.");
            var senderEmail = smtpSettings["SenderEmail"] ?? throw new ArgumentNullException(nameof(smtpSettings), "SmtpSettings:SenderEmail is not configured.");
            var username = smtpSettings["Username"] ?? throw new ArgumentNullException(nameof(smtpSettings), "SmtpSettings:Username is not configured.");
            var password = smtpSettings["Password"] ?? throw new ArgumentNullException(nameof(smtpSettings), "SmtpSettings:Password is not configured.");

            if (!int.TryParse(portString, out var port))
            {
                throw new ArgumentException("SmtpSettings:Port must be a valid integer.", nameof(smtpSettings));
            }

            var client = new SmtpClient(server, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail, senderName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(toEmail);

            return client.SendMailAsync(mailMessage);
        }
    }
}
