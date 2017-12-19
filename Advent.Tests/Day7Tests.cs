using System.Collections.Generic;
using System.Linq;
using AdventDay7;
using Xunit;

namespace Advent.Tests
{
    public class Day7Tests
    {

        private List<ProgramModel> _programs = ProgramListParser.GetProgramModelsFromFile("day7testinput.txt");

        [Theory]
        [InlineData("ugml (68) -> gyxo, ebii, jptl", "ugml", 68, new[] { "gyxo", "ebii", "jptl" })]
        [InlineData("jptl (61)", "jptl", 61, new string[] { })]
        public void ParseLine_Regex_ReturnsCorrectly(
            string line,
            string expectedName,
            int expectedWeight,
            string[] expectedChildrenNames)
        {
            var program = ProgramListParser.ParseLine(line);

            Assert.Equal(expectedName, program.Name);
            Assert.Equal(expectedWeight, program.Weight);
            Assert.Equal(expectedChildrenNames, program.ChildrenNames.ToArray());

        }

        [Fact]
        public void FindBottomMost_ReturnsCorrectly()
        {
            var bottom = Program.FindBottomMost(_programs);

            Assert.Equal("tknk", bottom.Name);
        }

        [Fact]
        public void WeightIncludingAllChildren_ReturnsCorrectly()
        {
            var ugml = _programs.First(p => p.Name == "ugml");
            var padx = _programs.First(p => p.Name == "padx");
            var fwft = _programs.First(p => p.Name == "fwft");
            var gyxo = _programs.First(p => p.Name == "gyxo");

            Assert.Equal(251, ugml.WeightIncludingAllChildren);
            Assert.Equal(243, padx.WeightIncludingAllChildren);
            Assert.Equal(243, fwft.WeightIncludingAllChildren);
            Assert.Equal(61, gyxo.WeightIncludingAllChildren);
        }

        [Fact]
        public void FindTopmostUnbalancedProgram_ReturnsCorrectly()
        {
            var topmostUnbalanced = Program.FindTopmostUnbalancedProgram(_programs);

            Assert.Equal("ugml", topmostUnbalanced.Name);
        }

        [Fact]
        public void GetNecessaryWeightToBalance_ReturnsCorrectly()
        {
            var topmostUnbalanced = Program.FindTopmostUnbalancedProgram(_programs);

            var desiredWeight = Program.GetNecessaryWeightToBalance(topmostUnbalanced);

            Assert.Equal(60, desiredWeight);
        }
    }
}
