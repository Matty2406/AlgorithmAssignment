using AlgorithmAssignment.Algorithms;

namespace AlgorithmAssignment.Core
{
    public static class AlgorithmFactory
    {
        public static IPathFinder Create(AlgorithmType type)
        {
            switch (type)
            {
                case AlgorithmType.BreadthFirst:
                    return new BreadthFirst();
                case AlgorithmType.DepthFirst:
                    return new DepthFirst();
                default:
                    throw new ArgumentException("Unknown algorithm type", nameof(type));
            }
        }
    }
}
