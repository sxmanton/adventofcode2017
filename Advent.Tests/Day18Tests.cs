using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDay18;
using Xunit;

namespace Advent.Tests
{
    public class Day18Tests
    {
        [Fact]
        public void DuetRunner_FirstRecoveredFrequency_Correct()
        {
            var duetRunner = new DuetRunner("day18testinput.txt");

            var actual = duetRunner.FirstRecoveredFrequency();

            Assert.Equal(4, actual);
        }
    }
}