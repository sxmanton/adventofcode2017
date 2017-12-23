using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDay19;
using Xunit;

namespace Advent.Tests
{
    public class Day19Tests
    {
        [Fact]
        public void MazeRunner_Works()
        {
            var runner = new MazeRunner("day19testinput.txt");

            var actual = runner.GetMazeLetterOrder(out int numSteps);

            Assert.Equal("ABCDEF", actual);
            Assert.Equal(38, numSteps);
        }
    }
}
