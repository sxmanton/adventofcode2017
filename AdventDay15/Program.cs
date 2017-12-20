using System;

namespace AdventDay15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Judge.ScoreGeneratedValues(new GeneratorA(289), new GeneratorB(629), 40000000));

            Console.WriteLine(Judge.ScoreGeneratedValues(new GeneratorAPart2(289), new GeneratorBPart2(629), 5000000));

            Console.ReadLine();            
        }
    }
}
