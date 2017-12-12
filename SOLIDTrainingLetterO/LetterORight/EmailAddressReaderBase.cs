using System.Collections.Generic;

namespace LetterORight
{
    internal abstract class EmailAddressReaderBase
    {
        public abstract IEnumerable<string> ReadMailAddresses();
    }
}