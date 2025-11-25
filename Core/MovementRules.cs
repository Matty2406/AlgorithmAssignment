namespace AlgorithmAssignment.Core
{
    public static class MovementRules
    {

        // Clockwise Rules
        private static readonly Coordinates[] Directions =
        {
            new Coordinates(-1, 0), // -> North
            new Coordinates(0, 1),  // -> East
            new Coordinates(1, 0),  // -> South
            new Coordinates(0, -1)  // -> West
        };

        public static IEnumerable<Coordinates> GetNeighbors(Coordinates c)
        {
            foreach (var d in Directions)
            {
                yield return new Coordinates(c.Row + d.Row, c.Column + d.Column);
            }
        }

        // Anti-Clockwise Rules
        private static readonly Coordinates[] ReverseDirections =
        {
            new Coordinates(0, -1), // West
            new Coordinates(1, 0),  // South
            new Coordinates(0, 1), // East
            new Coordinates(-1, 0)  // North
        };

        public static IEnumerable<Coordinates> GetReverseNeighbors(Coordinates c)
        {
            foreach (var d in ReverseDirections)
            {
                yield return new Coordinates(c.Row + d.Row, c.Column + d.Column);
            }
        }
    }
}