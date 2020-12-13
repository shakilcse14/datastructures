namespace DataStructures.Core.Sorting.Contracts.Interfaces
{
    public interface ISort<out T>
    {
        T[] Sort();
    }
}