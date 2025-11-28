using AlgorithmAssignment.Core;
using AlgorithmAssignment.DataStructures;

namespace AlgorithmAssignment.Algorithms
{
    public class HillClimbing : IPathFinder
    {
        public List<Coordinates> Run(TerrainMap map)
        {
            // Implementation of Hill Climbing algorithm...

            // Depth limit for backtracking hill climbing
            Dictionary<Coordinates, int> depth = new();
            const int MAX_DEPTH = 1000;

            // Create open list, closed list, and tmp list
            CustomStack<Coordinates> openList = new();
            DataStructures.LinkedList<Coordinates> closedList = new();
            List<(Coordinates coord, int cost)> tmpList = new();

            // Track the path
            Dictionary<Coordinates, Coordinates> parent = new();

            // Push the initial state onto the open list
            openList.Push(map.Start);
            depth[map.Start] = 0;

            // Until goal is found or open list is empty
            while (!openList.IsEmpty())
            {
                // Pop the first element from the open list
                Coordinates current = openList.Pop();
                // If it was empty, return failure

                // If the goal is found, return success
                if (current.Equals(map.Goal))
                {
                    return ReconstructPath(parent, map.Start, map.Goal);
                }

                // Add current state to closed list
                closedList.PushBack(current);

                // For each rule that can match the current state
                foreach (var next in MovementRules.GetNeighbors(current))
                {
                    // Apply rule to generate the next state
                    if (map.InBound(next) && !map.IsWall(next) && !closedList.Contains(next))
                    {
                        // Check depth limit
                        if (depth[current] + 1 > MAX_DEPTH) continue;
                        depth[next] = depth[current] + 1;

                        // And calculate heuristic cost
                        int h = Heuristics.ManhattanDistance(next, map.Goal);
                        tmpList.Add((next, h));
                    }
                }

                // Sort tmp list by cost
                tmpList.Sort((a, b) => a.cost.CompareTo(b.cost));

                // Add list to open list
                for (int i = tmpList.Count - 1; i >= 0; i--)
                {
                    openList.Push(tmpList[i].coord);
                    parent[tmpList[i].coord] = current;
                }

                // Clear tmp list
                tmpList.Clear();
            }

            // If we reach here, return failure
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
