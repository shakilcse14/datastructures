using System;
using System.Linq;
using DataStructures.Core.Search.Contracts.Interfaces;

namespace DataStructures.Core.Search.BinarySearch
{
    public class BinarySearch<T> : ISearch<T> where T : IComparable
    {
        private readonly T[] _sortedItems;
        
        public BinarySearch(T[] sortedItems)
        {
            _sortedItems = sortedItems;
        }

        public bool Find(T data)
        {
            return Search(0, _sortedItems.Length - 1, data);
        }

        #region Private methods

        private bool Search(int left, int right, T data)
        {
            if (left > right)
                return false;
            var midIndex = (left + right) / 2;
            var result = _sortedItems[midIndex].CompareTo(data);
            if (result == 0)
                return true;

            if (result > 0)
                return Search(left, midIndex - 1, data);
            else
                return Search(midIndex + 1, right, data);
        }

        #endregion
    }
}