using System;

namespace AdventDay22
{
    public class EvolvedVirusStrategy : IVirusStrategy
    {
        public Direction DecideTurnDirection(GridState gridState)
        {
            switch (gridState.CurrentGridSquareState)
            {
                case GridSquareStatus.Clean:
                    return Direction.Left;
                case GridSquareStatus.Infected:
                    return Direction.Right;
                case GridSquareStatus.Weakened:
                    return Direction.Up;
                case GridSquareStatus.Flagged:
                    return Direction.Down;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ModifyNode(GridState gridState)
        {
            switch (gridState.CurrentGridSquareState)
            {
                case GridSquareStatus.Clean:
                    gridState.GridSquareStatuses.Add(gridState.CurrentPosition, GridSquareStatus.Weakened);
                    break;
                case GridSquareStatus.Infected:
                    gridState.GridSquareStatuses[gridState.CurrentPosition] = GridSquareStatus.Flagged;
                    break;
                case GridSquareStatus.Weakened:
                    gridState.GridSquareStatuses[gridState.CurrentPosition] = GridSquareStatus.Infected;
                    gridState.InfectionBursts++;
                    break;
                case GridSquareStatus.Flagged:
                    gridState.GridSquareStatuses.Remove(gridState.CurrentPosition);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
