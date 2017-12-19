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

            RowBinaries = RowHashes.Select(HexToBinaryConverter.HexStringToBinary).ToList();
        }

        public void PrintGridPreview(int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(BinaryToGridPreview(RowBinaries[i].Substring(0, columns)));
            }
        }

        public int NumUsedSquares => GetNumUsedSquares();

        public int NumRegions => GetNumRegions();

        private int GetNumUsedSquares()
        {
            return RowBinaries.Aggregate(0, (sum, row) => sum += row.Count(c => c == '1'));
        }

        private int GetNumRegions()
        {
            List<OccupiedGridSquare> usedSquares = new List<OccupiedGridSquare>();
            for (int i = 0; i < RowBinaries.Count; i++)
            {
                var row = RowBinaries[i];

                for (int j = 0; j < row.Length; j++)
                {
                    if (row[j] == '1')
                    {
                        usedSquares.Add(new OccupiedGridSquare
                        {
                            Row = i,
                            Column = j
                        });
                    }
                }
            }

            var lastGroup = 1;

            foreach (OccupiedGridSquare square in usedSquares)
            {
                if (square.Group == 0)
                {
                    square.Group = lastGroup;
                    ApplyGroupingToAdjacents(square, usedSquares);
                    lastGroup++;
                }
            }

            return usedSquares.Select(sq => sq.Group).Distinct().Count();
        }

        private void ApplyGroupingToAdjacents(OccupiedGridSquare square, IEnumerable<OccupiedGridSquare> usedSquares)
        {
            var adjacents = usedSquares.Where(other => other.Group == 0 && square.IsAdjacentTo(other))
                .ToList();
            adjacents.ForEach(sq => sq.Group = square.Group);
            adjacents.ForEach(sq => ApplyGroupingToAdjacents(sq, usedSquares));
        }

        private string BinaryToGridPreview(string binary)
        {
            return String.Join(string.Empty, binary.Select(BinaryToGridPreview));
        }

        private char BinaryToGridPreview(char c)
        {
            if (c == '0')
            {
                return '.';
            }
            if (c == '1')
            {
                return '#';
            }
            throw new ArgumentException("Encountered non-binary character", c.ToString());
        }

        private class OccupiedGridSquare
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public int Group { get; set; } = 0;

            public bool IsAdjacentTo(OccupiedGridSquare square)
            {
                var rowDistance = Math.Abs(square.Row - Row);
                if (rowDistance > 1) return false;

                var columnDistance = Math.Abs(square.Column - Column);
                if (columnDistance > 1) return false;

                return rowDistance + columnDistance == 1;
            }
        }
    }
}
