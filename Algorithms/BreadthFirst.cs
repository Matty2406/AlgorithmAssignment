using AlgorithmAssignment.Core;
using AlgorithmAssignment.DataStructures;

namespace AlgorithmAssignment.Algorithms
{
    public class BreadthFirst : IAlgorithm
    {
        public List<Coordinates> Run(TerrainMap map)
        {
            // Implementation of the Breadth-First Search algorithm...

            // Create the Open and Closed lists
            CustomQueue<Coordinates> openList = new();
            HashSet<Coordinates> closedList = new();

            // Track the path
            Dictionary<Coordinates, Coordinates> parent = new();

            // Enqueue the start position
            openList.Enqueue(map.Start);

            // Until the end is reached or open list is empty:
            while (!openList.IsEmpty())
            {
                // Dequeue first coordinate from Open List and call it current
                Coordinates current = openList.Dequeue();

                // If current is the goal, reconstruct and return the path
                if (current.Equals(map.Goal))
                {
                    return ReconstructPath(parent, map.Start, map.Goal);
                }

                // For each rule (North, East, South, West):
                foreach (var next in MovementRules.GetNeighbors(current))
                {
                    // If next is not in closed list, enqueue next to Open List
                    if (!closedList.Contains(next) && map.InBound(next) && !map.IsWall(next)) // Check bounds and walls
                    {
                        parent[next] = current;
                        openList.Enqueue(next);
                    }
                }

                // Add current to Closed List
                closedList.Add(current);
            }

            // If the goal was not reached, return an empty path
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
