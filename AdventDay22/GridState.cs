using System;
using System.Collections.Generic;

namespace AdventDay22
{
    public class GridState
    {
        public int VirusX { get; set; } = 0;
        public int VirusY { get; set; } = 0;


        public Direction Direction { get; set; } = Direction.Up;

        public Dictionary<Tuple<int, int>, GridSquareStatus> GridSquareStatuses { get; }
            = new Dictionary<Tuple<int, int>, GridSquareStatus>();


        public Tuple<int, int> CurrentPosition => new Tuple<int, int>(VirusX, VirusY);

        public GridSquareStatus CurrentGridSquareState => GridSquareStatuses.ContainsKey(CurrentPosition)
            ? GridSquareStatuses[CurrentPosition]
            : GridSquareStatus.Clean;
        
        public int InfectionBursts { get; set; } = 0;
    }
}
