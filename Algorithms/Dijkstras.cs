using AlgorithmAssignment.Core;
using AlgorithmAssignment.Core.Nodes;
using AlgorithmAssignment.DataStructures;

namespace AlgorithmAssignment.Algorithms
{
    public class Dijkstras : IPathFinder
    {
        public List<Coordinates> Run(TerrainMap map)
        {
            // Implementation of Dijkstra's algorithm

            // Create open list
            CustomPriorityQueue<CostNode> openList = new();
            // Dictionary to track coordinates with nodes
            Dictionary<Coordinates, CostNode> openIndex = new();

            // Push initial start to open list, with cost 0, no parent
            CostNode costNode = new CostNode(map.Start, 0);
            openList.Insert(costNode);
            openIndex[map.Start] = costNode;

            // Until goal found or open list empty
            while (!openList.IsEmpty())
            {
                // Pop the first best node from open list
                CostNode current = openList.Dequeue()!;
                // If empty, no path found

                // If goal, reconstruct path
                if (current.Position.Equals(map.Goal))
                {
                    return ReconstructPath(current);
                }

                // For each rule that can match current
                foreach (var next in MovementRules.GetNeighbors(current.Position))
                {
                    // Apply rule to generate and call it n
                    if (map.InBound(next) && !map.IsWall(next))
                    {
                        // The cost of new state is cost of current + cost to enter n
                        int newCost = current.Cost + map.GetCost(next);

                        // If n is on open list and >= cost, skip
                        bool inOpen = openIndex.TryGetValue(next, out CostNode? existingNode);
                        if (inOpen)
                        {
                            if (existingNode!.Cost <= newCost) continue;

                            // n now replaces existing node on open list
                            openList.Remove(existingNode!);
                            openIndex.Remove(next);
                        }

                        // If n is not on open list, add it
                        CostNode neighborNode = new CostNode(next, newCost, current);
                        openList.Insert(neighborNode);
                        openIndex[next] = neighborNode;

                        // Reorders the open list automatically on insert
                    }
                }
            }

            // If open list empty, fail
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
