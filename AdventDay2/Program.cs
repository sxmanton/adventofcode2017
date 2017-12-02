using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay2
{
    class Program
    {
        static void Main(string[] args)
        {
            ICheckSummer checkSummer = new CheckSummer(new MinMaxDiffCheckSumStrategy());
            Console.WriteLine("Checksum {0}",checkSummer.CheckSum("input.txt"));

            ICheckSummer checkSummer2 = new CheckSummer(new EvenDivideCheckSumStrategy());
            Console.WriteLine("Checksum Even Divides: {0}", checkSummer2.CheckSum("input.txt"));

            Console.ReadLine();
        }
    }
}
