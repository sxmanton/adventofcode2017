using AdventDay15;
using Xunit;

namespace Advent.Tests
{
    public class Day15Tests
    {
        [Fact]
        public void Generators_Work()
        {
            var genA = new GeneratorA(65);
            var genB = new GeneratorB(8921);

            Assert.Equal(1092455, genA.GetNextValue());
            Assert.Equal(430625591, genB.GetNextValue());
        }

        [Theory]
        [InlineData(1092455, 430625591, false)]
        [InlineData(1181022009, 123383848, false)]
        [InlineData(245556042, 1431495498, true)]
        [InlineData(1744312007, 137874439, false)]
        [InlineData(1352636452, 285222916, false)]
        public void CompareValues_Works(int valueA, int valueB, bool expected)
        {
            Assert.Equal(expected, Judge.CompareValues(valueA, valueB));
        }

        [Fact]
        public void IntegrationTest_Passes()
        {
            int count = 40000000;
            var genA = new GeneratorA(65);
            var genB = new GeneratorB(8921);

            var actual = Judge.ScoreGeneratedValues(genA, genB, count);

            var genAPart2 = new GeneratorAPart2(65);
            var genBPart2 = new GeneratorBPart2(8921);
            var countPart2 = 5000000;

            var actualPart2 = Judge.ScoreGeneratedValues(genAPart2, genBPart2, countPart2);

            Assert.Equal(588, actual);
            Assert.Equal(309, actualPart2);
        }
    }
}
