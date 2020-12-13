namespace DataStructures.Core.Stack.Contracts.Interfaces
{
    public interface IStack<T>
    {
        void Clear();
        void Push(T data);
        T Pop();
        bool Contains(T data);
        T Peek();
    }
}