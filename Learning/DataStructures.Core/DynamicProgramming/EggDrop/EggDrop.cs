using System;

namespace DataStructures.Core.DynamicProgramming.EggDrop
{
    public class EggDrop
    {
        private readonly int _totalFloors;
        private readonly int _totalEggs;

        private readonly int[,] _store;

        public EggDrop(int totalFloors, int totalEggs)
        {
            _totalFloors = totalFloors;
            _totalEggs = totalEggs;

            _store = new int[_totalEggs + 1, _totalFloors + 1];
            for (var indexI = 0; indexI <= _totalEggs; indexI++)
            {
                for (var indexJ = 0; indexJ <= _totalFloors; indexJ++)
                {
                    if (indexI == 0 || indexJ == 0)
                    {
                        _store[indexI, indexJ] = 0;
                        continue;
                    }
                    if (indexI == 1)
                    {
                        _store[indexI, indexJ] = indexJ;
                        continue;
                    }

                    _store[indexI, indexJ] = -1;
                }
            }
        }

        public int Find()
        {
            var numberOfTries = 0;
            //numberOfTries = Recursive(_totalEggs, _totalFloors);
            //numberOfTries = RecursiveMemoization(_totalEggs, _totalFloors);
            numberOfTries = DynamicProgramming(_totalEggs, _totalFloors);

            return numberOfTries;
        }

        #region Private methods

        /// <summary>
        /// Time complexity O(exponential)
        /// </summary>
        /// <param name="eggs"></param>
        /// <param name="floors"></param>
        /// <returns></returns>
        private int Recursive(int eggs, int floors)
        {
            if (eggs <= 0)
                return 0;
            if (eggs == 1)
                return floors;
            if (floors <= 1)
                return floors;

            var min = int.MaxValue;
            for (var index = 1; index <= floors; index++)
            {
                var value = Math.Max(Recursive(eggs - 1, index - 1), Recursive(eggs, floors - index));
                if (min > value)
                    min = value;
            }

            return 1 + min;
        }

        private int DynamicProgramming(int eggs, int floors)
        {
            // one egg tries number of floors so skip loop of 1
            for (var indexI = 2; indexI <= eggs; indexI++)
            {
                // one floor tries number of floors so skip loop of 1
                for (var indexJ = 2; indexJ <= floors; indexJ++)
                {
                    _store[indexI, indexJ] = int.MaxValue;
                    for (var indexK = 1; indexK <= indexJ; indexK++)
                    {
                        var value = 1 + Math.Max(_store[indexI, indexJ - indexK],
                                        _store[indexI - 1, indexK - 1]);
                        if (_store[indexI, indexJ] > value)
                            _store[indexI, indexJ] = value;
                    }
                }
            }

            return _store[eggs, floors];
        }

        private int RecursiveMemoization(int eggs, int floors)
        {
            if (_store[eggs, floors] != -1)
                return _store[eggs, floors];

            if (eggs <= 0)
                return 0;
            if (eggs == 1)
                return floors;
            if (floors <= 1)
                return floors;

            var min = int.MaxValue;
            for (var index = 1; index <= floors; index++)
            {
                var value = Math.Max(RecursiveMemoization(eggs - 1, index - 1), RecursiveMemoization(eggs, floors - index));
                if (min > value)
                    min = value;
            }

            _store[eggs, floors] = 1 + min;

            return _store[eggs, floors];
        }

        #endregion
    }
}