using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventDay22
{
    public class VirusSimulator
    {
        private readonly GridState _originalGridState;
        private GridState _gridState = new GridState();
        private readonly IVirusStrategy _strategy;

        public VirusSimulator(string gridFile, IVirusStrategy strategy)
        {
            _strategy = strategy;

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

            lines
                .SelectMany((s, i) => ParseRowForInfected(s, (gridHeight / 2) - i, gridWidth)).ToList()
                .ForEach(coord => _gridState.GridSquareStatuses.Add(coord, GridSquareStatus.Infected));
            _originalGridState = _gridState;
        }

        private List<Tuple<int, int>> ParseRowForInfected(string line, int y, int width)
        {
            var list = new List<Tuple<int, int>>();
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '#')
                {
                    var x = (-width / 2) + i;
                    list.Add(new Tuple<int, int>(x, y));
                }
            }
            return list;
        }

        public int InfectionBurstsAfterTotalBursts(int numBursts)
        {
            _gridState = _originalGridState;

            for (int i = 0; i < numBursts; i++)
            {
                RunSimulationStep();
            }

            return _gridState.InfectionBursts;
        }

        private void RunSimulationStep()
        {
            Turn(_strategy.DecideTurnDirection(_gridState));
            _strategy.ModifyNode(_gridState);
            ExecuteMove();
        }

        private void Turn(Direction turnDirection)
        {
            _gridState.Direction = (Direction)(((int)_gridState.Direction + (int)turnDirection) % 4);
        }

        private void ExecuteMove()
        {
            switch (_gridState.Direction)
            {
                case Direction.Up:
                    _gridState.VirusY++;
                    break;
                case Direction.Left:
                    _gridState.VirusX--;
                    break;
                case Direction.Down:
                    _gridState.VirusY--;
                    break;
                case Direction.Right:
                    _gridState.VirusX++;
                    break;
            }
        }
    }
}
