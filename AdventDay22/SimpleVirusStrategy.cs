namespace AdventDay22
{
    public class SimpleVirusStrategy : IVirusStrategy
    {
        public Direction DecideTurnDirection(GridState gridState)
        {
            var direction = gridState.CurrentGridSquareState == GridSquareStatus.Infected 
                ? Direction.Right : Direction.Left;
            return direction;
        }

        public void ModifyNode(GridState gridState)
        {
            if (gridState.CurrentGridSquareState == GridSquareStatus.Infected)
            {
                gridState.GridSquareStatuses.Remove(gridState.CurrentPosition);
            }
            else
            {
                gridState.GridSquareStatuses.Add(gridState.CurrentPosition, GridSquareStatus.Infected);
                gridState.InfectionBursts++;
            }
        }
    }
}
