using AlgorithmAssignment.Core;
using AlgorithmAssignment.DataStructures;
using AlgorithmAssignment.Core.Nodes;

namespace AlgorithmAssignment.Algorithms
{
    public class BestFirst : IPathFinder
    {
        public List<Coordinates> Run(TerrainMap map)
        {
            // Implementation of Best-First Search algorithm

            // Create an open list and closed list
            CustomPriorityQueue<CostNode> openList = new();
            DataStructures.LinkedList<Coordinates> closedList = new();

            // Add the start node to the open list, set parent to null, and calculate heuristic
            int h = Heuristics.ManhattanDistance(map.Start, map.Goal);
            openList.Insert(new CostNode(map.Start, h));

            // Until goal is found or open list is empty
            while (!openList.IsEmpty())
            {
                // Pop the best node from the open list
                CostNode current = openList.Dequeue()!;
                // If open list is empty, return empty path

                // If goal is reached, reconstruct path
                if (current.Position.Equals(map.Goal))
                {
                    return ReconstructPath(current);
                }

                // For each rule that matches current
                foreach (var next in MovementRules.GetNeighbors(current.Position))
                {
                    // Apply rule to generate new state
                    if (map.InBound(next) && !map.IsWall(next) && !closedList.Contains(next))
                    {
                        // Calculate heuristic for the new state
                        int heuristic = Heuristics.ManhattanDistance(next, map.Goal);

                        // If new state has not been visited, push to open list and set parent
                        openList.Insert(new CostNode(next, heuristic, current));
                    }
                }

                // Add current to closed list
                closedList.PushBack(current.Position);
            }

            // If goal not found, return failure
            return new List<Coordinates>();
        }

        private List<Coordinates> ReconstructPath(SearchNode goalNode)
        {
            var path = new List<Coordinates>();
            SearchNode? currentNode = goalNode;

            while (currentNode != null)
            {
                path.Add(currentNode.Position);
                currentNode = currentNode.Parent;
            }

            path.Reverse();
            return path;
        }
    }
}
