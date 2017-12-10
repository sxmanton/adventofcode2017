using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay9
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                input = reader.ReadToEnd();
            }

            var parser = new GroupParser();

            parser.Parse(input);

            Console.WriteLine("Score: {0}", parser.Score);
            Console.WriteLine("Number of non-cancelled garbage characters: {0}", parser.NonCancelledGarbageCharacterCount);
            Console.ReadLine();
        }
    }
}
