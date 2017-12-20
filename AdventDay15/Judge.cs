using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay15
{
    public static class Judge
    {
        public static int ScoreGeneratedValues(Generator genA, Generator genB, int numValues)
        {
            var score = 0;
            for (int i = 0; i < numValues; i++)
            {
                if (CompareValues(genA.GetNextValue(), genB.GetNextValue()))
                {
                    score++;
                }
            }

            return score;
        }

        public static bool CompareValues(long valueA, long valueB)
        {
            var xor = valueA ^ valueB;
            if (xor == 0)
            {
                return true;
            }
            var xorString = Convert.ToString(xor, 2).PadLeft(32, '0');
            return xorString.Substring(16).Trim('0') == string.Empty;
        }
    }
}
