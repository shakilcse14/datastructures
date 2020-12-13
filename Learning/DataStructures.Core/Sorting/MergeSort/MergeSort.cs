using System;
using DataStructures.Core.Sorting.Contracts.Interfaces;

namespace DataStructures.Core.Sorting.MergeSort
{
    public class MergeSort<T> : ISort<T> where T : IComparable
    {
        private readonly T[] _items;

        public MergeSort(T[] item)
        {
            _items = item;
        }

        /// <summary>
        /// Time complexity O(nlogn)
        /// </summary>
        /// <returns></returns>
        public T[] Sort()
        {
            var tempArray = new T[_items.Length];
            HelperMergeSort(0, _items.Length - 1, tempArray);
            return _items;
        }

        #region Private methods

        private void HelperMergeSort(int left, int right, T[] tempArray)
        {
            if(left >= right) return;
            var mid = (left + right) / 2;
            HelperMergeSort(left, mid, tempArray);
            HelperMergeSort(mid + 1, right, tempArray);
            Merge(left, mid, right, tempArray);
        }

        private void Merge(int left, int mid, int right, T[] tempArray)
        {
            var index = left;
            var leftStart = left;
            var leftEnd = mid;
            var rightStart = mid + 1;
            var rightEnd = right;
            while (leftStart <= leftEnd && rightStart <= rightEnd)
            {
                if (_items[leftStart].CompareTo(_items[rightStart]) < 0)
                {
                    tempArray[index] = _items[leftStart];
                    leftStart++;
                }
                else
                {
                    tempArray[index] = _items[rightStart];
                    rightStart++;
                }
                index++;
            }

            Array.Copy(_items, leftStart, tempArray, index, leftEnd - leftStart + 1);
            Array.Copy(_items, rightStart, tempArray, index, rightEnd - rightStart + 1);
            
            Array.Copy(tempArray, left, _items, left, right - left + 1);
        }

        #endregion
    }
}