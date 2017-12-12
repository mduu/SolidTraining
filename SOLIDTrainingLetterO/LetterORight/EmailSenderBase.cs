using System.Net.Mail;

namespace LetterORight
{
    internal abstract class EmailSenderBase
    {
        public void SendMail(string to, string subject, string body)
        {
            var mailMessage = BuildMailMessage(to, subject, body);
            SendMessage(mailMessage);
        }

        protected abstract void SendMessage(MailMessage mailMessage);

        private static MailMessage BuildMailMessage(string to, string subject, string body)
        {
            return new MailMessage("solid@isolutions.ch", to)
            {
                Body = body,
                Subject = subject
            };
        }
    }
}