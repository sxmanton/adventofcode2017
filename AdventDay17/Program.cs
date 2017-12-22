using System;
using System.Linq;

namespace AdventDay17
{
    class Program
    {
        static void Main(string[] args)
        {
            var spinner = new Spinlock(376);

            spinner.DoInsertions(2017);

            Console.WriteLine(
                spinner.Buffer.GetRange(spinner.CurrentPosition - 1, 3)
                .Aggregate("", (last, i) => last += i.ToString() + ", "));
            

            Console.WriteLine(Spinlock.LastInsertAfterZero(376, 50000000));

            Console.ReadLine();
        }
    }
}
