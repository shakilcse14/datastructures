using System.Collections.Generic;
using DataStructures.Core.Trie.Contracts;
using DataStructures.Core.Trie.Contracts.Interfaces;

namespace DataStructures.Core.Trie
{
    public class Trie : ITrie
    {
        private TrieNode _root;

        public Trie() { }

        public void Insert(string word)
        {
            if(_root == null)
                _root = new TrieNode()
                {
                    Childrens = new Dictionary<char, TrieNode>()
                };

            var currentNode = _root;
            foreach (var key in word)
            {
                if (!currentNode.Childrens.ContainsKey(key))
                    currentNode.Childrens[key] = new TrieNode()
                    {
                        Childrens = new Dictionary<char, TrieNode>()
                    };

                currentNode = currentNode.Childrens[key];
            }

            currentNode.IsAWord = true;
        }

        public bool Search(string word)
        {
            var currentNode = _root;
            foreach (var key in word)
            {
                if (currentNode.Childrens.ContainsKey(key))
                    currentNode = currentNode.Childrens[key];
                else
                    return false;
            }
            return currentNode.IsAWord;
        }

        public void Delete(string word)
        {
            var currentNode = _root;
            DeleteRecursive(currentNode, word);
        }

        #region Private methods

        private bool DeleteRecursive(TrieNode node, string word, int key = 0)
        {
            if (node == null)
                return false;
            if (word.Length == key)
            {
                if (node.IsAWord)
                    node.IsAWord = false;

                return node.Childrens.Count <= 0;
            }

            if (!node.Childrens.ContainsKey(word[key]))
                return false;

            node = node.Childrens[word[key]];
            var isDelete = DeleteRecursive(node, word, key + 1);
            if (!isDelete) return false;

            if (node.Childrens.Count > 0)
                node.Childrens.Remove(word[key + 1]);
            return node.Childrens.Count <= 0 && !node.IsAWord;
        }

        #endregion
    }
}