using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AdventDay4
{
    class Program
    {
        static void Main(string[] args)
        {

            int part1ValidCount = 0;
            int part2ValidCount = 0;

            using (var streamReader = new StreamReader("input.txt"))
            {
                while (!streamReader.EndOfStream)
                {
                    var passphrase = streamReader.ReadLine();
                    if (PassPhraseValidator.IsValid(passphrase, EqualityComparer<string>.Default))
                    {
                        part1ValidCount++;
                    }
                    if (PassPhraseValidator.IsValid(passphrase, new AnagramEqualityComparer()))
                    {
                        part2ValidCount++;
                    }
                    else
                    {
                        Debug.WriteLine("Failed Part 2: {0}", passphrase);
                    }
                }
            }

            Console.WriteLine(part1ValidCount);
            Console.WriteLine(part2ValidCount);
            Console.ReadLine();
        }
    }
}
