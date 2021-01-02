using System;
using System.Collections.Generic;

namespace DataStructures.Core.Greedy.Knapsack
{
    public class Knapsack
    {
        private readonly int _maxWeight;
        private readonly int [] _profits;
        private readonly int [] _weights;
        private readonly Dictionary<int, float> _profitByWeight;
        private readonly float[] _xWeights;

        public Knapsack(int maxWeight, int [] profits, int [] weights)
        {
            _maxWeight = maxWeight;
            _profits = profits;
            _weights = weights;

            _xWeights = new float[_weights.Length];
            _profitByWeight = new Dictionary<int, float>(_weights.Length);
        }

        /// <summary>
        /// Time complexity O(n^2), Space complexity O(n)
        /// </summary>
        /// <returns></returns>
        public float[] FindMaximum()
        {
            if(_profits.Length != _weights.Length)
                throw new InvalidOperationException();
            var currentWeight = 0;
            var totalProfit = 0.0f;

            for (var index = 0; index < _weights.Length; index++)
            {
                _profitByWeight[index] = _profits[index] / (float) _weights[index];
            }

            foreach (var _ in _weights)
            {
                var nextMaxProfitByWeight = float.MinValue;
                var nextMaxProfitByWeightIndex = 0;
                for (var j = 0; j < _weights.Length; j++)
                {
                    if (_profitByWeight[j] > nextMaxProfitByWeight && _xWeights[j] <= 0.0f)
                    {
                        nextMaxProfitByWeight = _profitByWeight[j];
                        nextMaxProfitByWeightIndex = j;
                    }
                }

                if (currentWeight + _weights[nextMaxProfitByWeightIndex] < _maxWeight)
                {
                    _xWeights[nextMaxProfitByWeightIndex] = 1.0f;
                    currentWeight += _weights[nextMaxProfitByWeightIndex];
                    totalProfit += _profits[nextMaxProfitByWeightIndex];
                }
                else
                {
                    _xWeights[nextMaxProfitByWeightIndex] =
                        (_maxWeight - currentWeight) / (float)_weights[nextMaxProfitByWeightIndex];
                    currentWeight = _maxWeight;
                    totalProfit += _xWeights[nextMaxProfitByWeightIndex] * _profits[nextMaxProfitByWeightIndex];
                }

                if (currentWeight == _maxWeight)
                    break;
            }


            return _xWeights;
        }
    }
}