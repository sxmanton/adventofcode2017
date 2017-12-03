using System;

namespace AdventDay3
{
    public static class SpiralGridCalculator
    {
        public static int GetManhattanDistanceToSquareOne(int squareNum)
        {
            var distanceToAxis = GetDistanceToNearestAxisSquare(squareNum);
            var layer = GetLayer(squareNum);
            return distanceToAxis + layer;
        }

        public static int GetDistanceToNearestAxisSquare(int squareNum)
        {
            var layer = GetLayer(squareNum);
            if (layer == 0) return 0;
            var numSquaresInLayer = layer * 8;
            var numSquaresPerEdge = numSquaresInLayer / 4;
            var maxDistanceToAxis = numSquaresPerEdge / 2;
            var endOfLastLayer = (int)Math.Pow(NearestOddSqrtRoundedDown(squareNum),2);
            var firstAxisSquare = endOfLastLayer + maxDistanceToAxis;
            var distanceToFirstAxisSquare = Math.Abs(squareNum - firstAxisSquare);
            var positionInEdge = distanceToFirstAxisSquare % numSquaresPerEdge;
            if (positionInEdge > maxDistanceToAxis)
            {
                return positionInEdge % maxDistanceToAxis;
            }
            return positionInEdge;
        }

        public static int GetLayer(int squareNum)
        {
            var nearestOddSqrt = NearestOddSqrtRoundedDown(squareNum);
            if (Math.Sqrt(squareNum) == nearestOddSqrt)
            {
                return (nearestOddSqrt - 1) / 2;
            }
            return (nearestOddSqrt + 1) / 2;
        }

        public static int NearestOddSqrtRoundedDown(int squareNum)
        {
            int nearestSqrt = (int)Math.Floor(Math.Sqrt(squareNum));
            if (nearestSqrt % 2 == 0)
            {
                return nearestSqrt - 1;
            }
            return nearestSqrt;
        }
    }
}
