namespace DataStructures.Core.Bits
{
    public class BitsBasic
    {
        public BitsBasic() { }

        public int GetBit(int number, int position)
        {
            var leftShiftNumber = 1 << position;

            // position bit 1 if result is not zero, else position bit is 0
            return (number & leftShiftNumber) == 0 ? 0 : 1;
        }

        public int SetBit(int number, int position)
        {
            var leftShiftNumber = 1 << position;

            // position bit will be set to 1 even if position bit is 0 or 1
            return number | leftShiftNumber;
        }

        public int ClearBit(int number, int position)
        {
            var leftShiftNumber = 1 << position;

            // position bit will be cleared by negating leftShiftNumber with arithmetic &
            return number & ~leftShiftNumber;
        }

        public int ToggleBit(int number, int position)
        {
            var leftShiftNumber = 1 << position;

            // toggle bit 1 to 0, 0 to 1
            return number ^ leftShiftNumber;
        }

        public int ChangeBit(int number, int position, int bit)
        {
            var leftShiftNumber = 1 << position;
            
            return (number & ~leftShiftNumber) | ((bit << position) & leftShiftNumber);
        }

        public int CountSetBits(int number)
        {
            //var count = NaiveCountSetBits(number);
            var count = 0;

            while (number > 0)
            {
                count++;
                number &= (number - 1);
            }

            return count;
        }

        private static int NaiveCountSetBits(int number)
        {
            var count = 0;
            while (number > 0)
            {
                if ((number & 1) == 1)
                    count++;
                number = number >> 1;
            }

            return count;
        }
    }
}