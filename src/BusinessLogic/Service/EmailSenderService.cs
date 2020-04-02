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
using Domain.EF_Models;
using System.IO;

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
                PlainTextContent = message,              
            };
            sendGridMessage.AddTo(subject);
            await _sendGridClient.SendEmailAsync(sendGridMessage);
        }


        // 
        public async Task SendMailAsync(string subject, News news)
        {
            var list = new List<Attachment>();
            string base64String = "";

            using (System.Drawing.Image image = System.Drawing.Image.FromFile(news.PhotoPath))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    base64String = Convert.ToBase64String(imageBytes);
                }
            }

            list.Add(new Attachment() { Content = base64String });

            var sendGridMessage = new SendGridMessage()
            {
                From = new EmailAddress(_sendGridSenderOptions.UserMail),
                Subject = subject,
                PlainTextContent = news.Text,
            };
            sendGridMessage.AddTo(subject);
            await _sendGridClient.SendEmailAsync(sendGridMessage);
        }


    }
}
