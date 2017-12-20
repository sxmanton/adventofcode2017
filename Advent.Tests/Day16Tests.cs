using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDay16;
using Xunit;

namespace Advent.Tests
{
    public class Day16Tests
    {
        [Fact]
        public void Spin_Works()
        {
            Assert.Equal("cdeab", DanceProcessor.Spin("abcde", 3));
        }

        [Fact]
        public void Exchange_Works()
        {
            Assert.Equal("eabdc", DanceProcessor.Exchange("eabcd", 3, 4));
        }

        [Fact]
        public void Partner_Works()
        {
            Assert.Equal("baedc", DanceProcessor.Partner("eabdc", 'e', 'b'));
        }

        [Fact]
        public void DoMoves_Works()
        {
            var dancePuppeteer = new DanceProcessor("abcde", "s1,x3/4,pe/b");
            Assert.Equal("baedc", dancePuppeteer.DoMoves(1));
            Assert.Equal("ceadb", dancePuppeteer.DoMoves(2));
        }
    }
}
