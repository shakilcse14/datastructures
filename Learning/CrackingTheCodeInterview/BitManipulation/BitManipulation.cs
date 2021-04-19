using System;
using System.Text;

namespace CrackingTheCodeInterview.BitManipulation
{
    public class BitManipulation
    {
        public int Insertion(int to, int from, int posStart, int posEnd)
        {
            var startSide = ~0 << (posStart + 1);
            var endSide = (1 << posEnd) - 1;
            var mask = startSide | endSide;

            var fromShift = from << posEnd;
            var toClear = to & mask;
            var result = toClear | fromShift;

            return result;
        }

        public string BinaryToString(double value)
        {
            if (value >= 1 || value <= 0)
                return "ERROR";

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(".");
            while (value > 0)
            {
                if (stringBuilder.Length > 32)
                    return "ERROR";
                value = value * 2;
                if (value >= 1)
                {
                    stringBuilder.Append("1");
                    value -= 1;
                }
                else
                {
                    stringBuilder.Append("0");
                }
            }

            return stringBuilder.ToString();
        }

        public int FlipBitToWin(int number)
        {
            var previousLength = 0;
            var currentLength = 0;
            var maxLength = 0;

            while (number != 0)
            {
                if ((number & 1) != 0)
                    currentLength++;
                else
                {
                    previousLength = currentLength;
                    currentLength = 0;
                }

                maxLength = Math.Max(previousLength + currentLength + 1, maxLength);
                number = (int) ((uint) number >> 1);
            }

            return maxLength;
        }

        public int NextNumberLargest(int number)
        {
            var countOne = 0;
            var countZero = 0;
            var tempNumber = number;
            while ((tempNumber & 1) == 0 && tempNumber != 0)
            {
                countZero++;
                tempNumber = (int) ((uint) tempNumber >> 1);
            }

            while ((tempNumber & 1) != 0)
            {
                countOne++;
                tempNumber = (int) ((uint) tempNumber >> 1);
            }

            var position = countZero + countOne;
            if (position == 31 || position == 0)
                return -1;

            number |= (1 << position);
            number &= ~((1 << position) - 1);
            number |= ((1 << (countOne - 1)) - 1);

            return number;
        }

        public int NextNumberSmallest(int number)
        {
            var countOne = 0;
            var countZero = 0;
            var tempNumber = number;

            while ((tempNumber & 1) != 0)
            {
                countOne++;
                tempNumber >>= 1;
            }

            if (tempNumber == 0)
                return -1;

            while ((tempNumber & 1) == 0 && tempNumber != 0)
            {
                countZero++;
                tempNumber >>= 1;
            }

            var position = countOne + countZero;
            number &= ((~0) << (position + 1));
            var one = (1 << (countOne + 1)) - 1;
            number |= (one << (countZero - 1));

            return number;
        }

        public int ConversionBit(int numberFrom, int numberTo)
        {
            var result = numberFrom ^ numberTo;
            var count = 0;
            while (result != 0)
            {
                count++;
                result &= (result - 1);
            }

            return count;
        }

        public int PairwiseSwap(int number)
        {
            return ((int) (number & 0xaaaaaaaa) << 1) | ((int) ((uint) (number & 0x55555555)) >> 1);
        }

        public bool IsPowerOfTwo(int number)
        {
            return (number & (number - 1)) == 0;
        }

        public bool IsPowerOfFour(int number)
        {
            return (number & (number - 1)) == 0 && (number & 0x55) != 0;
        }

        public int SumOfTwoIntegers(int numberA, int numberB)
        {
            return Sum(numberA, numberB);
        }

        public int MissingNumber(int[] numbers)
        {
            var result = numbers.Length;
            for (var index = 0; index < numbers.Length; index++)
                result ^= index ^ numbers[index];

            return result;
        }

        public int LargestPowerOfTwo(int number)
        {
            var power = 0;
            while (1 << power <= number)
                power++;

            return 1 << power - 1;
        }

        public uint ReverseBit(uint number)
        {
            uint result = 0;
            uint mask = 1;
            for (var i = 0; i < 32; i++)
            {
                result <<= 1;
                if ((mask & number) != 0)
                    result |= 1;
                mask <<= 1;
            }

            return result;
        }

        public int BitWiseAndNumbers(int start, int end)
        {
            var count = 0;
            while (start != end)
            {
                start >>= 1;
                end >>= 1;
                count++;
            }

            return start << count;
        }

        public int CountBitOne(int number)
        {
            var count = 0;
            while (number != 0)
            {
                if ((number & 1) == 1)
                    count++;
                number &= (number - 1);
            }

            return count;
        }

        #region Private Methods

        private int Sum(int numberA, int numberB)
        {
            var xor = numberA ^ numberB;
            var carry = numberA & numberB;
            carry <<= 1;

            return carry == 0 ? xor : Sum(xor, carry);
        }

        #endregion
    }
}