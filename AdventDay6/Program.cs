using System;
using System.Collections.Generic;

namespace AdventDay6
{
    class Program
    {
        private static List<int> input = new List<int>
        {
            10,
            3,
            15,
            10,
            5,
            15,
            5,
            15,
            9,
            2,
            5,
            8,
            5,
            2,
            3,
            6
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Redistributions until loop entered: {0}",
                InfiniteLoopDetector.RedistributionsUntilLoopDetection(input, out int cycles));
            Console.WriteLine("Loop cycle length: {0}", cycles);
            Console.ReadLine();
        }
    }
}
