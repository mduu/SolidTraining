using System.Collections.Generic;

namespace LetterSRight
{
    public interface IEmailRepository
    {
        IEnumerable<string> ReadEmailAddresses();
    }
}