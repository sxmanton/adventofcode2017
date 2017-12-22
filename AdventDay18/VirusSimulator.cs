using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay18
{
    public class VirusSimulator
    {
        private List<Tuple<int, int>> _infectedGridPoints;

        private int _virusX = 0;
        private int _virusY = 0;
        private enum Direction
        {
            Up = 0,
            Left = 1,
            Down = 2,
            Right = 3
        }
        private Direction _direction = Direction.Up;
        private int _infectionBursts = 0;

        public VirusSimulator(string gridFile)
        {
            var lines = new List<string>();
            using (var reader = new StreamReader(gridFile))
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }

            var gridHeight = lines.Count;
            var gridWidth = lines.First().Length;

            _infectedGridPoints = lines.SelectMany((s, i) => ParseRowForInfected(s, (gridHeight / 2) - i, gridWidth)).ToList();
        }

        private List<Tuple<int,int>> ParseRowForInfected(string line, int y, int width)
        {
            var list = new List<Tuple<int, int>>();
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '#')
                {
                    var x = (width / 2) - i;
                    list.Add(new Tuple<int, int>(x, y));
                }
            }
            return list;
        }

        public void Reset()
        {
            _virusX = 0;
            _virusY = 0;
            _infectionBursts = 0;
        }

        public int InfectionBurstsAfterTotalBursts(int numBursts)
        {
            Reset();

            for (int i = 0; i < numBursts; i++)
            {
                RunSimulationStep();
            }

            return _infectionBursts;
        }

        private void RunSimulationStep()
        {
            var coord = new Tuple<int, int>(_virusX, _virusY);
            bool shouldTurnLeft;
            if (_infectedGridPoints.Contains(coord))
            {
                shouldTurnLeft = false;
                _infectedGridPoints.Remove(coord);
            }
            else
            {
                shouldTurnLeft = true;
                _infectedGridPoints.Add(coord);
                _infectionBursts++;
            }
            ExecuteMove(shouldTurnLeft);
        }

        private void ExecuteMove(bool isTurnLeft)
        {
            int direction;
            direction = isTurnLeft ? (int)_direction - 1 : ((int)_direction + 1) % 4;
            if (direction < 0)
            {
                direction = 3;
            }
            _direction = (Direction)direction;

            switch (_direction)
            {
                case Direction.Up:
                    _virusY++;
                    break;
                case Direction.Left:
                    _virusX--;
                    break;
                case Direction.Down:
                    _virusY--;
                    break;
                case Direction.Right:
                    _virusX++;
                    break;
                default:
                    break;
            }
        }
    }
}
