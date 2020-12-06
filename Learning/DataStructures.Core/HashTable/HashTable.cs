using System;
using DataStructures.Core.ArrayList;
using DataStructures.Core.HashTable.Contracts.Interfaces;
using DataStructures.Core.LinkedList;

namespace DataStructures.Core.HashTable
{
    public class HashTable<K,V> : IHashTable<K, V>
    {
        private int _bucketSize;
        private readonly float _loadFactor;
        private int _currentSize;

        private ArrayList<SinglyLinkedList<KeyValuePair<K, V>>> _bucketList;

        public HashTable()
        {
            _bucketSize = 10;
            _loadFactor = 0.7f;
            _currentSize = 0;

            _bucketList = new ArrayList<SinglyLinkedList<KeyValuePair<K, V>>>(_bucketSize);
            for (var index = 0; index < _bucketSize; index++)
            {
                _bucketList.Add(new SinglyLinkedList<KeyValuePair<K, V>>());
            }
        }

        public int Size
        {
            get
            {
                return _currentSize;
            }
        }

        public void Add(K key, V value)
        {
            try
            {
                int bucketIndexForKey = GetBucketIndex(key);
                _bucketList[bucketIndexForKey].Add(new KeyValuePair<K, V>()
                {
                    Key = key,
                    Value = value
                });

                _currentSize++;

                if (((float)_currentSize / _bucketSize) >= _loadFactor)
                {
                    Console.WriteLine("Load factor crossed");
                }
            }
            catch(Exception)
            {
                throw new InvalidOperationException();
            }
        }

        public void Remove(K key)
        {
            throw new System.NotImplementedException();
        }

        #region Private Methods

        private int GetBucketIndex(K key)
        {
            return Math.Abs(key.GetHashCode()) % _bucketSize;
        }

        public V Get(K key)
        {
            try
            {
                var bucketIndexForKey = GetBucketIndex(key);
                return _bucketList[bucketIndexForKey].Find(key, "Key").Value;
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        #endregion
    }
}
