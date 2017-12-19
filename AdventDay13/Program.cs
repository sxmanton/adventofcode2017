using System;
using System.Diagnostics;

namespace AdventDay13
{
    class Program
    {
        static void Main(string[] args)
        {
            var firewall = new FirewallSimulator("input.txt");

            var severity = firewall.CalculateSeverity(0);
            
            Console.WriteLine($"Severity when passing through with no delay: {severity}");

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var minimumDelay = firewall.SmallestDelayToPassThroughWithoutGettingCaught();

            stopwatch.Stop();

            Console.WriteLine($"Minimum delay in picoseconds to avoid getting caught: {minimumDelay}");

            Console.WriteLine($"Minimum delay calcualted in {stopwatch.ElapsedMilliseconds} ms");

            Console.ReadLine();
        }
    }
}
