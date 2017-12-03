using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventDay2
{
    public class EvenDivideCheckSumStrategy : ICheckSumStrategy
    {
        public IEnumerable<int> FilterRow(IEnumerable<int> inputRow)
        {
            int[] row = inputRow.ToArray();
            for (int i = 0; i < row.Count(); i++)
            {
                for (int j = 0; j < row.Count(); j++)
                {
                    if (row[i] > row[j] && row[i] % row[j] == 0)
                    {
                        return new[] { row[i], row[j] };
                    }
                }
            }
            throw new ArgumentException("Row did not contain evenly divisible pair");
        }

        public int RowResult(IEnumerable<int> inputRow)
        {
            var row = inputRow.ToArray();
            return row[0] / row[1];
        }
    }
}
