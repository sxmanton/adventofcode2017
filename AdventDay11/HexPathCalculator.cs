using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay11
{
    public class HexPathCalculator
    {
        private static Vector3 _north = new Vector3(0, 1, 1);
        private static Vector3 _northeast = new Vector3(1, 0, 1);
        private static Vector3 _southeast = new Vector3(1, -1, 0);

        private Vector3 _coordinates = Vector3.Zero;

        public int GetNetStepsOfPath(IEnumerable<string> directions, out int maxStepsFromOrigin)
        {
            maxStepsFromOrigin = 0;
            int stepsFromOrigin = 0;
            foreach (string direction in directions)
            {
                ApplyStep(direction);
                stepsFromOrigin = GetStepsFromOrigin();

                if (stepsFromOrigin > maxStepsFromOrigin)
                {
                    maxStepsFromOrigin = stepsFromOrigin;
                }
            }

            return stepsFromOrigin;
        }

        private int GetStepsFromOrigin()
        {
            var absValue = Vector3.Abs(_coordinates);
            var steps = (absValue.X + absValue.Y + absValue.Z) / 2;
            return Convert.ToInt32(steps);
        }

        private void ApplyStep(string direction)
        {
            switch (direction.ToUpper())
            {
                case "N":
                    _coordinates += _north;
                    break;
                case "S":
                    _coordinates -= _north;
                    break;
                case "NE":
                    _coordinates += _northeast;
                    break;
                case "SW":
                    _coordinates -= _northeast;
                    break;
                case "SE":
                    _coordinates += _southeast;
                    break;
                case "NW":
                    _coordinates -= _southeast;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(direction, "Direction not valid");
            }
        }

    }
}
