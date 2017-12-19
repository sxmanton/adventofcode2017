using System;

namespace AdventDay14
{
    class Program
    {
        static void Main(string[] args)
        {
            var testGrid = new DefragmenterGrid("flqrgnkx");

            Console.WriteLine("First 8x8 of grid for flqrgnkx:");

            testGrid.PrintGridPreview(8, 8);

            Console.WriteLine();

            var challengeGrid = new DefragmenterGrid("xlqgujun");

            Console.WriteLine($"Number of used square in grid for hash xlqgujun: {challengeGrid.NumUsedSquares}");

            Console.WriteLine($"Number of regions: {challengeGrid.NumRegions}");

            Console.ReadLine();

        }
    }
}
