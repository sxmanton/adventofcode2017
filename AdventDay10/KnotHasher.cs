using System.Collections.Generic;
using System.Linq;

namespace AdventDay10
{
    public static class KnotHasher
    {
        private static int[] APPENDED_LENGTH_SEQUENCE = new[] { 17, 31, 73, 47, 23 };

        public static string Hash(string input)
        {
            var lengths = AsciiConverter.ConvertString(input);
            lengths.AddRange(APPENDED_LENGTH_SEQUENCE);

            var listToKnot = ListGenerator.MakeValueEqualsIndexList(256);

            var knotter = new ListKnotter<int>(listToKnot);
            var sparseHash = knotter.ApplyTwists(lengths, 64);

            var denseHash = new List<int>();

            for (int i = 0; i < 16; i++)
            {
                var range = sparseHash.GetRange(i * 16, 16);
                var denseValue = range.Aggregate((x, y) => x ^ y);
                denseHash.Add(denseValue);
            }

            var hash = denseHash.Aggregate("", (agg, next) => agg + next.ToString("X2"));
            return hash.ToLower();
        }
    }
}
