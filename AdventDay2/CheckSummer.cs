using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventDay2
{
    public class CheckSummer : ICheckSummer
    {
        private ICheckSumStrategy _filterStrategy;

        public CheckSummer(ICheckSumStrategy filterStrategy)
        {
            _filterStrategy = filterStrategy;
        }

        public int CheckSum(string filePath)
        {
            var sum = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var filteredRow = _filterStrategy.FilterRow(ParseRow(reader.ReadLine()));
                    var rowResult = _filterStrategy.RowResult(filteredRow);
                    sum += rowResult;
                }
            }
            return sum;
        }

        private IEnumerable<int> ParseRow(string row)
        {
            return row.Split('\t').Select(s => int.Parse(s));
        }
    }
}
