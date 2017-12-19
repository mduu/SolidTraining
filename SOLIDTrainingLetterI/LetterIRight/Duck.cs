using System;

namespace LetterIRight
{
    public class Duck : IDuck
    {
        public void Run()
        {
            Console.WriteLine("running");
        }

        public void Swim()
        {
            Console.WriteLine("swimming");
        }

        public void Fly()
        {
            Console.WriteLine("flying");
        }
    }
}