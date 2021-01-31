using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Core.Backtracking.Subsets
{
    public class Subsets
    {
        private readonly int[] _items;

        public Subsets(int [] items)
        {
            _items = items;
        }

        /// <summary>
        /// Time complexity O(2^n)
        /// </summary>
        public List<string> FindAll()
        {
            var sets = new List<string>();
            Find(sets, new List<int>(), 0);

            return sets;
        }

        #region Private methods

        private void Find(ICollection<string> sets, IList<int> list, int position)
        {
            sets.Add(string.Join(", ", list));
            for (var indexI = position; indexI < _items.Length; indexI++)
            {
                list.Add(_items[indexI]);
                Find(sets, list, indexI + 1);
                list.RemoveAt(list.Count - 1);
            }
        }

        #endregion
    }
}