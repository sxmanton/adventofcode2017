using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }
        //, high-bit first: 0 becomes 0000, 1 becomes 0001, e becomes 1110, f becomes 1111, and so on; a hash that begins
    }
}
