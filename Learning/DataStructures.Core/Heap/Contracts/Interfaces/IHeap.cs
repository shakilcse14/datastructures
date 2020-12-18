namespace DataStructures.Core.Heap.Contracts.Interfaces
{
    public interface IHeap<T>
    {
        void Enqueue(T data);
        T Dequeue();
        T Peek();
    }
}