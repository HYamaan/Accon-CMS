using System.Text;
using AcconAPI.Application.Features.Commands.ContactPage.ContactPageMail;
using AcconAPI.Application.Models;
using AcconAPI.Application.Repository;
using AcconAPI.Application.Services;
using AcconAPI.Domain.Entities.Settings;
using AcconAPI.Domain.Settings;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace AcconAPI.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private MailSettings _mailSettings { get; }
        private readonly IGenericRepository<Domain.Entities.Settings.EmailSettings> _emailSettings;

        public MailService(IOptions<MailSettings> mailSettings, IGenericRepository<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings;
            _mailSettings = mailSettings.Value;
        }


        private async Task SendMailAsync(MailRequest mailRequest)
        {
            try
            {
                var mailInformation = await _emailSettings.GetAll().FirstOrDefaultAsync();
                if (mailInformation == null)
                {
                    throw new Exception("Mail settings not found");
                }

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(mailInformation.FromEmail));
                email.To.Add(MailboxAddress.Parse(mailInformation.ToEmail));
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(mailInformation.SmtpHost, mailInformation.SmtpPort, SecureSocketOptions.SslOnConnect);
                smtp.Authenticate(mailInformation.SmtpUser, mailInformation.SmtpPassword);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SendPasswordResetMailAsync(ContactPageMailCommandRequest request)
        {
            StringBuilder mailBody = new StringBuilder();

            mailBody.AppendLine("<!DOCTYPE html>");
            mailBody.AppendLine("<html lang='en'>");
            mailBody.AppendLine("<head>");
            mailBody.AppendLine("<meta charset='UTF-8'>");
            mailBody.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1.0'>");
            mailBody.AppendLine("<style>");
            mailBody.AppendLine("body { font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px; }");
            mailBody.AppendLine(
                ".container { background-color: #ffffff; padding: 20px; border-radius: 10px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); }");
            mailBody.AppendLine("h2 { color: #333333; }");
            mailBody.AppendLine("p { color: #666666; }");
            mailBody.AppendLine("</style>");
            mailBody.AppendLine("</head>");
            mailBody.AppendLine("<body>");
            mailBody.AppendLine("<div class='container'>");
            mailBody.AppendLine("<h2>İletişim Formu</h2>");
            mailBody.AppendLine("<p><strong>İsim:</strong> " + request.Name + "</p>");
            mailBody.AppendLine("<p><strong>E-posta:</strong> " + request.Email + "</p>");
            mailBody.AppendLine("<p><strong>Telefon:</strong> " + request.Phone + "</p>");
            mailBody.AppendLine("<p><strong>Mesaj:</strong></p>");
            mailBody.AppendLine("<p>" + request.Message + "</p>");
            mailBody.AppendLine("</div>");
            mailBody.AppendLine("</body>");
            mailBody.AppendLine("</html>");

            var emailRequest = new MailRequest()
            {
                Body = mailBody.ToString(),
                From = request.Email,
                Subject = "İletişim Mesajı",
            };

            await SendMailAsync(emailRequest);
        }
    }
}