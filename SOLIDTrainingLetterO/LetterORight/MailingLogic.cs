using System;
using System.Linq;

namespace LetterORight
{
    internal class MailingLogic
    {
        private readonly RegexEmailAddressValidator _regexEmailAddressValidator;
        private readonly EmailAddressReaderBase _emailAddressReader;
        private readonly EmailSenderBase _emailSender;

        public MailingLogic(RegexEmailAddressValidator regexEmailAddressValidator, EmailAddressReaderBase emailAddressReader, EmailSenderBase emailSender)
        {
            _regexEmailAddressValidator = regexEmailAddressValidator ?? throw new ArgumentNullException(nameof(regexEmailAddressValidator));
            _emailAddressReader = emailAddressReader ?? throw new ArgumentNullException(nameof(emailAddressReader));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
        }

        public void ProcessMailing()
        {
            var addresses = _emailAddressReader.ReadMailAddresses();

            foreach (var emailAddress in addresses.Where(a => _regexEmailAddressValidator.IsValid(a)))
            {
                var mailContent = GetMailContentFor(emailAddress);
                _emailSender.SendMail(emailAddress, mailContent.Subject, mailContent.Body);
            }
        }

        private MailContent GetMailContentFor(string recipient)
        {
            if (recipient.Contains("@example.com"))
            {
                return new MailContent
                {
                    Subject = "example: Hello SOLID",
                    Body = "Our guests from example are the most contacted people in the world!"
                };
            }
            if (recipient.Contains("@example1.com"))
            {
                return new MailContent
                {
                    Subject = "example1: Hello SOLID",
                    Body = "Our guests from example1 have some special text!"
                };
            }
            return new MailContent
            {
                Subject = "Default: Hello SOLID",
                Body = "This is the default content body for hello SOLID"
            };
        }

        private struct MailContent
        {
            public string Subject { get; set; }
            public string Body { get; set; }
        }
    }
}