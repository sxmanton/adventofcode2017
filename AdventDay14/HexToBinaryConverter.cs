using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay14
{
    public static class HexToBinaryConverter
    {
        public static string HexStringToBinary(string hex)
        {
            return String.Join(string.Empty, hex.Select(HexCharToBinary));
        }

        public static string HexCharToBinary(char hexChar)
        {
            return Convert.ToInt32(hexChar.ToString(), 16).ToString();
        }
    }
}
