using System.Collections.Generic;
using System.Linq;
using AdventDay6;
using Xunit;

namespace Advent.Tests
{
    public class Day6Tests
    {
        [Fact]
        public void LoopDetection_RetrunsCorrect()
        {
            var banks = new List<int>
            {
                0,
                2,
                7,
                0
            };

            var numRedistributions = InfiniteLoopDetector.RedistributionsUntilLoopDetection(banks, out int loopCycles);

            Assert.Equal(5, numRedistributions);
            Assert.Equal(4, loopCycles);
        }

        [Fact]
        public void CheckingMyUnderstanding_OfListEquality()
        {
            var banks = new List<int>
            {
                0,
                2,
                7,
                0
            };

            var banks2 = new List<int>
            {
                0,
                2,
                7,
                0
            };

            var listlist = new List<List<int>> {banks};

            Assert.DoesNotContain(listlist, l => l == banks2);
            Assert.Contains(listlist, l => l.SequenceEqual(banks2));
        }
    }
}
