using System;

namespace LetterLRight
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("1 = Rectangle, 2 = Square");

            var userDecision = Console.ReadLine();
            var figure = userDecision == "1" ? new Rectangle(10, 10) as Figure : new Square(10);
            ValidateLiskov(figure, 100);

            switch (figure)
            {
                case Rectangle rect:
                    rect.Width = 20;
                    ValidateLiskov(figure, 200);
                    break;
                case Square square:
                    square.SideLength = 20;
                    ValidateLiskov(figure, 400);
                    break;
            }


            Console.ReadLine();
        }

        private static void ValidateLiskov(Figure figure, int expectedArea)
        {
            var area = figure.CalculateArea();
            Console.WriteLine($"Area is {area} - expected {expectedArea}");
            var foregroundColor = Console.ForegroundColor;
            try
            {
                if (area != expectedArea)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Liskov violated because Height should not have been modified.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Liskov principal handled correctly.");
                }
            }
            finally
            {
                Console.ForegroundColor = foregroundColor;
            }
        }
    }
}