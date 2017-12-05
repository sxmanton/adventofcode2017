using Xunit;
using AdventDay4;
using System.Collections.Generic;

namespace Advent.Tests
{
    public class Day4Tests
    {
        [Theory]
        [InlineData("aa bb cc dd ee", true)]
        [InlineData("aa bb cc dd aa", false)]
        [InlineData("aa bb cc dd aaa", true)]
        public void PassPhraseValidator_IsValid_ReturnsCorrectly_ForDefaultEquality(string input, bool expected)
        {
            var actual = PassPhraseValidator.IsValid(input, EqualityComparer<string>.Default);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("abcde fghij",true)]
        [InlineData("abcde xyz ecdab",false)]
        [InlineData("a ab abc abd abf abj",true)]
        [InlineData("iiii oiii ooii oooi oooo",true)]
        [InlineData("oiii ioii iioi iiio",false)]
        [InlineData("kdd itdyhe pvljizn cgi",true)]
        public void PassPhraseValidator_IsValid_ReturnsCorrectly_ForAnagram(string input, bool expected)
        {
            var actual = PassPhraseValidator.IsValid(input, new AnagramEqualityComparer());

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("asdf","fdsa")]
        [InlineData("qwertyuio","ouiyrtewq")]
        public void AnagramEqualityComparer_GetHashCode_SameForAnagrams(string word, string anagram)
        {
            var comparer = new AnagramEqualityComparer();
            var hash1 = comparer.GetHashCode(word);
            var hash2 = comparer.GetHashCode(anagram);

            Assert.Equal(hash1, hash2);
        }
    }
}
