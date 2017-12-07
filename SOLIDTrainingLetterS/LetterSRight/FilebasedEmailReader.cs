using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LetterSRight
{
    public class FilebasedEmailReader : IEmailRepository
    {
        private readonly string _filename;

        public FilebasedEmailReader(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) { throw new ArgumentNullException(nameof(filename)); }

            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("Input file not found!", filename);
            }

            _filename = filename;
        }

        public IEnumerable<string> ReadEmailAddresses()
        {
            using (var reader = File.OpenText(_filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
