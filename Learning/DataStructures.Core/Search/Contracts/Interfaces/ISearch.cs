namespace DataStructures.Core.Search.Contracts.Interfaces
{
    public interface ISearch<in T>
    {
        bool Find(T data);
    }
}