using System.Text.RegularExpressions;

namespace LetterSRight
{
    public class RegexEmailaddressValidator: IEmailaddressValidator
    {
        private static readonly Regex EmailRegex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]+$", RegexOptions.Compiled);

        public bool Validate(string emailaddressToValidate)
        {
            return EmailRegex.IsMatch(emailaddressToValidate);
        }
    }
}
