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
    }
}