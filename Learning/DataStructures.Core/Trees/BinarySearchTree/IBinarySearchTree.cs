namespace DataStructures.Core.Trees.BinarySearchTree
{
    public interface IBinarySearchTree<T>
    {
        void Insert(T data);
        bool Contains(T data);
        void Remove(T data);
    }
}