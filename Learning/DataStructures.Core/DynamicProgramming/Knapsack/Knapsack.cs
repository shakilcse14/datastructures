using System;

namespace DataStructures.Core.DynamicProgramming.Knapsack
{
    public class Knapsack
    {
        private readonly int _maxWeight;
        private readonly int[] _profits;
        private readonly int[] _weights;

        private int[,] _dp;

        public Knapsack(int maxWeight, int[] profits, int[] weights)
        {
            _maxWeight = maxWeight;
            _profits = profits;
            _weights = weights;
        }

        public int FindMaximum(Solution solution)
        {
            switch (solution)
            {
                case Solution.Recursion:
                    return Recursion();
                case Solution.Memoization:
                    return Memoization();
                default:
                    return Tabulation();
            }
        }

        #region Private methods

        /// <summary>
        /// Time complexity O(2^n), Space complexity O(1)
        /// </summary>
        /// <returns></returns>
        private int Recursion()
        {
            var maxProfit = RecursiveKnapsack(_profits, _weights,
                _maxWeight, _profits.Length - 1);
            return maxProfit;
        }

        private int RecursiveKnapsack(int[] profits, int[] weights, int weight, int index)
        {
            if (index < 0 || weight == 0)
                return 0;
            if (weights[index] > weight)
                return RecursiveKnapsack(profits, weights, weight, index - 1);
            else
                return Math.Max(RecursiveKnapsack(profits, weights, weight, index - 1),
                    profits[index] + RecursiveKnapsack(profits, weights, weight - weights[index], index - 1));
        }

        /// <summary>
        /// Time complexity O(W*L), Space complexity O(W*L)
        /// </summary>
        /// <returns></returns>
        private int Memoization()
        {
            _dp = new int[_profits.Length + 1, _maxWeight + 1];
            for (var index = 0; index <= _profits.Length; index++)
            {
                for (var w = 0; w <= _maxWeight; w++)
                {
                    _dp[index, w] = -1;
                }
            }

            return RecursiveKnapsackMemoization(_profits, _weights, _maxWeight, _profits.Length - 1);
        }

        private int RecursiveKnapsackMemoization(int[] profits, int[] weights, int weight, int index)
        {
            if (weight == 0 || index < 0)
                return 0;
            if (_dp[index, weight] != -1)
                return _dp[index, weight];

            if (weights[index] > weight)
            {
                _dp[index, weight] = RecursiveKnapsackMemoization(profits, weights, weight, index - 1);
                return _dp[index, weight];
            }
            else
            {
                _dp[index, weight] = Math.Max(
                    profits[index] +
                    RecursiveKnapsackMemoization(profits, weights, weight - weights[index], index - 1),
                    RecursiveKnapsackMemoization(profits, weights, weight, index - 1));
                return _dp[index, weight];
            }
        }

        /// <summary>
        /// Time complexity O(W*L), Space complexity O(W*L)
        /// </summary>
        /// <returns></returns>
        private int Tabulation()
        {
            _dp = new int[_profits.Length, _maxWeight + 1];
            // populate the weight = 0 columns, we have '0' profit because weight is zero
            for (var index = 0; index < _profits.Length; index++)
                _dp[index, 0] = 0;

            // if we have only one weight, we will take it if it is not more than the capacity
            for (var w = 0; w <= _maxWeight; w++)
            {
                if (_weights[0] <= w)
                    _dp[0, w] = _profits[0];
            }

            for (var index = 1; index < _profits.Length; index++)
            {
                for (var w = 1; w <= _maxWeight; w++)
                {
                    if (_weights[index] <= w)
                    {
                        _dp[index, w] = Math.Max(
                            _profits[index] + _dp[index - 1, w - _weights[index]],
                            _dp[index - 1, w]);
                    }
                    else
                    {
                        _dp[index, w] = _dp[index - 1, w];
                    }
                }
            }

            return _dp[_profits.Length - 1, _maxWeight];
        }

        #endregion
    }

    public enum Solution
    {
        Recursion,
        Memoization,
        Tabulation
    }
}