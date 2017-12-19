using System;

namespace LetterIRight
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var duck = new Duck();
            DoRun(duck);
            DoSwim(duck);
            DoFly(duck);

            var runnerDuck = new RunnerDuck();
            DoRun(runnerDuck);
            DoSwim(runnerDuck);
            //DoFly(runnerDuck); ==> compiler-error

            Console.ReadLine();
        }

        private static void DoRun(IRunnable duck)
        {
            duck.Run();
        }

        private static void DoSwim(ISwimmable duck)
        {
            duck.Swim();
        }

        private static void DoFly(IFlyingable flyingDuck)
        {
            flyingDuck.Fly();
        }
    }
}