using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay10
{
    public static class ListGenerator
    {
        public static List<int> MakeValueEqualsIndexList(int count)
        {
            var list = new List<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            return list;
        }
    }
}
