using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace LetterSRight
{
    class SmtpMailSender: IEmailSender
    {
        private readonly IFeedback _feedback;

        public SmtpMailSender(IFeedback feedback)
        {
            _feedback = feedback ?? throw new ArgumentNullException(nameof(feedback));
        }

        public void SendMailTo(string recipientAddress)
        {
            string body;
            string subject;
            if (recipientAddress.Contains("@example.com"))
            {
                subject = "example: Hello SOLID";
                body = "Our guests from example are the most contacted people in the world!";
            }
            else if (recipientAddress.Contains("@example1.com"))
            {
                subject = "example1: Hello SOLID";
                body = "Our guests from example1 have some special text!";
            }
            else
            {
                subject = "Default: Hello SOLID";
                body = "This is the default content body for hello SOLID";
            }

            var mailMessage = new MailMessage("solid@isolutions.ch", recipientAddress)
            {
                Body = body,
                Subject = subject
            };

            _feedback.Info("");
            _feedback.Info($"Sending message from:{mailMessage.From}, to:{mailMessage.To}, subject:{mailMessage.Subject}, body:{mailMessage.Body}");

            // Access: https://mailtrap.io/
            // UName: christoph.koenig@isolutions.ch
            // PW: 123456
            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("2e5239bd361ded", "c92461365296ff"),
                EnableSsl = true
            };

            client.Send(mailMessage);

        }
    }
}
