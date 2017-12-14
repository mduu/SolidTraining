using System;

namespace LetterLRight
{
    public class Square : Figure
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public Square(int sideLength)
        {
            Console.WriteLine($"Creating {typeof(Square).FullName} with sideLength of {sideLength}");
            SideLength = sideLength;
        }

        public int SideLength { get; set; }

        public override int CalculateArea()
        {
            return SideLength * SideLength;
        }
    }
}