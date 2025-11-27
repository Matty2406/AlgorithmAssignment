namespace AlgorithmAssignment.Core.Nodes
{
    public abstract class SearchNode
    {
        public Coordinates Position { get; }

        public SearchNode? Parent { get; set; }

        protected SearchNode(Coordinates position, SearchNode? parent = null)
        {
            Position = position;
            Parent = parent;
        }
    }
}
