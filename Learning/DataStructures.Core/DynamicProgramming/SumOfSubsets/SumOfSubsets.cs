namespace DataStructures.Core.DynamicProgramming.SumOfSubsets
{
    public class SumOfSubsets
    {
        private int[] _subsets;
        private int _total;
        private int[,] _store;

        public SumOfSubsets() { }

        public bool Find(int[] subsets, int total)
        {
            _subsets = subsets;
            _total = total;
            _store = new int[subsets.Length + 1, total + 1];
            for (var indexI = 0; indexI < subsets.Length; indexI++)
            {
                for (var indexJ = 0; indexJ < total + 1; indexJ++)
                {
                    _store[indexI, indexJ] = -1;
                }
            }

            //return IsSumEqualsRecursive(subsets.Length, total);
            //return IsSumEqualsMemoization(subsets.Length, total);
            return IsSumEqualsDp();
        }

        #region Private methods

        /// <summary>
        /// Time complexity O(2^n)
        /// </summary>
        /// <param name="index"></param>
        /// <param name="currentTotal"></param>
        /// <returns></returns>
        private bool IsSumEqualsRecursive(int index, int currentTotal)
        {
            if (currentTotal == 0)
                return true;
            if (index == 0)
                return false;
            if (currentTotal - _subsets[index - 1] < 0)
                return IsSumEqualsRecursive(index - 1, currentTotal);

            return IsSumEqualsRecursive(index - 1, currentTotal - _subsets[index - 1]) ||
                   IsSumEqualsRecursive(index - 1, currentTotal);
        }
        /// <summary>
        /// Time complexity O(m*n)
        /// </summary>
        /// <param name="index"></param>
        /// <param name="currentTotal"></param>
        /// <returns></returns>
        private bool IsSumEqualsMemoization(int index, int currentTotal)
        {
            if (currentTotal == 0)
            {
                _store[index, currentTotal] = 1;
                return _store[index, currentTotal] == 1;
            }
            if (index == 0)
            {
                _store[index, currentTotal] = 0;
                return _store[index, currentTotal] == 1;
            }

            if (currentTotal - _subsets[index - 1] < 0)
            {
                _store[index, currentTotal]  = IsSumEqualsMemoization(index - 1, currentTotal) ? 1 : 0;
                return _store[index, currentTotal] == 1;
            }

            var result = IsSumEqualsMemoization(index - 1, currentTotal - _subsets[index - 1]) ||
                         IsSumEqualsMemoization(index - 1, currentTotal);
            _store[index, currentTotal] = result ? 1 : 0;

            return _store[index, currentTotal] == 1;
        }
        /// <summary>
        /// Time complexity O(m*n)
        /// </summary>
        /// <returns></returns>
        private bool IsSumEqualsDp()
        {
            _store = new int[_subsets.Length + 1, _total + 1];
            for (var indexI = 0; indexI <= _subsets.Length; indexI++)
            {
                for (var indexJ = 0; indexJ <= _total; indexJ++)
                {
                    if (indexJ == 0)
                        _store[indexI, indexJ] = 1;
                    else if (indexI == 0)
                        _store[indexI, indexJ] = 0;
                }
            }

            for (var indexI = 1; indexI <= _subsets.Length; indexI++)
            {
                for (var indexJ = 1; indexJ <= _total; indexJ++)
                {
                    _store[indexI, indexJ] = _store[indexI - 1, indexJ];
                    if (indexJ - _subsets[indexI - 1] >= 0)
                        _store[indexI, indexJ] = _store[indexI - 1, indexJ - _subsets[indexI - 1]] == 1 ||
                                                 _store[indexI, indexJ] == 1
                            ? 1
                            : 0;
                }
            }

            return _store[_subsets.Length, _total] == 1;
        }

        #endregion
    }
}