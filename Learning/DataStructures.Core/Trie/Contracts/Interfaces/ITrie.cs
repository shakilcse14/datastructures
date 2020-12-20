namespace DataStructures.Core.Trie.Contracts.Interfaces
{
    public interface ITrie
    {
        void Insert(string word);
        bool Search(string word);
        void Delete(string word);
    }
}