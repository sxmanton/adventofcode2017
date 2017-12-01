using AdventDay1;
using Xunit;

namespace Advent.Tests
{
    public class Day1Tests
    {
        [Theory]
        [InlineData("1122", 3)]
        [InlineData("1111", 4)]
        [InlineData("1234", 0)]
        [InlineData("91212129", 9)]
        public void InverseCaptchaCalculator_SumRepeatedDigits_ReturnsCorrectSums(string captcha, int expectedSum)
        {
            var actualSum = InverseCaptchaCalculator.SumRepeatedDigits(captcha);

            Assert.Equal(expectedSum, actualSum);
        }

        [Theory]
        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123425", 4)]
        [InlineData("123123", 12)]
        [InlineData("12131415", 4)]
        public void InverseCaptchaCalculator_SumSameHalfwayAroundDigits_ReturnsCorrectSums(string captcha, int expectedSum)
        {
            var actualSum = InverseCaptchaCalculator.SumSameHalfwayAroundDigits(captcha);

            Assert.Equal(expectedSum, actualSum);
        }
    }
}
