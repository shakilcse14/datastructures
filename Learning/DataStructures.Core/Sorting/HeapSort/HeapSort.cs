using DataStructures.Core.Sorting.Contracts.Interfaces;

namespace DataStructures.Core.Sorting.HeapSort
{
    public class HeapSort<T> : ISort<T>
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
            Heapify();
            DeletionToSort();

            return _items;
        }

        #region Private methods

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        private void Heapify()
        {
            var currentPosition = (_items.Length / 2) - 1;


            var leftPosition = GetLeftChildPosition(currentPosition);
            var rightPosition = GetRightChildPosition(currentPosition);
        }

        private void DeletionToSort()
        {

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