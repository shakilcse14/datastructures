namespace DataStructures.Core.NumberTheory.GCD
{
    /// <summary>
    /// Greatest/Largest common divisor between numbers
    /// </summary>
    public class GCD
    {
        public GCD() { }

        public int GetGcd(int aFirst, int bSecond)
        {
            return LoopGcd(aFirst, bSecond);
            //return RecursionGcd(aFirst, bSecond);
        }

        #region Private methods

        private int RecursionGcd(int aFirst, int bSecond)
        {
            if (bSecond == 0)
                return aFirst;
            return RecursionGcd(bSecond, aFirst % bSecond);
        }

        private int LoopGcd(int aFirst, int bSecond)
        {
            var gcd = 1;
            for (var index = 2; index <= aFirst && index <= bSecond; index++)
            {
                if ((aFirst % index) == 0 && (bSecond % index) == 0)
                    gcd = index;
            }

            return gcd;
        }

        #endregion
    }
}