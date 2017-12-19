using System;

namespace LetterIRight
{
    public class RunnerDuck : IRunnerDuck
    {
        public void Run()
        {
            Console.WriteLine("running");
        }

        public void Swim()
        {
            Console.WriteLine("simming");
        }
    }
}