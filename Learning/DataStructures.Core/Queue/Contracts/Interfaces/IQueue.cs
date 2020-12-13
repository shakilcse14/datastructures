namespace DataStructures.Core.Queue.Contracts.Interfaces
{
    public interface IQueue<T>
    {
        void Clear();
        void Enqueue(T data);
        T Dequeue();
        bool Contains(T data);
        T Peek();
    }
}