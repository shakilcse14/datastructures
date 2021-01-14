using System;
using DataStructures.Core.Sorting.Contracts.Interfaces;

namespace DataStructures.Core.Sorting.InsertionSort
{
    public class InsertionSort<T> : ISort<T> where T : IComparable
    {
        private readonly T[] _items;

        public InsertionSort(T[] items)
        {
            _items = items;
        }

        /// <summary>
        /// Time complexity O(n^2)
        /// </summary>
        /// <returns></returns>
        public T[] Sort()
        {
            for (var indexI = 1; indexI < _items.Length; indexI++)
            {
                var temp = _items[indexI];
                int indexJ;
                for (indexJ = indexI - 1; indexJ >= 0; indexJ--)
                {
                    var result = temp.CompareTo(_items[indexJ]);
                    if (result >= 0) break;
                    _items[indexJ + 1] = _items[indexJ];
                }
                _items[indexJ + 1] = temp;
            }
            return _items;
        }
    }
}