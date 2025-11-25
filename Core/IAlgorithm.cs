namespace AlgorithmAssignment.Core
{
    public interface IAlgorithm
    {
        List<Coordinates> Run(TerrainMap map);
    }
}