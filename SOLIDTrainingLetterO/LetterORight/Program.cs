using System;

namespace LetterORight
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            try
            {
                var regexEmailAddressValidator = new RegexEmailAddressValidator();
                var fileEmailAddressReader = new EmailAddressFileReader("MailListFile.txt");
                var smtpMailSender = new SmtpMailSender();

                var logic = new MailingLogic(regexEmailAddressValidator, fileEmailAddressReader, smtpMailSender);

                logic.ProcessMailing();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}