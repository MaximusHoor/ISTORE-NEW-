using System;
using System.Collections.Generic;
using System.Text;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Business.Infrastructure;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Business.Service
{
   public class EmailSenderService :IEmailSender
    {
        private readonly SendGridSenderOptions _sendGridSenderOptions;
        private readonly SendGridClient _sendGridClient;
        public EmailSenderService(IOptions<SendGridSenderOptions> options)
        {
            _sendGridSenderOptions = options.Value;
            _sendGridClient = new SendGridClient(_sendGridSenderOptions.SendGridKey);
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return SendMailAsync(email, subject, message);
        }
        private async Task SendMailAsync(string email, string subject, string message)
        {
            var sendGridMessage = new SendGridMessage()
            {
                From = new EmailAddress(_sendGridSenderOptions.UserMail),
                Subject = subject,
                PlainTextContent = message
            };
            sendGridMessage.AddTo(email);
            await _sendGridClient.SendEmailAsync(sendGridMessage);
        }
    }
}
