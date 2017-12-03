using System;
namespace AdventDay3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input square number: ");
            var input = Console.ReadLine();
            var squareNum = int.Parse(input);

            Console.WriteLine(
                "Distance to access point: {0}",
                SpiralGridCalculator.GetManhattanDistanceToSquareOne(squareNum));

            var generator = new AdjacentSumSpiralGridGenerator();

            var value = 0;
            while (value <= squareNum)
            {
                value = generator.GetNextValue();
            }

            Console.WriteLine("First value higher than {0}: {1}",squareNum,value);

            Console.ReadLine();
        }
    }
}
