using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay12
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = ProgramParser.ParseFile("input.txt");
            var connectedToZero = collection.GetConnectedPrograms(0);

            Console.WriteLine("Number of programs connected to program 0 (including itself): {0}",
                connectedToZero.Count);

            Console.WriteLine("Total number of groups: {0}", collection.GetNumberOfGroups());

            Console.ReadLine();
        }
    }
}
