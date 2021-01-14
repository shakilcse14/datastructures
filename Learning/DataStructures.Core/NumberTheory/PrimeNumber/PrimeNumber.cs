using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Core.NumberTheory.PrimeNumber
{
    public class PrimeNumber
    {
        public PrimeNumber() { }

        /// <summary>
        /// Time complexity O(sqrt(n)) -->> O(n)
        /// </summary>
        /// <returns></returns>
        public bool IsPrime(int number)
        {
            if (number < 2) return false;

            for (var value = 2; value <= Math.Sqrt(number); value++)
            {
                if (number % value == 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Sieve of Eratosthenes. Time complexity O(nLog(Log(n)))
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetPrimeNumbers(int number)
        {
            var primeNumbers = new List<int>();
            var numbers = new bool[number + 1];
            for (var indexI = 0; indexI < number + 1; indexI++)
            {
                numbers[indexI] = true;
            }

            numbers[0] = false;
            numbers[1] = false;
            for (var indexI = 2; indexI <= Math.Sqrt(number); indexI++)
            {
                if (!numbers[indexI]) continue;

                for (var indexJ = indexI*indexI; indexJ <= number; indexJ+=indexI)
                {
                    numbers[indexJ] = false;
                }
            }

            for (var indexI = 0; indexI < number; indexI++)
            {
                if(numbers[indexI])
                    primeNumbers.Add(indexI);
            }

            return primeNumbers;
        }
    }
}