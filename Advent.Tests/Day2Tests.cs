using AdventDay2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Advent.Tests
{
    public class Day2Tests
    {
        [Fact]
        public void MinMaxDiffStrategy_ReturnsCorrectly()
        {
            var row = new[] { 10, 44, 3, 66 };
            var strategy = new MinMaxDiffCheckSumStrategy();

            var result = strategy.RowResult(strategy.FilterRow(row));

            Assert.Equal(66 - 3, result);
        }

        [Theory]
        [InlineData(new[] { 5, 9, 2, 8 }, 4)]
        [InlineData(new[] { 9, 4, 7, 3 }, 3)]
        [InlineData(new[] { 3, 8, 6, 5}, 2)]
        public void EvenDivideStrategy_ReturnsCorrectly(int[] row, int expected)
        {
            var strategy = new EvenDivideCheckSumStrategy();

            var result = strategy.RowResult(strategy.FilterRow(row));

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CheckSummer_CheckSum_ReturnsCorrectly_ForMinMaxStrategy()
        {
            var checkSummer = new CheckSummer(new MinMaxDiffCheckSumStrategy());

            var checkSum = checkSummer.CheckSum("day2testinput.txt");

            Assert.Equal(18, checkSum);
        }

        [Fact]
        public void CheckSummer_CheckSum_ReturnsCorrectly_ForEvenDivideStrategy()
        {
            var checkSummer = new CheckSummer(new EvenDivideCheckSumStrategy());

            var checkSum = checkSummer.CheckSum("day2testinput2.txt");

            Assert.Equal(9, checkSum);
        }
    }
}
