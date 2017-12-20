using System;
using System.Diagnostics;
using System.IO;

namespace AdventDay16
{
    class Program
    {
        static void Main(string[] args)
        {
            var original = "abcdefghijklmnop";

            string moves;
            using (var reader = new StreamReader("input.txt"))
            {
                moves = reader.ReadToEnd();
            }

            var danceProcessor = new DanceProcessor(original, moves);

            var result = danceProcessor.DoMoves(1);
            Console.WriteLine(result);

            var timer = new Stopwatch();

            timer.Start();
            var resultBillion = danceProcessor.DoMoves(1000000000);
            timer.Stop();
            Console.WriteLine(resultBillion);

            Console.WriteLine($"Part 2 took {timer.ElapsedMilliseconds} ms");

            Console.ReadLine();
        }
    }
}
