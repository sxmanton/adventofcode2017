using System;

namespace AdventDay18
{
    class Program
    {
        static void Main(string[] args)
        {
            var virus = new VirusSimulator("input.txt");

            var infectionBursts = virus.InfectionBurstsAfterTotalBursts(10000);

            Console.WriteLine(infectionBursts);

            Console.ReadLine();
        }
    }
}
