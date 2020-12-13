using System;
using System.Xml.Schema;
using DataStructures.Core.Sorting.Contracts.Interfaces;

namespace DataStructures.Core.Sorting.QuickSort
{
    public class QuickSort<T> : ISort<T> where T : IComparable
    {
        private readonly T[] _items;

        public QuickSort(T[] items)
        {
            _items = items;
        }

        /// <summary>
        /// Time complexity O(nlogn), worst O(n^2)
        /// </summary>
        /// <returns></returns>
        public T[] Sort()
        {
            HelperQuickSort(0, _items.Length - 1);
            return _items;
        }

        #region Private methods

        private void HelperQuickSort(int left, int right)
        {
            if (left >= right) return;

            var pivot = _items[(left + right) / 2];
            var index = Partition(left, right, pivot);
            HelperQuickSort(left, index - 1);
            HelperQuickSort(index, right);
        }

        private int Partition(int left, int right, T pivot)
        {
            while (left <= right)
            {
                while (_items[left].CompareTo(pivot) < 0)
                {
                    left++;
                }

                while (_items[right].CompareTo(pivot) > 0)
                {
                    right--;
                }

                if (left <= right)
                {
                    var temp = _items[left];
                    _items[left] = _items[right];
                    _items[right] = temp;
                    left++;
                    right--;
                }
            }

            return left;
        }

        #endregion
    }
}