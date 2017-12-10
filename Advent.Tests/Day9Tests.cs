using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AdventDay9;

namespace Advent.Tests
{
    public class Day9Tests
    {
        [Theory]
        [InlineData("{}", 1)]
        [InlineData("{{{}}}", 3)]
        [InlineData("{{},{}}", 3)]
        [InlineData("{{{},{},{{}}}}", 6)]
        [InlineData("{<{},{},{{}}>}", 1)]
        [InlineData("{<a>,<a>,<a>,<a>}", 1)]
        [InlineData("{{<a>},{<a>},{<a>},{<a>}}", 5)]
        [InlineData("{{<!>},{<!>},{<!>},{<a>}}", 2)]
        public void GroupParser_CountsGroupsCorrectly(string input, int expectedNumGroups)
        {
            var parser = new GroupParser();

            parser.Parse(input);

            Assert.Equal(expectedNumGroups, parser.NumGroups);
        }

        [Theory]
        [InlineData("{}", 1)]
        [InlineData("{{{}}}", 6)]
        [InlineData("{{},{}}", 5)]
        [InlineData("{{{},{},{{}}}}", 16)]
        [InlineData("{<a>,<a>,<a>,<a>}", 1)]
        [InlineData("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [InlineData("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [InlineData("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void GroupParser_Calculates_CorrectScore(string input, int expectedScore)
        {
            var parser = new GroupParser();

            parser.Parse(input);

            Assert.Equal(expectedScore, parser.Score);
        }

        [Theory]
        [InlineData("<>", 0)]
        [InlineData("<random characters>", 17)]
        [InlineData("<<<<>", 3)]
        [InlineData("<{!>}>", 2)]
        [InlineData("<!!>", 0)]
        [InlineData("<!!!>>", 0)]
        [InlineData("<{o\"i!a,<{i<a>", 10)]
        public void GroupParser_Calculates_CorrectNonCancelledGarbabeCharacterCount(string input, int expected)
        {
            var parser = new GroupParser();

            parser.Parse(input);

            Assert.Equal(expected, parser.NonCancelledGarbageCharacterCount);
        }
    }
}
