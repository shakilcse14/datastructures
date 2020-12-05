namespace DataStructures.Core.LinkedList.Contracts.Interfaces
{
    public interface ILinkedList<T>
    {
        void Add(T data);
        void Add(T data, int position);
        void AddFirst(T data);
        void AddLast(T data);
        void Clear();
        void Remove(T data);
        void Remove(int position);
        void RemoveFirst();
        void RemoveLast();
        T Find(int position);
        bool Find(T data);
    }
}