using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDay22;
using Xunit;

namespace Advent.Tests
{
    public class Day22Tests
    {
        [Fact]
        public void VirusSimulator_SimpleStrategy_Works()
        {
            var virus = new VirusSimulator("day22testinput.txt", new SimpleVirusStrategy());

            var actual = virus.InfectionBurstsAfterTotalBursts(10000);

            Assert.Equal(5587, actual);
        }

        [Theory]
        [InlineData(100, 26)]
        [InlineData(10000000, 2511944, Skip = "Long running")]
        public void EvolvedVirusStrategy_Works(int totalBursts, int expectedInfectionBursts)
        {
            var virus = new VirusSimulator("day22testinput.txt", new EvolvedVirusStrategy());

            var actual = virus.InfectionBurstsAfterTotalBursts(totalBursts);
            Assert.Equal(expectedInfectionBursts, actual);
        }
    }
}
