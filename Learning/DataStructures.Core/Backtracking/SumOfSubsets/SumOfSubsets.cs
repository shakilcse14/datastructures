using System;
using System.Linq;

namespace DataStructures.Core.Backtracking.SumOfSubsets
{
    public class SumOfSubsets
    {
        private readonly int[] _subsets;
        private readonly int _goalSum;

        public SumOfSubsets(int goalSum, int[] subsets)
        {
            _subsets = subsets;
            _goalSum = goalSum;
        }

        public void FindAll()
        {
            var taken = new int[_subsets.Length];
            for (var index = 0; index < taken.Length; index++)
            {
                taken[index] = -1;
            }

            SubsetsSum(0, 0, _subsets.Sum(), taken);
        }

        #region Private methods

        private void SubsetsSum(int index, int total, int remaining, int[] taken)
        {
            if (total == _goalSum)
            {
                Console.WriteLine($"{string.Join(", ", taken)}");
                return;
            }

            if(remaining == 0)
                return;

            if (total + _subsets[index] <= _goalSum)
            {
                taken[index] = 1;
                SubsetsSum(index + 1, total + _subsets[index], remaining - _subsets[index], taken);
            }

            if (total + remaining >= _goalSum)
            {
                taken[index] = 0;
                SubsetsSum(index + 1, total, remaining - _subsets[index], taken);
            }
        }

        #endregion
    }
}