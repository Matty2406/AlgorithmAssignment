namespace AlgorithmAssignment.Core
{
    public interface IPathFinder
    {
        List<Coordinates> Run(TerrainMap map);
    }
}