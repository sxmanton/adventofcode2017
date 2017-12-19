using System.Collections.Generic;
using AdventDay10;
using Xunit;

namespace Advent.Tests
{
    public class Day10Tests
    {
        [Fact]
        public void ListKnotter_AppliesTwistsCorrectly()
        {
            var original = ListGenerator.MakeValueEqualsIndexList(5);
            var lengths = new List<int> { 3, 4, 1, 5 };

            var knotter = new ListKnotter<int>(original);
            var output = knotter.ApplyTwists(lengths, 1);

            var expected = new List<int> { 3, 4, 2, 1, 0 };

            Assert.Equal(expected, output);
        }

        [Fact]
        public void AsciiConverter_Works()
        {
            string input = "1,2,3";

            var expected = new List<int> { 49, 44, 50, 44, 51 };

            var actual = AsciiConverter.ConvertString(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", "a2582a3a0e66e6e86e3812dcb672a272")]
        [InlineData("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
        [InlineData("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
        [InlineData("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
        public void KnotHasher_Works(string input, string expected)
        {
            var output = KnotHasher.Hash(input);

            Assert.Equal(expected, output);
        }
    }
}
