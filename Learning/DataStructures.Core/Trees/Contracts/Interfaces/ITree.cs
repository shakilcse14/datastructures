namespace DataStructures.Core.Trees.Contracts.Interfaces
{
    public interface ITree<T>
    {
        void Traverse(TraverseType traverseType);
    }
}