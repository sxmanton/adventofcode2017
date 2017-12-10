using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay8
{
    class Program
    {
        static void Main(string[] args)
        {
            IInstructionRunner runner = new InstructionRunner();
            runner.ApplyInstructions("input.txt");

            Console.WriteLine("Max value in a register after running instructions: {0}",
                runner.Registers.Values.Max());

            Console.WriteLine("Highest value ever: {0}", runner.HighestValueEver);

            Console.ReadLine();

        }
    }
}
