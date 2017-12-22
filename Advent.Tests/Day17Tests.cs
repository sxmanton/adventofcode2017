using AdventDay17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Advent.Tests
{
    public class Day17Tests
    {
        [Fact]
        public void Spinlock_Works()
        {
            var spinner = new Spinlock(3);

            spinner.DoInsertions(2017);

            Assert.Equal(638, spinner.Buffer[spinner.CurrentPosition + 1]);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(24)]
        [InlineData(7)]
        [InlineData(13)]
        [InlineData(386)]
        public void Spinlock_Zero_StaysAtStart(int spin)
        {
            var spinner = new Spinlock(spin);
            for (int i = 0; i < 50000; i++)
            {
                spinner.DoInsertions(1);
                Assert.Equal(0, spinner.Buffer[0]);
            }
        }
    }
}
