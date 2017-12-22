using System;

namespace AdventDay22
{
    class Program
    {
        static void Main(string[] args)
        {
            var virus = new VirusSimulator("input.txt", new SimpleVirusStrategy());

            var infectionBursts = virus.InfectionBurstsAfterTotalBursts(10000);

            Console.WriteLine(infectionBursts);

            var evolvedVirus = new VirusSimulator("input.txt", new EvolvedVirusStrategy());

            Console.WriteLine(evolvedVirus.InfectionBurstsAfterTotalBursts(10000000));

            Console.ReadLine();
        }
    }
}
