using System.Collections.Generic;
using System.Linq;

namespace AdventDay10
{
    public static class AsciiConverter
    {
        public static List<int> ConvertString(string input)
        {
            return input.Select(c => (int)c).ToList();
        }
    }
}
