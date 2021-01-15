namespace DataStructures.Core.NumberTheory.LCM
{
    /// <summary>
    /// Least common multiplier, smallest number that divides by two numbers
    /// </summary>
    public class LCM
    {
        public LCM() { }

        public int GetLcm(int aFirst, int bSecond)
        {
            return LoopLcm(aFirst, bSecond);
            //return (aFirst * bSecond) / (new GCD.GCD().GetGcd(aFirst, bSecond));
        }

        #region Private methods

        private int LoopLcm(int aFirst, int bSecond)
        {
            for (var index = 1; index <= aFirst; index++)
            {
                if ((aFirst * index) == (bSecond * index))
                    return (aFirst * index);
            }

            return (aFirst * bSecond);
        }

        #endregion
    }
}