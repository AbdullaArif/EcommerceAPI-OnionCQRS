using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EcommerceAPI.Application.Features.Emails.Exceptions;
using EcommerceAPI.Application.Interfaces.Emails;
using Microsoft.Extensions.Options;

namespace EcommerceAPI.Infrastructure.Emails
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                using var client = new SmtpClient(_settings.SmtpServer)
                {
                    Port = _settings.SmtpPort,
                    Credentials = new NetworkCredential(_settings.SenderEmail, _settings.SenderPassword),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_settings.SenderEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);
                await client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new EmailSendFailedException("Email gönderilemedi!", ex);
            }
        }
    }
}
