using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay10
{
    public static class ListExtensions
    {
        public static List<T> GetRangeCircular<T>(this List<T> list, int start, int count)
        {
            var subset = new List<T>();
            for (int i = 0; i < count; i++)
            {
                int index = (start + i) % list.Count;
                subset.Add(list[index]);
            }
            return subset;
        }

        public static void ReplaceRangeCircular<T>(this List<T> list, List<T> replacement, int start)
        {
            for (int i = 0; i < replacement.Count; i++)
            {
                int index = (start + i) % list.Count;
                list[index] = replacement[i];
            }
        }
    }
}
