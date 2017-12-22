using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDay18;
using Xunit;

namespace Advent.Tests
{
    public class Day18Tests
    {
        [Fact]
        public void VirusSimulatorWorks()
        {
            var virus = new VirusSimulator("day18testinput.txt");

            var actual = virus.InfectionBurstsAfterTotalBursts(10000);

            Assert.Equal(5587, actual);
        }
    }
}
