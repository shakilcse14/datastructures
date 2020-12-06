namespace DataStructures.Core.HashTable.Contracts.Interfaces
{
    public interface IHashTable<K, V>
    {
        void Add(K key, V value);
        void Remove(K key);
        V Get(K key);
    }
}