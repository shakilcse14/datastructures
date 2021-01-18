using System;

namespace DataStructures.Core.DynamicProgramming.LCS
{
    public class LongestCommonSubsequence
    {
        private int[,] _storeOccurence;
        public LongestCommonSubsequence() { }

        /// <summary>
        /// Time complexity
        ///     Recursion approach O(2^n)
        ///     Memoization approach O(MxN)
        /// </summary>
        /// <param name="aFirst"></param>
        /// <param name="bSecond"></param>
        /// <returns></returns>
        public int MaxLcs(string aFirst, string bSecond)
        {
            _storeOccurence = new int[aFirst.Length, bSecond.Length];
            for (var indexI = 0; indexI < aFirst.Length; indexI++)
            {
                for (var indexJ = 0; indexJ < bSecond.Length; indexJ++)
                {
                    _storeOccurence[indexI, indexJ] = -1;
                }
            }

            //return RecursionLcs(aFirst, bSecond, 0, 0);
            //return RecursionMemoizationLcs(aFirst, bSecond, 0, 0);
            return TabulationLcs(aFirst, bSecond);
        }

        #region Private methods

        private int TabulationLcs(string aFirst, string bSecond)
        {
            _storeOccurence = new int[aFirst.Length + 1, bSecond.Length + 1];
            for (var indexI = 0; indexI < aFirst.Length + 1; indexI++)
            {
                if (indexI == 0)
                    continue;
                for (var indexJ = 0; indexJ < bSecond.Length + 1; indexJ++)
                {
                    if (indexJ == 0)
                        continue;
                    if (aFirst[indexI - 1] == bSecond[indexJ - 1])
                        _storeOccurence[indexI, indexJ] = 1 + _storeOccurence[indexI - 1, indexJ - 1];
                    else
                        _storeOccurence[indexI, indexJ] = Math.Max(_storeOccurence[indexI - 1, indexJ],
                            _storeOccurence[indexI, indexJ - 1]);
                }
            }

            return _storeOccurence[aFirst.Length, bSecond.Length];
        }

        private int RecursionMemoizationLcs(string aFirst, string bSecond, int aIndex, int bIndex)
        {
            if (aIndex >= aFirst.Length || bIndex >= bSecond.Length)
                return 0;

            if (_storeOccurence[aIndex, bIndex] != -1)
                return _storeOccurence[aIndex, bIndex];

            if (aFirst[aIndex] == bSecond[bIndex])
            {
                _storeOccurence[aIndex, bIndex] = 1 + RecursionMemoizationLcs(aFirst, bSecond, aIndex + 1, bIndex + 1);
                return _storeOccurence[aIndex, bIndex];
            }

            _storeOccurence[aIndex, bIndex] = Math.Max(RecursionMemoizationLcs(aFirst, bSecond, aIndex + 1, bIndex),
                RecursionMemoizationLcs(aFirst, bSecond, aIndex, bIndex + 1));
            return _storeOccurence[aIndex, bIndex];
        }

        private int RecursionLcs(string aFirst, string bSecond, int aIndex, int bIndex)
        {
            if (aIndex >= aFirst.Length || bIndex >= bSecond.Length)
                return 0;
            if (aFirst[aIndex] == bSecond[bIndex])
                return 1 + RecursionLcs(aFirst, bSecond, aIndex + 1, bIndex + 1);
            
            return Math.Max(RecursionLcs(aFirst, bSecond, aIndex + 1, bIndex),
                RecursionLcs(aFirst, bSecond, aIndex, bIndex + 1));
        }

        #endregion
    }
}