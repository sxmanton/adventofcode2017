using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AdventDay8;

namespace Advent.Tests
{
    public class Day8Tests
    {
        [Theory]
        [InlineData("a < -1", false)]
        [InlineData("b == 0", true)]
        [InlineData("a > 1", false)]
        [InlineData("c != 10", true)]
        [InlineData("d <= 0", true)]
        [InlineData("f >= 0", true)]
        public void EvaluteCondition_ReturnsCorrectly(string condition, bool expected)
        {
            var runner = new InstructionRunner();

            var actual = runner.ConditionIsTrue(condition);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ApplyInstructions_ReturnsCorrectly()
        {
            var runner = new InstructionRunner();

            runner.ApplyInstructions("day8testinput.txt");

            var registers = runner.Registers;

            Assert.Equal(1, registers["a"]);
            Assert.Equal(0, registers["b"]);
            Assert.Equal(-10, registers["c"]);
        }

        [Fact]
        public void HighestValueEver_ReturnsCorrectly_AfterApplyInstructions()
        {
            var runner = new InstructionRunner();

            runner.ApplyInstructions("day8testinput.txt");

            Assert.Equal(10, runner.HighestValueEver);
        }
    }
}
