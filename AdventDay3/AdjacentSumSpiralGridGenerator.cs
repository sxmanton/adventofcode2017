using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventDay3
{
    public class AdjacentSumSpiralGridGenerator
    {
        private List<SpiralGridPoint> _spiralGrid = new List<SpiralGridPoint>(); 

        public AdjacentSumSpiralGridGenerator()
        {
            _spiralGrid.Add(new SpiralGridPoint()
            {
                index = 0,
                x = 0,
                y = 0,
                value = 1
            });

            _spiralGrid.Add(new SpiralGridPoint()
            {
                index = 1,
                x = 1,
                y = 0,
                value = 1
            });
        }

        public int GetValueAt(int index)
        {
            while (_spiralGrid.Count < index + 1)
            {
                GetNextValue();
            }

            return _spiralGrid[index].value;
        }

        public int GetNextValue()
        {
            var coordinates = GetNextCoordinate();
            var nextPoint = new SpiralGridPoint()
            {
                index = _spiralGrid.Count,
                x = coordinates.Item1,
                y = coordinates.Item2
            };
            var adjacent = GetPriorAdjacentPoints(nextPoint);
            var sum = adjacent.Sum(p => p.value);
            nextPoint.value = sum;
            _spiralGrid.Add(nextPoint);

            return sum;
        }
        
        private IEnumerable<SpiralGridPoint> GetPriorAdjacentPoints(SpiralGridPoint point)
        {
            return _spiralGrid.Where(p => p.index < point.index
            && Math.Abs(point.x - p.x) <= 1
            && Math.Abs(point.y - p.y) <= 1);
        }

        private Tuple<int,int> GetNextCoordinate()
        {
            var lastPoint = _spiralGrid.Last();
            var layer = SpiralGridCalculator.GetLayer(lastPoint.index + 1);

            // Right edge
            if (lastPoint.x == layer)
            {
                // If top corner, go left
                if (lastPoint.y == layer)
                {
                    return new Tuple<int, int>(lastPoint.x - 1, lastPoint.y);
                }
                // Otherwise, if not bottom corner, right edge goes up
                if (lastPoint.y != -layer)
                {
                    return new Tuple<int, int>(lastPoint.x, lastPoint.y + 1);
                }
            }
            // Top edge
            if (lastPoint.y == layer)
            {
                // If left corner, go down
                if (lastPoint.x == -layer)
                {
                    return new Tuple<int, int>(lastPoint.x, lastPoint.y - 1);
                }
                // Otherwise top edge goes left
                return new Tuple<int, int>(lastPoint.x - 1, lastPoint.y);
            }
            // Left edge
            if (lastPoint.x == -layer)
            {
                // If bottom corner, go right
                if (lastPoint.y == -layer)
                {
                    return new Tuple<int, int>(lastPoint.x + 1, lastPoint.y);
                }
                // Otherwise, go down
                return new Tuple<int, int>(lastPoint.x, lastPoint.y - 1);
            }
            // Bottom edge always goes right
            if (lastPoint.y == -layer)
            {
                return new Tuple<int, int>(lastPoint.x + 1, lastPoint.y);
            }

            throw new Exception("Shouldn't be able to get here");
        }

        struct SpiralGridPoint
        {
            public int index;
            public int x;
            public int y;
            public int value;
        }
    }
}
