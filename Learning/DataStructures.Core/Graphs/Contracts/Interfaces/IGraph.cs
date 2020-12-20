namespace DataStructures.Core.Graphs.Contracts.Interfaces
{
    public interface IGraph
    {
        void AddEdge(int from, int to);
        void Traverse(int startFrom);
    }
}