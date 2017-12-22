namespace AdventDay22
{
    public interface IVirusStrategy
    {
        Direction DecideTurnDirection(GridState gridState);
        void ModifyNode(GridState gridState);
    }
}
