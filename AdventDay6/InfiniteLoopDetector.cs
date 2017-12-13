using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay6
{
    public static class InfiniteLoopDetector
    {
        public static int RedistributionsUntilLoopDetection(List<int> originalBank, out int loopCycles)
        {
            var redistributedBank = new List<int>(originalBank);
            var seenBanks = new List<List<int>>();

            int numRedistributions = 0;

            while (seenBanks.All(l => !l.SequenceEqual(redistributedBank)))
            {
                seenBanks.Add(new List<int>(redistributedBank));

                var maxValue = redistributedBank.Max();

                var maxIndex = redistributedBank.FindIndex(i => i == maxValue);

                redistributedBank[maxIndex] = 0;
                for (int i = 1; i <= maxValue; i++)
                {
                    var index = (maxIndex + i) % redistributedBank.Count;
                    redistributedBank[index]++;
                }

                numRedistributions++;
            }

            var loopStartIndex = seenBanks.IndexOf(seenBanks.First(l => l.SequenceEqual(redistributedBank)));
            loopCycles = numRedistributions - loopStartIndex;

            return numRedistributions;
        }
    }
}