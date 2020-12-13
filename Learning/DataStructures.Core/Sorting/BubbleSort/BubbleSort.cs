using System;
using System.Collections.Generic;
using DataStructures.Core.Sorting.Contracts.Interfaces;

namespace DataStructures.Core.Sorting.BubbleSort
{
    public class BubbleSort<T> : ISort<T> where T : IComparable
    {
        private readonly T[] _items;

        public BubbleSort(T[] items)
        {
            _items = items;
        }

        /// <summary>
        /// Time complexity O(n^2)
        /// </summary>
        /// <returns></returns>
        public T[] Sort()
        {
            for (var indexI = 0; indexI < _items.Length; indexI++)
            {
                // _items.Length - 1 - indexI, here last one will be the biggest, no need to check
                for (var indexJ = 0; indexJ < _items.Length - 1 - indexI; indexJ++)
                {
                    var result = _items[indexJ].CompareTo(_items[indexJ + 1]);
                    if (result <= 0) continue;
                    var temp = _items[indexJ + 1];
                    _items[indexJ + 1] = _items[indexJ];
                    _items[indexJ] = temp;
                }
            }
            return _items;
        }
    }
}