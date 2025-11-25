namespace AlgorithmAssignment.Core
{
    public class TerrainMap
    {
        public int Rows { get; }
        public int Columns { get; }
        public int[,] Grid { get; }

        public Coordinates Start { get; }
        public Coordinates Goal { get; }

        public TerrainMap(int[,] grid, Coordinates start, Coordinates goal)
        {
            Grid = grid;
            Rows = grid.GetLength(0);
            Columns = grid.GetLength(1);

            Start = start;
            Goal = goal;
        }

        public int GetCost(Coordinates c) => Grid[c.Row, c.Column];

        public bool InBound(Coordinates c) => c.Row >= 0 && c.Row < Rows &&
            c.Column >= 0 && c.Column < Columns;

        public bool IsWall(Coordinates c) => GetCost(c) == 0;
    }
}
