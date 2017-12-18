using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDay13;
using Xunit;

namespace Advent.Tests
{
    public class Day13Tests
    {
        [Fact]
        public void CalculateSeverity_ReturnsCorrectly()
        {
            var firewall = new FirewallSimulator("day13testinput.txt");

            var severity = firewall.CalculateSeverity(0);

            Assert.Equal(24, severity);
        }

        [Fact]
        public void MinimumDelay_ReturnsCorrectly()
        {
            var firewall = new FirewallSimulator("day13testinput.txt");

            var delay = firewall.SmallestDelayToPassThroughWithoutGettingCaught();

            Assert.Equal(10, delay);
        }
    }
}
