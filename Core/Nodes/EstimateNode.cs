namespace AlgorithmAssignment.Core.Nodes
{
    public class EstimateNode : SearchNode, IComparable<EstimateNode>
    {
        public int Cost { get; }
        public int Heuristic { get; }
        public int EstimatedTotalCost => Cost + Heuristic;

        public EstimateNode(Coordinates position, int cost, int heuristic, SearchNode? parent = null) : base(position, parent)
        {
            Cost = cost;
            Heuristic = heuristic;
        }

        public int CompareTo(EstimateNode? other)
        {
            if (other == null) return 1;
            return EstimatedTotalCost.CompareTo(other.EstimatedTotalCost);
        }
    }
}
