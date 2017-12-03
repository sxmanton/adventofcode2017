using AdventDay3;
using Xunit;

namespace Advent.Tests
{
    public class Day3Tests
    {
        [Theory]
        [InlineData(1,0)]
        [InlineData(2,1)]
        [InlineData(9,1)]
        [InlineData(10,2)]
        [InlineData(25,2)]
        public void SpiralGridCalculator_GetLayer_ReturnsCorrectly(int squareNum, int expectedLayer)
        {
            var actual = SpiralGridCalculator.GetLayer(squareNum);

            Assert.Equal(expectedLayer, actual);
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(3,1)]
        [InlineData(6,1)]
        [InlineData(10,3)]
        public void NearestOddSqrtRoundedDown_ReturnsCorrectly(int input, int expected)
        {
            var actual = SpiralGridCalculator.NearestOddSqrtRoundedDown(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1,0)]
        [InlineData(4,0)]
        [InlineData(7,1)]
        [InlineData(10,1)]
        [InlineData(13,2)]
        [InlineData(15,0)]
        public void DistanceToNearestAxisSquare_ReturnsCorrectly(int input, int expected)
        {
            var actual = SpiralGridCalculator.GetDistanceToNearestAxisSquare(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1,0)]
        [InlineData(12,3)]
        [InlineData(23,2)]
        [InlineData(1024,31)]
        public void ManhattanDistanceToSquareOne(int squareNum, int expectedDistance)
        {
            var actual = SpiralGridCalculator.GetManhattanDistanceToSquareOne(squareNum);

            Assert.Equal(expectedDistance, actual);
        }

        [Theory]
        [InlineData(0,1)]
        [InlineData(1,1)]
        [InlineData(2,2)]
        [InlineData(3,4)]
        [InlineData(4,5)]
        [InlineData(5,10)]
        [InlineData(6,11)]
        [InlineData(7,23)]
        [InlineData(8,25)]
        [InlineData(9,26)]
        [InlineData(10,54)]
        public void AdjacentSumSpiralGridGenerator_GeneratesCorrectValues(int index, int expectedValue)
        {
            var generator = new AdjacentSumSpiralGridGenerator();
            var actual = generator.GetValueAt(index);

            Assert.Equal(expectedValue, actual);
        }
    }
}
