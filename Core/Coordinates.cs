namespace AlgorithmAssignment.Core
{
    public readonly struct Coordinates : IEquatable<Coordinates>
    {
        public int Row { get; init; }
        public int Column { get; init; }

        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public bool Equals(Coordinates other) => Row == other.Row && Column == other.Column;

        public override string ToString() => $"{Row} {Column}";
    }
}