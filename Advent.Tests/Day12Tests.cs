using AdventDay12;
using Xunit;

namespace Advent.Tests
{
    public class Day12Tests
    {
        [Fact]
        public void ProgramCollection_GetConnectedPrograms_ReturnsCorrectly()
        {
            var programCollection = ProgramParser.ParseFile("day12testinput.txt");

            var connected = programCollection.GetConnectedPrograms(0);

            Assert.Equal(6, connected.Count);
        }

        [Fact]
        public void ProgramCollection_GetNumberOfGroups_ReturnsCorrectly()
        {
            var programCollection = ProgramParser.ParseFile("day12testinput.txt");

            var numGroups = programCollection.GetNumberOfGroups();

            Assert.Equal(2, numGroups);
        }
    }
}
