using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LetterORight
{
    internal class EmailAddressFileReader: EmailAddressReaderBase
    {
        private readonly string _filePath;

        public EmailAddressFileReader(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public override IEnumerable<string> ReadMailAddresses()
        {
            return File.Exists(_filePath)
                ? File.ReadLines(_filePath).Where(line => !string.IsNullOrWhiteSpace(line))
                : Enumerable.Empty<string>();
        }
    }
}