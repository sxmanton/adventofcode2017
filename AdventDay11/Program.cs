using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay11
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> directions;
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                directions = reader.ReadToEnd().Split(',');
            }

            var numSteps = new HexPathCalculator().GetNetStepsOfPath(directions, out int maxSteps);

            Console.WriteLine("Net steps of path: {0}", numSteps);
            Console.WriteLine("Max steps from origin during path: {0}", maxSteps);
            Console.ReadLine();
        }
    }
}
