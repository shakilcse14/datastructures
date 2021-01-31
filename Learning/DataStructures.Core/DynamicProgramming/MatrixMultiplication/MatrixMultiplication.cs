using System;

namespace DataStructures.Core.DynamicProgramming.MatrixMultiplication
{
    public class MatrixMultiplication
    {
        private readonly int[] _items;
        private readonly int[,] _results;

        public MatrixMultiplication(int[] items)
        {
            _items = items;
            _results = new int[items.Length, items.Length];

            for (var indexI = 0; indexI < _items.Length; indexI++)
            {
                for (var indexJ = 0; indexJ < _items.Length; indexJ++)
                {
                    _results[indexI, indexJ] = 0;
                }
            }
        }

        public int TotalMultiplication()
        {
            return TabulationMatrixMultiplication();
            return RecursiveMemoizationMatrixMultiplication(1, _items.Length - 1);
            return RecursiveMatrixMultiplication(1, _items.Length - 1);
        }

        #region Private methods

        /// <summary>
        /// Time complexity O(n^2)
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int TabulationMatrixMultiplication()
        {
            for (var len = 2; len < _items.Length; len++)
            {
                for (var indexLeft = 1; indexLeft < _items.Length - len + 1; indexLeft++)
                {
                    var indexRight = len + indexLeft - 1;
                    if (indexLeft >= indexRight)
                        continue;

                    _results[indexLeft, indexRight] = int.MaxValue;
                    for (var index = indexLeft; index <= indexRight - 1; index++)
                    {
                        _results[indexLeft, indexRight] =
                            Math.Min(_results[indexLeft, indexRight],
                                _results[indexLeft, index] + _results[index + 1, indexRight] +
                                (_items[indexLeft - 1] * _items[index] * _items[indexRight]));
                    }
                }
            }

            return _results[1, _items.Length - 1];
        }

        /// <summary>
        /// Time complexity O(n^3)
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int RecursiveMemoizationMatrixMultiplication(int left, int right)
        {
            if (left >= right)
                return 0;
            if (_results[left, right] != 0)
                return _results[left, right];

            _results[left, right] = int.MaxValue;
            for (var index = left; index < right; index++)
            {
                _results[left, right] =
                    Math.Min(_results[left, right], RecursiveMemoizationMatrixMultiplication(left, index) +
                                                    RecursiveMemoizationMatrixMultiplication(index + 1, right) +
                                                    _items[left - 1] * _items[index] * _items[right]);
            }

            return _results[left, right];
        }

        /// <summary>
        /// Time complexity exponential
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int RecursiveMatrixMultiplication(int left, int right)
        {
            if (left >= right)
                return 0;

            var min = int.MaxValue;
            for (var index = left; index < right; index++)
            {
                var result = RecursiveMatrixMultiplication(left, index) +
                             RecursiveMatrixMultiplication(index + 1, right) +
                             _items[left - 1] * _items[index] * _items[right];
                if (result < min)
                    min = result;
            }

            return min;
        }

        #endregion
    }
}