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
    }
}