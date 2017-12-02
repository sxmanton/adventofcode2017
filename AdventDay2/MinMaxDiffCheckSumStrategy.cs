using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay2
{
    public class MinMaxDiffCheckSumStrategy : ICheckSumStrategy
    {
        public IEnumerable<int> FilterRow(IEnumerable<int> row)
        {
            return row;
        }

        public int RowResult(IEnumerable<int> row)
        {
            return row.Max() - row.Min();
        }
    }
}
