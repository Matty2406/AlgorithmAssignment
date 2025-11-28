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
                case AlgorithmType.HillClimbing:
                    return new HillClimbing();
                case AlgorithmType.BestFirst:
                    return new BestFirst();
                case AlgorithmType.Dijkstras:
                    return new Dijkstras();
                case AlgorithmType.AStar:
                    return new AStar();
                default:
                    throw new ArgumentException("Unknown algorithm type", nameof(type));
            }
        }
    }
}
