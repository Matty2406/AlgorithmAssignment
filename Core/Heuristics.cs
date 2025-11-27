namespace AlgorithmAssignment.Core
{
    public static class Heuristics
    {
        public static int ManhattanDistance(Coordinates a, Coordinates b)
        {
            return Math.Abs(a.Row - b.Row) + Math.Abs(a.Column - b.Column);
        }
    }
}