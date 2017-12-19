using System;
using System.Collections.Generic;
using System.IO;

namespace AdventDay5
{
    class Program
    {
        static void Main(string[] args)
        {
            var offsets = new List<int>();
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    if (int.TryParse(reader.ReadLine(), out int offset))
                    {
                        offsets.Add(offset);
                    }
                }
            }

            Console.WriteLine("Steps for Part 1: {0}",
                JumpMazeCalculator.StepsToEscape(offsets, i => i + 1));

            Console.WriteLine("Steps for Part 2: {0}",
                JumpMazeCalculator.StepsToEscape(offsets, JumpMazeCalculator.Part2OffsetChange));

            Console.ReadLine();
        }
    }
}
