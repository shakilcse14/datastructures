using System.Collections.Generic;

namespace DataStructures.Core.DynamicProgramming.Fibonacci
{
    public class Fibonacci
    {
        private int[] _fibNumbers;

        public Fibonacci() { }

        public IEnumerable<int> GetFibonacciNumbers(int total)
        {
            _fibNumbers = new int[total + 1];
            for (var index = 0; index < _fibNumbers.Length; index++)
            {
                _fibNumbers[index] = -1;
            }

            //IterativeAprroach(total);

            Fibo(total);

            return _fibNumbers;
        }


        #region Private Methods

        private int Fibo(int number)
        {
            if (_fibNumbers[number] != -1)
                return _fibNumbers[number];
            if (number <= 1)
            {
                _fibNumbers[number] = number;
                return _fibNumbers[number];
            }
            _fibNumbers[number] = Fibo(number - 1) + Fibo(number - 2);
            return _fibNumbers[number];
        }

        private void IterativeAprroach(int total)
        {
            var aFirst = 0;
            var bSecond = 1;
            _fibNumbers[0] = aFirst;
            _fibNumbers[1] = bSecond;
            for (var index = 2; index <= total; index++)
            {
                var result = aFirst + bSecond;
                aFirst = bSecond;
                bSecond = result;

                _fibNumbers[index] = result;
            }
        }

        #endregion
    }
}