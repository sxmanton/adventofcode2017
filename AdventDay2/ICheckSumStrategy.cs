using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay2
{
    public interface ICheckSumStrategy
    {
        IEnumerable<int> FilterRow(IEnumerable<int> inputRow);

        int RowResult(IEnumerable<int> filteredRow);
    }
}
