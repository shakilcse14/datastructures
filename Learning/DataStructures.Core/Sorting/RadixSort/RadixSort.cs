using System;

namespace DataStructures.Core.Sorting.RadixSort
{
    public class RadixSort
    {
        public int[] Sort(int[] array)
        {
            var max = int.MinValue;
            for (var index = 0; index < array.Length; index++)
                max = Math.Max(max, array[index]);

            for (var exp = 1; max / exp > 0; exp *= 10)
                array = CountingSort(array, exp);

            return array;
        }

        #region Private Methods

        private int[] CountingSort(int[] array, int exp)
        {
            var countArray = new int[10];
            var outputArray = new int[array.Length];

            for (var index = 0; index < array.Length; index++)
                countArray[(array[index] / exp) % 10]++;

            for (var index = 1; index < countArray.Length; index++)
                countArray[index] += countArray[index - 1];

            for(var index = array.Length - 1; index >= 0; index--)
            {
                outputArray[countArray[(array[index] / exp) % 10] - 1] = array[index];
                countArray[(array[index] / exp) % 10]--;
            }

            for(var index = 0; index < array.Length; index++)
                array[index] = outputArray[index];

            return array;
        }

        #endregion
    }
}
