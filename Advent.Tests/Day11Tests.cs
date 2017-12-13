using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AdventDay11;

namespace Advent.Tests
{
    public class Day11Tests
    {
        

        [Theory]
        [ClassData(typeof(Day11TestData))]
        public void HexPathCalculator_GetNetDistanceOfPath_ReturnsCorrectly(string[] input, int expectedDistance)
        {
            var actual = new HexPathCalculator().GetNetStepsOfPath(input, out int maxSteps);

            Assert.Equal(expectedDistance, actual);
        }
    }

    public class Day11TestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new[] { "ne", "ne", "ne" }, 3 },
            new object[] { new[] { "ne", "ne", "sw", "sw" }, 0 },
            new object[] { new[] { "ne", "ne", "s", "s" }, 2 },
            new object[] { new[] {"se", "sw", "se", "sw", "sw"}, 3 }
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
}
