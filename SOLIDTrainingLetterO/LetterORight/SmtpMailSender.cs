using System;
using System.Net;
using System.Net.Mail;

namespace LetterORight
{
    internal class SmtpMailSender : EmailSenderBase
    {
        protected override void SendMessage(MailMessage mailMessage)
        {
            Console.WriteLine();
            Console.WriteLine($"Sending message from:{mailMessage.From}, to:{mailMessage.To}, subject:{mailMessage.Subject}, body:{mailMessage.Body}");

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