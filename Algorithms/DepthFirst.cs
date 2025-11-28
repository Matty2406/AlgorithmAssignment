using AlgorithmAssignment.Core;
using AlgorithmAssignment.DataStructures;

namespace AlgorithmAssignment.Algorithms
{
    public class DepthFirst : IPathFinder
    {
        public List<Coordinates> Run(TerrainMap map)
        {
            // Implementation of Depth First Search...

            // Depth maximum limit
            Dictionary<Coordinates, int> depth = new();
            const int MAX_DEPTH = 1000;

            // Create Open and Closed List
            CustomStack<Coordinates> openList = new();
            DataStructures.LinkedList<Coordinates> closedList = new();

            // Track the path
            Dictionary<Coordinates, Coordinates> parent = new();

            // Push the initial state to open list
            openList.Push(map.Start);
            depth[map.Start] = 0;

            // Until goal state is reached or open list is empty
            while (!openList.IsEmpty())
            {
                // Pop first element from open list
                Coordinates current = openList.Pop();
                // If open list was empty, return failure and exit

                // If current state is goal state, return success and exit
                if (current.Equals(map.Goal))
                {
                    return ReconstructPath(parent, map.Start, map.Goal);
                }

                // For each rule that matches current state
                foreach (var next in MovementRules.GetReverseNeighbors(current))
                {
                    // Apply rule to generate next state
                    if (map.InBound(next) && !map.IsWall(next) && !closedList.Contains(next))
                    {
                        // Check depth limit
                        if (depth[current] + 1 > MAX_DEPTH) continue;
                        depth[next] = depth[current] + 1;

                        // If next state is not in closed list, add to open list
                        parent[next] = current;
                        openList.Push(next);
                    }
                }

                // Add current state to closed list
                closedList.PushBack(current);
            }

            // If open list is empty, return failure
            return new List<Coordinates>();
        }

        private List<Coordinates> ReconstructPath(Dictionary<Coordinates, Coordinates> parent, Coordinates start, Coordinates goal)
        {
            List<Coordinates> path = new();
            Coordinates current = goal;

            while (!current.Equals(start))
            {
                path.Add(current);
                current = parent[current];
            }

            path.Add(start);
            path.Reverse();
            return path;
        }
    }
}