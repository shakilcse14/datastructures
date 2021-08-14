using System;

namespace DataStructures.Core.Trees.SegmentTree
{
    public class SegmentTree
    {
        public readonly int[] RunningSum;

        private readonly int[] _items;

        /// <summary>
        /// Space complexity O(2n -1)
        /// </summary>
        /// <param name="items"></param>
        public SegmentTree(int [] items)
        {
            _items = items;
            var x = (int)(Math.Ceiling(Math.Log(_items.Length) / Math.Log(2)));

            var maxSize = 2 * (int)Math.Pow(2, x) - 1;

            RunningSum = new int[maxSize];

            CreateSegmentTree();
        }

        /// <summary>
        /// Time complexity O(logn)
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Update(int index, int value)
        {
            var diff = value - _items[index];
            _items[index] = value;

            Update(index, 0, diff, 0, _items.Length - 1);
        }

        /// <summary>
        /// Time complexity O(logn)
        /// </summary>
        /// <param name="leftIndex"></param>
        /// <param name="rightIndex"></param>
        /// <returns></returns>
        public int GetSum(int leftIndex, int rightIndex)
        {
            return GetSum(0, 0, _items.Length - 1, leftIndex, rightIndex);
        }

        #region Private Methods

        private void Update(int index, int currentIndex, int diff, int left, int right)
        {
            if (!(index >= left && index <= right))
                return;

            RunningSum[currentIndex] += diff;
            if (left != right)
            {
                var mid = (right - left) / 2 + left;
                Update(index, 2 * currentIndex + 1, diff, left, mid);
                Update(index, 2 * currentIndex + 2, diff, mid + 1, right);
            }
        }

        private int GetSum(int index, int left, int right, int leftIndex, int rightIndex)
        {
            if (leftIndex <= left && rightIndex >= right)
                return RunningSum[index];

            if (rightIndex < left || leftIndex > right)
                return 0;

            var mid = (right - left) / 2 + left;

            return GetSum(2 * index + 1, left, mid, leftIndex, rightIndex) +
                   GetSum(2 * index + 2, mid + 1, right, leftIndex, rightIndex);
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        private void CreateSegmentTree()
        {
            CreateRunningSum(0, 0, _items.Length - 1);
        }

        private int CreateRunningSum(int index, int left, int right)
        {
            if (left == right)
            {
                RunningSum[index] = _items[left];
                return _items[left];
            }

            var mid = (right - left) / 2 + left;

            RunningSum[index] = CreateRunningSum(2 * index + 1, left, mid) +
                                 CreateRunningSum(2 * index + 2, mid + 1, right);

            return RunningSum[index];
        }

        #endregion
    }
}