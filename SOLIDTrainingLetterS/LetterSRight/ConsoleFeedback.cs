using System;
using System.Collections.Generic;
using System.Text;

namespace LetterSRight
{
    class ConsoleFeedback : IFeedback
    {
        public void Info(string message)
        {
            Console.WriteLine($"{DateTime.Now.ToShortTimeString()}: {message}");
        }
    }
}
