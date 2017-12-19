using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventDay10;

namespace AdventDay14
{
    public class DefragmenterGrid
    {
        public readonly List<string> RowHashes = new List<string>();
        public List<string> RowBinaries { get; }

        public DefragmenterGrid(string hashInput)
        {
            for (int i = 0; i < 128; i++)
            {
                string rowHashInput = $"{hashInput}-{i}";
                string rowHash = KnotHasher.Hash(rowHashInput);
                RowHashes.Add(rowHash);
            }

            RowBinaries = RowHashes.Select(HexStringToBinary).ToList();
        }
    }
}
