using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay18
{
    class Program
    {
        static void Main(string[] args)
        {

            var duetRunner = new DuetRunner("input.txt");

            Console.WriteLine(duetRunner.FirstRecoveredFrequency());

            Console.ReadLine();
        }
    }
}
