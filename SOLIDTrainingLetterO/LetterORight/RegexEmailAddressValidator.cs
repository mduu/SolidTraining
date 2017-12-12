using System.Text.RegularExpressions;

namespace LetterORight
{
    class RegexEmailAddressValidator : EmailAddressValidatorBase
    {
        private readonly Regex _regex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]+$");

        public override bool IsValid(string emailAddress)
        {
            return _regex.IsMatch(emailAddress);
        }
    }
}