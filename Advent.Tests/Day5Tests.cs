using System.Collections.Generic;
using AdventDay5;
using Xunit;

namespace Advent.Tests
{
    public class Day5Tests
    {
        private List<int> _offsets = new List<int>
        {
            0,
            3,
            0,
            1,
            -3
        };

        [Fact]
        public void JumpMazeCalculator_ReturnsCorrectNumberOfSteps_ForPart1()
        {
            var stepsToExit = JumpMazeCalculator.StepsToEscape(_offsets, i => i + 1);

            Assert.Equal(5, stepsToExit);
        }

        [Fact]
        public void JumpMazeCalculator_ReturnsCorrectNumberOfSteps_ForPart2()
        {
            var stepsToExit = JumpMazeCalculator.StepsToEscape(_offsets, JumpMazeCalculator.Part2OffsetChange);

            Assert.Equal(10, stepsToExit);
        }
    }
}
