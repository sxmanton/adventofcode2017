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
        public void FakeDuetRunner_FirstRecoveredFrequency_Correct()
        {
            var duetRunner = new FakeDuetRunner("day18testinput.txt");

            var actual = duetRunner.FirstRecoveredFrequency();

            Assert.Equal(4, actual);
        }
        
        [Fact]
        public void ActualDuetRunner_Works()
        {
            var duetRunner = new DuetRunner("day18testinputpart2.txt", 0, 1);

            duetRunner.RunTillTerminated();

            Assert.Equal(3, duetRunner.Program1.SentCount);
        }

    }
}