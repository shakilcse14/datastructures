using System.Collections.Generic;

namespace DataStructures.Core.Trie.Contracts
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Childrens { get; set; }
        public bool IsAWord { get; set; }
    }
}