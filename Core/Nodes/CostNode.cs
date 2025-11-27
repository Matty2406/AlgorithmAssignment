namespace AlgorithmAssignment.Core.Nodes
{
    public class CostNode : SearchNode, IComparable<CostNode>
    {
        public int Cost { get; }

        public CostNode(Coordinates position, int cost, SearchNode? parent = null) : base(position, parent)
        {
            Cost = cost;
        }

        public int CompareTo(CostNode? other)
        {
            if (other == null) return 1;
            return Cost.CompareTo(other.Cost);
        }
    }
}
