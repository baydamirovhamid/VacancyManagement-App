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

        public async Task SendCvSubmissionConfirmationEmailAsync(string to, string fileName)
        {
            string subject = "CV Submission Confirmation";
            string body = $@"
            <p>Hello,</p>
            <p>We have successfully received your CV file</p>
            <p>Thank you for your application.</p>
            <p>Best regards,<br>Vacancy Management Team</p>";

            await SendMailAsync(to, subject, body, isBodyHtml: true);
        }
    }

}
