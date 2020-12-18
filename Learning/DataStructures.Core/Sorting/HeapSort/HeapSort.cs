using System;
using DataStructures.Core.Sorting.Contracts.Interfaces;

namespace DataStructures.Core.Sorting.HeapSort
{
    public class HeapSort<T> : ISort<T> where T : IComparable
    {
        private readonly T[] _items;

        public HeapSort(T[] items)
        {
            _items = items;
        }

        /// <summary>
        /// Time complexity O(nlogn)
        /// </summary>
        /// <returns></returns>
        public T[] Sort()
        {
            for (var i = (_items.Length / 2) - 1; i >= 0 ; i--)
                Heapify(_items, i, _items.Length);

            DeletionLikeSwap(_items);

            return _items;
        }

        #region Private methods

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        private void Heapify(T[] items, int currentPosition, int length)
        {
            var leftPosition = GetLeftChildPosition(currentPosition);
            var rightPosition = GetRightChildPosition(currentPosition);

            var largestPosition = currentPosition;

            if (leftPosition < length && items[leftPosition].CompareTo(items[largestPosition]) > 0)
            {
                largestPosition = leftPosition;
            }

            if (rightPosition < length && items[rightPosition].CompareTo(items[largestPosition]) > 0)
            {
                largestPosition = rightPosition;
            }

            if (largestPosition == currentPosition) return;

            Swap(items, largestPosition, currentPosition);

            Heapify(items, largestPosition, length);
        }

        private void Swap(T[] items, int swapPosA, int swapPosB)
        {
            var temp = items[swapPosA];
            items[swapPosA] = items[swapPosB];
            items[swapPosB] = temp;
        }

        /// <summary>
        /// Time complexity O(nlogn)
        /// </summary>
        /// <param name="items"></param>
        private void DeletionLikeSwap(T[] items)
        {
            for (var i = items.Length - 1; i > 0; i--)
            {
                Swap(items, i, 0);
                Heapify(items, 0, i);
            }
        }

        private int GetLeftChildPosition(int index)
        {
            return (2 * index) + 1;
        }

        private int GetRightChildPosition(int index)
        {
            return (2 * index) + 2;
        }

        #endregion
    }
}