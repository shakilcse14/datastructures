using System;

namespace DataStructures.Core.Sorting.CountingSort
{
    public class CountingSort
    {
        public int[] Sort(int[] array)
        {
            var max = int.MinValue;
            for (var index = 0; index < array.Length; index++)
                max = Math.Max(max, array[index]);

            var countArray = new int[max + 1];
            var outputArray = new int[array.Length];

            for (var index = 0; index < array.Length; index++)
                countArray[array[index]]++;

            for (var index = 1; index < countArray.Length; index++)
                countArray[index] += countArray[index - 1];

            for (var index = 0; index < array.Length; index++)
            {
                outputArray[countArray[array[index]] - 1] = array[index];
                countArray[array[index]]--;
            }

            for (var index = 0; index < array.Length; index++)
                array[index] = outputArray[index];

            return array;
        }
    }
}
