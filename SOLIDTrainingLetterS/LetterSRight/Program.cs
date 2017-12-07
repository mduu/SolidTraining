using System;

namespace LetterSRight
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            try
            {

                IFeedback feedback = new ConsoleFeedback();
                IEmailRepository repository = new FilebasedEmailReader("MailListFile.txt");
                IEmailaddressValidator validator = new RegexEmailaddressValidator();
                IEmailSender sender = new SmtpMailSender(feedback);
                ISpamEngine engine = new SpamEngine(feedback, repository, validator, sender);

                engine.Process();
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