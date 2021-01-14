using System;
using DataStructures.Core.Sorting.Contracts.Interfaces;

namespace DataStructures.Core.Sorting.SelectionSort
{
    public class SelectionSort<T> : ISort<T> where T : IComparable
    {
        private readonly T[] _items;

        public SelectionSort(T[] items)
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
                var min = _items[indexI];
                var minIndex = indexI;
                for (var indexJ = indexI + 1; indexJ < _items.Length; indexJ++)
                {
                    var result = min.CompareTo(_items[indexJ]);
                    if (result > 0)
                    {
                        min = _items[indexJ];
                        minIndex = indexJ;
                    }
                }

                if(minIndex != indexI)
                    Swap(minIndex, indexI);
            }

            return _items;
        }

        #region Private methods

        private void Swap(int swapPosA, int swapPosB)
        {
            var temp = _items[swapPosA];
            _items[swapPosA] = _items[swapPosB];
            _items[swapPosB] = temp;
        }

        #endregion
    }
}