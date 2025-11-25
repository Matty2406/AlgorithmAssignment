namespace AlgorithmAssignment.Core
{
    public readonly struct Coordinates : IComparable, IEquatable<Coordinates>
    {
        public int Row { get; init; }
        public int Column { get; init; }

        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int CompareTo(object? obj)
        {
            if (obj is not Coordinates other)
            {
                throw new ArgumentException("Object is not a Coordinates", nameof(obj));
            }

            var cmp = Row.CompareTo(other.Row);
            return cmp != 0 ? cmp : Column.CompareTo(other.Column);
        }

        public bool Equals(Coordinates other) => Row == other.Row && Column == other.Column;

        public override bool Equals(object? obj) => obj is Coordinates other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Row, Column);

        public override string ToString() => $"({Row}, {Column})";
    }
}