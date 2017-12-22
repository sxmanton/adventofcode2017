using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay17
{
    public class Spinlock
    {
        private int _spin;
        public int CurrentPosition { get; private set; } = 0;
        public readonly List<int> Buffer = new List<int>();

        public Spinlock(int spin)
        {
            _spin = spin;
            Buffer.Add(0);
        }

        public void DoInsertions(int numInsertions)
        {
            var lastInsert = Buffer.Count;
            for (int i = 0 + lastInsert; i < numInsertions + lastInsert; i++)
            {
                CurrentPosition = ((CurrentPosition + _spin) % Buffer.Count) + 1;
                if (CurrentPosition >= Buffer.Count)
                {
                    Buffer.Add(i);
                }
                else
                {
                    Buffer.Insert(CurrentPosition, i);
                }
            }
        }

        public static int LastInsertAfterZero(int spin, int numInsertions)
        {
            var i = 1;
            var position = 0;
            var result = 1;
            while (i <= numInsertions)
            {
                position = ((position + spin) % i) + 1;
                if (position == 1)
                {
                    result = i;
                }
                i++;
            }

            return result;
        }
    }
}
