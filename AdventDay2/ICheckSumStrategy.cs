using System.Collections.Generic;

namespace AdventDay2
{
    public interface ICheckSumStrategy
    {
        IEnumerable<int> FilterRow(IEnumerable<int> inputRow);

        int RowResult(IEnumerable<int> filteredRow);
    }
}
