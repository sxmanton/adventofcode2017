using System;
using System.Linq;

namespace AdventDay10
{
    class Program
    {
        private const string LENGTHS_STRING = "70,66,255,2,48,0,54,48,80,141,244,254,160,108,1,41";

        static void Main(string[] args)
        {
            var originalList = ListGenerator.MakeValueEqualsIndexList(256);

            var knotterPart1 = new ListKnotter<int>(originalList);
            var lengthsPart1 = LENGTHS_STRING.Split(',').Select(s => int.Parse(s)).ToList();
            var outputPart1 = knotterPart1.ApplyTwists(lengthsPart1, 1);

            var product = outputPart1[0] * outputPart1[1];

            Console.WriteLine("Product of first two values of twisted list for part 1: {0}", product);

            var outputPart2 = KnotHasher.Hash(LENGTHS_STRING);

            Console.WriteLine("Hashed value for part 2: {0}", outputPart2);

            Console.ReadLine();
        }
    }
}
