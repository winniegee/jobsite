using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace JobPlatform.Messaging
{
    public class EmailService
    {
        private readonly SendGridMessage _msg;
        private readonly SendGridClient client;
        public EmailService(string apiKey, string senderEmail="info@jobcreate.com", string senderName="Job Create")
        {
            _msg = new SendGridMessage { From = new EmailAddress(senderEmail, senderName) };
            _msg.From = new EmailAddress(senderEmail, senderName);
            client = new SendGridClient(apiKey);
        }
        public void  SendMail(EmailMessage message, Boolean isHtml)
        {
            _msg.AddTo(message.Recipient);

            _msg.Subject = message.Subject;
            if (!isHtml)
            {
                _msg.PlainTextContent = message.Body;
            }
            else
            {
                _msg.HtmlContent = message.Body;
            }
         client.SendEmailAsync(_msg);


        }
    }
}