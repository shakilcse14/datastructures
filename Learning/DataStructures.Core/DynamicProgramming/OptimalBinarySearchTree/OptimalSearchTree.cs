namespace DataStructures.Core.DynamicProgramming.OptimalBinarySearchTree
{
    public class OptimalSearchTree
    {
        private readonly int[] _keys;
        private readonly int[] _freqencies;
        private readonly int[,] _cost;

        public OptimalSearchTree(int[] keys, int[] freqencies)
        {
            _keys = keys;
            _freqencies = freqencies;
            _cost = new int[_keys.Length, _keys.Length];
        }

        public int FindCost()
        {
            return TabulationOST();
            //return RecursionOST(0, _freqencies.Length - 1);
            //return RecursionMemoizationOST(0, _freqencies.Length - 1);
        }

        #region Private methods

        /// <summary>
        /// Time complexity O(n^4)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private int RecursionMemoizationOST(int start, int end)
        {
            if (end < start) return 0;

            if (_cost[start, end] != 0)
                return _cost[start, end];

            if (end == start)
            {
                _cost[start, end] = _freqencies[start];
                return _cost[start, end];
            }

            var min = int.MaxValue;
            for (var inx = start; inx <= end; inx++)
            {
                var calculatedMin = RecursionMemoizationOST(start, inx - 1) +
                                    RecursionMemoizationOST(inx + 1, end);
                if (min > calculatedMin)
                    min = calculatedMin;
            }

            _cost[start, end] = FrequencySum(start, end) + min;
            return _cost[start, end];
        }

        /// <summary>
        /// Time complexity exponential
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private int RecursionOST(int start, int end)
        {
            if (end < start) return 0;
            if (end == start) return _freqencies[start];

            var min = int.MaxValue;
            for (var inx = start; inx <= end; inx++)
            {
                var calculatedMin = RecursionOST(start, inx - 1) +
                                    RecursionOST(inx + 1, end);
                if (min > calculatedMin)
                    min = calculatedMin;
            }

            return FrequencySum(start, end) + min;
        }

        private int TabulationOST()
        {
            var prefixSum = new int[_freqencies.Length];
            prefixSum[0] = _freqencies[0];
            for (var index = 1; index < _freqencies.Length; index++)
            {
                prefixSum[index] = prefixSum[index - 1] + _freqencies[index];
            }

            for (var index = 0; index < _freqencies.Length; index++)
            {
                _cost[index, index] = _freqencies[index];
            }

            for (var len = 2; len <= _freqencies.Length; len++)
            {
                for (var indexI = 0; indexI < _freqencies.Length - len + 1; indexI++)
                {
                    var indexJ = indexI + len - 1;

                    var min = int.MaxValue;
                    //Console.Write($"{indexI},{indexJ} --->> ");
                    for (var indexK = indexI; indexK <= indexJ; indexK++)
                    {
                        var calculatedValue =
                            (indexK > indexI ? _cost[indexI, indexK - 1] : 0) +
                            (indexK < indexJ ? _cost[indexK + 1, indexJ] : 0);
                        if (min > calculatedValue)
                            min = calculatedValue;
                        //Console.Write($"{indexK - 1} vs {indexK + 1} \t");
                    }

                    _cost[indexI, indexJ] = (indexI <= 0 ? prefixSum[indexJ] : 
                                                prefixSum[indexI] - prefixSum[indexI - 1] + prefixSum[indexJ] - prefixSum[indexJ - 1]) + min;

                    //Console.Write("\n");
                }

                //Console.WriteLine("\n");
            }

            return _cost[0, _freqencies.Length - 1];
        }

        private int FrequencySum(int indexI, int indexJ)
        {
            var sum = 0;
            for (var index = indexI; index <= indexJ; index++)
            {
                sum += _freqencies[index];
            }

            return sum;
        }

        #endregion
    }
}