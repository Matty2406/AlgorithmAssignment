using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmAssignment.Core
{
    public static class AlgorithmFactory
    {
        public static IAlgorithm Create(AlgorithmType type)
        {
            switch (type)
            {
                case AlgorithmType.BreadthFirst:
                    break;
                case AlgorithmType.DepthFirst:
                    break;
                case AlgorithmType.Dijkstra:
                    break;
                case AlgorithmType.AStar:
                    break;
                default:
                    throw new ArgumentException("Unknown algorithm type", nameof(type));
            }
        }
    }
}
