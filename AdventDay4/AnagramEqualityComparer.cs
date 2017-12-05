using System.Collections.Generic;
using System.Linq;

namespace AdventDay4
{
    public class AnagramEqualityComparer : EqualityComparer<string>
    {
        public override bool Equals(string x, string y)
        {
            string xSorted = new string(x.OrderBy(c => c).ToArray());
            string ySorted = new string(x.OrderBy(c => c).ToArray());

            return xSorted == ySorted;
        }

        public override int GetHashCode(string obj)
        {
            // Sum the character codes
            return new string(obj.OrderBy(c => c).ToArray()).GetHashCode();
        }
    }
}
