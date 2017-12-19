using System;
using System.Linq;

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
