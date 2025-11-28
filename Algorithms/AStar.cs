using AlgorithmAssignment.Core;
using AlgorithmAssignment.DataStructures;
using AlgorithmAssignment.Core.Nodes;

namespace AlgorithmAssignment.Algorithms
{
    public class AStar : IPathFinder
    {
        public int SortCounts { get; private set; } = 0;

        public List<Coordinates> Run(TerrainMap map)
        {
            // Implementation of A* Search algorithm

            // Create open and closed lists
            CustomPriorityQueue<EstimateNode> openList = new();
            DataStructures.LinkedList<EstimateNode> closedList = new();
            // Dictionary to track coordinates with nodes
            Dictionary<Coordinates, EstimateNode> openIndex = new();
            Dictionary<Coordinates, EstimateNode> closedIndex = new();

            // Push initial state to open list, set its parent to null, cost to 0, and heuristic to estimated cost to goal
            int h = Heuristics.ManhattanDistance(map.Start, map.Goal);
            EstimateNode startNode = new EstimateNode(map.Start, 0, h);
            openList.Insert(startNode);
            SortCounts++;
            openIndex[map.Start] = startNode;

            // Until goal state is reached or open list is empty
            while (!openList.IsEmpty())
            {
                // Pop the first element from the open list
                EstimateNode current = openList.Dequeue()!;
                // If empty, return failure

                // If current node is goal, success
                if (current.Position.Equals(map.Goal))
                {
                    return ReconstructPath(current);
                }

                // For each rule that matches the current state
                foreach (var next in MovementRules.GetNeighbors(current.Position))
                {
                    // Apply rule to generate new state
                    if (map.InBound(next) && !map.IsWall(next))
                    {
                        // The cost of new state is cost of current + cost of moving to new state
                        int g = current.Cost + map.GetCost(next);

                        // If n is on open list and >= cost, skip
                        bool inOpen = openIndex.TryGetValue(next, out EstimateNode? existingOpenNode);
                        bool inClosed = closedIndex.TryGetValue(next, out EstimateNode? existingClosedNode);

                        if (inOpen && existingOpenNode != null)
                        {
                            if (g >= existingOpenNode.Cost) continue;

                            // If new path to n is better, update node in open list
                            openList.Remove(existingOpenNode);
                            openIndex.Remove(next);
                        }

                        if (inClosed && existingClosedNode != null)
                        {
                            if (g >= existingClosedNode.Cost) continue;

                            closedList.RemoveFirst(existingClosedNode);
                            closedIndex.Remove(next);
                        }

                        // If n is not on open or closed list
                        int hNew = Heuristics.ManhattanDistance(next, map.Goal);
                        EstimateNode neighborNode = new EstimateNode(next, g, hNew, current);
                        openList.Insert(neighborNode);
                        SortCounts++;
                        openIndex[next] = neighborNode;

                        // Reorder is automatic
                    }
                }

                // Add current to closed list
                closedList.PushBack(current);
                closedIndex[current.Position] = current;
            }

            // If open list is empty, return failure
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
