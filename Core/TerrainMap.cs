namespace AlgorithmAssignment.Core
{
    public class TerrainMap
    {
        public int[,] Grid { get; }
        public int Rows => Grid.GetLength(0);
        public int Columns => Grid.GetLength(1);

        public Coordinates Start { get; }
        public Coordinates Goal { get; }

        public TerrainMap(int[,] grid, Coordinates start, Coordinates goal)
        {
            Grid = grid;
            Start = start;
            Goal = goal;
        }

        public int GetCost(Coordinates c) => Grid[c.Row, c.Column];

        public bool InBound(Coordinates c) => c.Row >= 0 && c.Row < Rows &&
            c.Column >= 0 && c.Column < Columns;

        public bool IsWall(Coordinates c) => GetCost(c) == 0;
    }
}
