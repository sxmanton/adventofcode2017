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

            var notADuet = new FakeDuetRunner("input.txt");

            Console.WriteLine(notADuet.FirstRecoveredFrequency());

            var duet = new DuetRunner("input.txt", 0, 1);

            duet.RunTillTerminated();

            Console.WriteLine(duet.Program1.SentCount);
            Console.WriteLine(duet.Program2.SentCount);
            Console.ReadLine();
        }
    }
}
