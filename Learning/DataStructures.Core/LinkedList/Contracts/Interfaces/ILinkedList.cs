namespace DataStructures.Core.LinkedList.Contracts.Interfaces
{
    public interface ILinkedList<T>
    {
        void AddAfter();
        void AddBefore();
        void AddFirst();
        void AddLast();
        void Clear();
        void Remove(T data);
        void RemoveFirst();
        void RemoveLast();
        T Find();
    }
}