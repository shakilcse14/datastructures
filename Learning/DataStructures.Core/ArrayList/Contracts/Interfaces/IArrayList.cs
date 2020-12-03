namespace DataStructures.Core.ArrayList.Contracts.Interfaces
{
    public interface IArrayList<in T>
    {
        void Add(T item);
        void Remove(int index);
    }
}