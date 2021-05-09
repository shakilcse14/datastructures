using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CrackingTheCodeInterview.RecursionAndDynamicProgramming
{
    public class RecursionAndDynamicProgramming
    {
        private int[] stepWays;
        private List<string> powerSets;

        public int FindTripleSteps(int totalStep)
        {
            var steps = new[] {1, 2, 3};
            stepWays = new int[totalStep + 1];
            for (var index = 0; index < stepWays.Length; index++)
                stepWays[index] = -1;

            //return TripleStepsRecursive(steps, totalStep);
            return TripleStepsMemoization(steps, totalStep);
        }

        public void RobotInGrid()
        {
            //FindPointsRecursive(5,5);
            FindPointsMemoization(5,5, new List<Point>());
        }

        public int MagicIndex(int[] array)
        {
            //return MagicIndexLinearSearch(array);
            //return MagicIndexBinarySearch(array, 0, array.Length);
            return MagicIndexNotDistinctBinarySearch(array, 0, array.Length);
        }

        public List<string> PowerSet(char[] chars)
        {
            powerSets = new List<string>();
            PowerSetRecursive(0, chars, new List<char>());
            return powerSets;
        }

        public int RecursiveMultiply(int a, int b)
        {
            return RecursiveMultiplyHelper(a > b ? b : a, a > b ? a : b);
        }

        public void TowersOfHanoi(int numberOfDisks)
        {
            MoveDisks(numberOfDisks, "Tower A", "Tower B", "Tower C");
        }

        public void DistinctStringPermutations(string distinctString)
        {
            DistinctPermutations(0, distinctString);
        }

        public void StringPermutations(string distinctString)
        {
            Permutations(0, distinctString);
        }

        public void Parens(int numberOfPairs)
        {
            var result = new List<string>();
            ValidPairs(result, numberOfPairs,numberOfPairs, new char[numberOfPairs*2], 0);
        }

        public int[,] PaintFill(int[,] screen, Point point, int color)
        {
            if (screen[point.Row, point.Column] == color)
                return screen;

            PaintFillDfs(screen, point, screen[point.Row, point.Column], color);
            return screen;
        }

        public int ChangeCoins(int[] coins, int total)
        {
            //return ChangeCoinsRecursiveV1(0, coins, total, string.Empty);
            //return ChangeCoinsRecursiveV2(0, coins, total, string.Empty);
            return ChangeCoinsDp(coins, total);
        }

        #region Private methods

        /// <summary>
        /// Time complexity O(3^n)
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="currentStep"></param>
        /// <returns></returns>
        private int TripleStepsRecursive(int[] steps, int currentStep)
        {
            if (currentStep == 0)
                return 1;
            if (currentStep < 0)
                return 0;

            var ways = 0;
            foreach (var step in steps)
            {
                if (currentStep - step >= 0)
                    ways += TripleStepsRecursive(steps, currentStep - step);
            }

            return ways;
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="currentStep"></param>
        /// <returns></returns>
        private int TripleStepsMemoization(int[] steps, int currentStep)
        {
            if (stepWays[currentStep] != -1)
                return stepWays[currentStep];

            if (currentStep == 0)
                return 1;
            if (currentStep < 0)
                return 0;

            var ways = 0;
            foreach (var step in steps)
            {
                if (currentStep - step >= 0)
                    ways += TripleStepsMemoization(steps, currentStep - step);
            }

            stepWays[currentStep] = ways;

            return stepWays[currentStep];
        }

        /// <summary>
        /// Time complexity O(2^n)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private bool FindPointsRecursive(int row, int column)
        {
            if (row < 0 || column < 0)
                return false;

            if (row == 0 && column == 0)
                return true;

            if (FindPointsRecursive(row - 1, column) || FindPointsRecursive(row, column - 1))
            {
                Console.WriteLine(row + "," + column);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Time complexity O(r*c)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private bool FindPointsMemoization(int row, int column, List<Point> failed)
        {
            if (row < 0 || column < 0)
                return false;

            if (failed.Contains(new Point()
            {
                Row = row,
                Column = column
            }))
                return false;

            if (row == 0 && column == 0)
                return true;

            if (FindPointsMemoization(row - 1, column, failed) || FindPointsMemoization(row, column - 1, failed))
            {
                Console.WriteLine(row + "," + column);
                return true;
            }

            failed.Add(new Point()
            {
                Row = row,
                Column = column
            });

            return false;
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private int MagicIndexLinearSearch(int[] array)
        {
            for (var index = 0; index < array.Length; index++)
            {
                if (array[index] == index)
                    return array[index];
            }

            return -1;
        }

        /// <summary>
        /// Time complexity O(logn)
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int MagicIndexBinarySearch(int[] array, int left, int right)
        {
            if (left > right)
                return -1;

            var mid = (left + right) / 2;
            if (mid == array[mid])
                return array[mid];

            return mid < array[mid]
                ? MagicIndexBinarySearch(array, left, mid - 1)
                : MagicIndexBinarySearch(array, mid + 1, right);
        }

        /// <summary>
        /// Time complexity O(logn)
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int MagicIndexNotDistinctBinarySearch(int[] array, int left, int right)
        {
            if (left > right)
                return -1;

            var mid = (left + right) / 2;
            if (mid == array[mid])
                return array[mid];

            var leftIndex = Math.Min(mid - 1, array[mid]);
            if (leftIndex >= 0)
                return MagicIndexNotDistinctBinarySearch(array, left, leftIndex);

            var rightIndex = Math.Max(mid + 1, array[mid]);
            return MagicIndexNotDistinctBinarySearch(array, rightIndex, right);
        }

        /// <summary>
        /// Time complexity O(2^n)
        /// </summary>
        /// <param name="current"></param>
        /// <param name="chars"></param>
        /// <param name="sets"></param>
        private void PowerSetRecursive(int current, char[] chars, List<char> sets)
        {
            powerSets.Add(string.Join(",", sets));
            for (var index = current; index < chars.Length; index++)
            {
                sets.Add(chars[index]);
                PowerSetRecursive(index + 1, chars, sets);
                sets.RemoveAt(sets.Count - 1);
            }
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="smaller"></param>
        /// <param name="bigger"></param>
        /// <returns></returns>
        private int RecursiveMultiplyHelper(int smaller, int bigger)
        {
            if (smaller <= 0)
                return 0;
            if (smaller == 1)
                return bigger;

            var result = RecursiveMultiplyHelper(smaller / 2, bigger);
            if (smaller % 2 == 0)
                return result + result;
            return result + result + bigger;
        }

        /// <summary>
        /// Time complexity O(2^n)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="origin"></param>
        /// <param name="buffer"></param>
        /// <param name="destination"></param>
        private void MoveDisks(int n, string origin, string buffer, string destination)
        {
            if (n <= 1)
            {
                Console.WriteLine("Move disk 1 from rod " +
                                  origin + " to rod " + destination);
                return;
            }
            MoveDisks(n-1, origin, destination, buffer);
            Console.WriteLine("Move disk " + n + " from rod " +
                              origin + " to rod " + destination);
            MoveDisks(n-1, buffer, origin, destination);
        }
        
        private bool ShouldSwap(char[] str, int start, int current)
        {
            for (var i = start; i < current; i++)
                if (str[i] == str[current])
                    return false;

            return true;
        }

        /// <summary>
        /// Time complexity O(n*n*n!)
        /// </summary>
        /// <param name="current"></param>
        /// <param name="distinctString"></param>
        private void Permutations(int current, string distinctString)
        {
            if (current == distinctString.Length - 1)
            {
                Console.WriteLine(distinctString);
                return;
            }

            for (var index = current; index < distinctString.Length; index++)
            {
                if (!ShouldSwap(distinctString.ToCharArray(), current, index))
                    continue;

                distinctString = Swap(current, index, distinctString);
                Permutations(current + 1, distinctString);
                distinctString = Swap(current, index, distinctString);
            }
        }

        /// <summary>
        /// Time complexity O(n*n!)
        /// </summary>
        /// <param name="current"></param>
        /// <param name="distinctString"></param>
        private void DistinctPermutations(int current, string distinctString)
        {
            if (current == distinctString.Length - 1)
            {
                Console.WriteLine(distinctString);
                return;
            }

            for (var index = current; index < distinctString.Length; index++)
            {
                distinctString = Swap(current, index, distinctString);
                DistinctPermutations(current + 1, distinctString);
                distinctString = Swap(current, index, distinctString);
            }
        }

        private string Swap(int indexSource, int indexTarget, string distinctString)
        {
            var charArray = distinctString.ToCharArray();

            var tempChar = charArray[indexSource];
            charArray[indexSource] = charArray[indexTarget];
            charArray[indexTarget] = tempChar;
            
            return new string(charArray);
        }

        /// <summary>
        /// Time complexity O(2^n)
        /// </summary>
        /// <param name="parens"></param>
        /// <param name="leftCount"></param>
        /// <param name="rightCount"></param>
        /// <param name="chars"></param>
        /// <param name="index"></param>
        private void ValidPairs(List<string> parens, int leftCount, int rightCount, char[] chars, int index)
        {
            if (leftCount < 0 || rightCount < leftCount)
                return;

            if (leftCount == 0 && rightCount == 0)
            {
                parens.Add(new string(chars));
            }
            else
            {
                if (leftCount > 0)
                {
                    chars[index] = '(';
                    ValidPairs(parens, leftCount - 1, rightCount, chars, index + 1);
                }

                if (rightCount > leftCount)
                {
                    chars[index] = ')';
                    ValidPairs(parens, leftCount, rightCount - 1, chars, index + 1);
                }
            }
        }

        /// <summary>
        /// Time complexity O(v+e)
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="point"></param>
        /// <param name="sourceColor"></param>
        /// <param name="targetColor"></param>
        private void PaintFillDfs(int[,] screen, Point point, int sourceColor, int targetColor)
        {
            if(point.Row < 0 || point.Column < 0 || point.Row >= screen.GetLength(0) || point.Column >= screen.GetLength(0))
                return;
            if(screen[point.Row, point.Column] != sourceColor)
                return;

            screen[point.Row, point.Column] = targetColor;

            PaintFillDfs(screen, new Point
            {
                Row = point.Row - 1,
                Column = point.Column
            }, sourceColor, targetColor);
            PaintFillDfs(screen, new Point
            {
                Row = point.Row,
                Column = point.Column - 1
            }, sourceColor, targetColor);
            PaintFillDfs(screen, new Point
            {
                Row = point.Row + 1,
                Column = point.Column
            }, sourceColor, targetColor);
            PaintFillDfs(screen, new Point
            {
                Row = point.Row,
                Column = point.Column + 1
            }, sourceColor, targetColor);
        }
        
        /// <summary>
        /// Time complexity O(n^n)
        /// </summary>
        /// <param name="current"></param>
        /// <param name="coins"></param>
        /// <param name="remainingTotal"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        private int ChangeCoinsRecursiveV2(int current, int[] coins, int remainingTotal, string str)
        {
            if (remainingTotal == 0)
            {
                Console.WriteLine(str);
                return 1;
            }

            if (remainingTotal < 0)
                return 0;

            var ways = 0;
            for (var index = current; index < coins.Length; index++)
            {
                if (coins[index] <= remainingTotal)
                {
                    ways += ChangeCoinsRecursiveV2(index, coins, remainingTotal - coins[index], str + coins[index]);
                }
            }

            return ways;
        }

        /// <summary>
        /// Time complexity O(2^total)
        /// </summary>
        /// <param name="current"></param>
        /// <param name="coins"></param>
        /// <param name="remainingTotal"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        private int ChangeCoinsRecursiveV1(int current, int[] coins, int remainingTotal, string str)
        {
            if (remainingTotal == 0)
            {
                Console.WriteLine(str);
                return 1;
            }

            if (current >= coins.Length)
                return 0;
            if (remainingTotal < 0)
                return 0;

            var ways = 0;
            if (coins[current] <= remainingTotal)
            {
                ways += ChangeCoinsRecursiveV1(current, coins, remainingTotal - coins[current], str + coins[current])
                        +
                        ChangeCoinsRecursiveV1(current + 1, coins, remainingTotal, str);
            }

            return ways;
        }

        /// <summary>
        /// Time complexity O(n^2)
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        private int ChangeCoinsDp(int[] coins, int total)
        {
            var ways = new int[coins.Length + 1, total + 1];
            for (var index = 0; index < ways.GetLength(1); index++)
                ways[0, index] = 0;
            for (var index = 0; index < ways.GetLength(0); index++)
                ways[index, 0] = 1;

            for (var indexI = 1; indexI < ways.GetLength(0); indexI++)
            {
                for (var indexJ = 1; indexJ < ways.GetLength(1); indexJ++)
                {
                    if (coins[indexI - 1] > indexJ)
                    {
                        ways[indexI, indexJ] = ways[indexI - 1, indexJ];
                    }
                    else
                    {
                        ways[indexI, indexJ] = ways[indexI, indexJ - coins[indexI - 1]] +
                                               ways[indexI - 1, indexJ];
                    }
                }
            }

            return ways[ways.GetLength(0) - 1, ways.GetLength(1) - 1];
        }

        #endregion
    }

    public class Point
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }
}