using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDay10;
using AdventDay14;
using Xunit;

namespace Advent.Tests
{
    public class Day14Tests
    {
        [Theory]
        [InlineData('0',"0000")]
        [InlineData('1',"0001")]
        [InlineData('e',"1110")]
        [InlineData('f',"1111")]
        public void HexCharToBinary_ReturnsCorrectly(char hexChar, string expected)
        {
            var actual = HexToBinaryConverter.HexCharToBinary(hexChar);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HexStringToBinary_RetunrsCorrectly()
        { 
            var actual = HexToBinaryConverter.HexStringToBinary("a0c2017");

            var expected = "1010000011000010000000010111";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NumUsedSquares_ReturnsCorrectly()
        {
            var grid = new DefragmenterGrid("flqrgnkx");

            var actual = grid.NumUsedSquares;

            Assert.Equal(8108, actual);
        }

        [Fact]
        public void NumRegions_Correct()
        {
            var grid = new DefragmenterGrid("flqrgnkx");

            var actual = grid.NumRegions;

            Assert.Equal(1242, actual);
        }
    }
}
