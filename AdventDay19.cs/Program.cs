using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay19
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new MazeRunner("input.txt");

            var result = runner.GetMazeLetterOrder();

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
