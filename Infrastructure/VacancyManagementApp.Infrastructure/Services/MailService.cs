using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.Helpers;


namespace VacancyManagementApp.Infrastructure.Services
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
                mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(_configuration["Mail:Username"], "Vacancy Management App", System.Text.Encoding.UTF8);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = _configuration["Mail:Host"];
            await smtp.SendMailAsync(mail);
        }

        public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
        {
            string resetUrl = $"https://vacancymanagementapp.com/reset-password?userId={userId}&token={resetToken.UrlEncode()}";

            StringBuilder mail = new();
            mail.AppendLine("Hello,<br><b>If you've requested a new password, please use the link below to reset it.<b><br>");
            mail.AppendLine($"<a href='{resetUrl}'>Reset Password</a>");

            await SendMailAsync(to, "Password Reset Request", mail.ToString());
        }


    }
}
