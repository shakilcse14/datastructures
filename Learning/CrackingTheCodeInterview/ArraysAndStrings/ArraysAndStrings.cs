﻿using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.ArraysAndStrings
{
    public class ArraysAndStrings
    {
        public ArraysAndStrings() { }

        public bool IsUnique(string value)
        {
            return IsUniqueBitWise(value);
            //return IsUniqueSortApproach(value);
        }

        public bool IsPermutation(string firstString, string secondString)
        {
            return IsPermutationCountApproach(firstString, secondString);
            //return IsPermutationSortApproach(firstString, secondString);
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="firstString"></param>
        /// <param name="secondString"></param>
        /// <returns></returns>
        public bool IsOneAway(string firstString, string secondString)
        {
            var firstStringCharArray = firstString.ToCharArray();
            var secondStringCharArray = secondString.ToCharArray();

            if (Math.Abs(firstStringCharArray.Length - secondStringCharArray.Length) > 1)
                return false;

            var fIndex = firstStringCharArray.Length - 1;
            var sIndex = secondStringCharArray.Length - 1;
            var oneEditOccured = false;
            while (fIndex >= 0 || sIndex >= 0)
            {
                if (firstStringCharArray[fIndex] == secondStringCharArray[sIndex])
                {
                    fIndex -= 1;
                    sIndex -= 1;
                }
                else
                {
                    if (oneEditOccured)
                        return false;

                    if (firstStringCharArray.Length == secondStringCharArray.Length)
                    {
                        // Replace best option
                        fIndex -= 1;
                        sIndex -= 1;
                        oneEditOccured = true;
                    }
                    else if (firstStringCharArray.Length > secondStringCharArray.Length)
                    {
                        // Delete best option
                        fIndex -= 1;
                        oneEditOccured = true;
                    }
                    else
                    {
                        // Delete best option
                        sIndex -= 1;
                        oneEditOccured = true;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsPermutationPalindrome(string value)
        {
            var charArray = value.ToLower().ToCharArray();
            var dictionaryCharArray = new Dictionary<char, int>();
            foreach (var chr in charArray)
            {
                if (!dictionaryCharArray.ContainsKey(chr))
                    dictionaryCharArray.Add(chr, 1);
                else
                    dictionaryCharArray[chr]++;
            }

            var oddCount = 0;
            foreach (var key in dictionaryCharArray.Keys)
            {
                if (dictionaryCharArray[key] % 2 != 0)
                    oddCount++;
                if (oddCount > 1)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public char[] Urlify(string value, int length)
        {
            var charArray = value.ToCharArray();

            var totalSpaces = 0;
            var index = 0;
            for (index = 0; index < charArray.Length; index++)
            {
                if (charArray[index].Equals(' '))
                    totalSpaces++;
            }

            while (charArray[index - 1] == ' ')
            {
                totalSpaces--;
                index--;
            }

            var newLength = length + (totalSpaces * 2);


            var newCharArray = new char[newLength];
            var oldIndex = 0;
            for (index = 0; index < newLength; index++)
            {
                if (charArray[oldIndex] == ' ')
                {
                    newCharArray[index] = '%';
                    newCharArray[index + 1] = '2';
                    newCharArray[index + 2] = '0';
                    index += 2;
                }
                else
                    newCharArray[index] = charArray[oldIndex];

                oldIndex++;
            }

            return newCharArray;
        }

        #region Private Methods

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="firstString"></param>
        /// <param name="secondString"></param>
        /// <returns></returns>
        private bool IsPermutationCountApproach(string firstString, string secondString)
        {
            var firstStringChars = firstString.ToCharArray();
            var secondStringChars = secondString.ToCharArray();

            if (firstStringChars.Length != secondStringChars.Length)
                return false;

            var dictionaryChars = new Dictionary<char, int>();
            for (var index = 0; index < firstStringChars.Length; index++)
            {
                if (dictionaryChars.ContainsKey(firstStringChars[index]))
                    dictionaryChars[firstStringChars[index]]++;
                else
                    dictionaryChars.Add(firstStringChars[index], 1);
                if (dictionaryChars.ContainsKey(secondStringChars[index]))
                    dictionaryChars[secondStringChars[index]]++;
                else
                    dictionaryChars.Add(secondStringChars[index], 1);
            }

            foreach (var chr in firstStringChars)
            {
                if (dictionaryChars[chr] % 2 != 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Time complexity O(nlogn)
        /// </summary>
        /// <param name="firstString"></param>
        /// <param name="secondString"></param>
        /// <returns></returns>
        private bool IsPermutationSortApproach(string firstString, string secondString)
        {
            var firstStringChars = firstString.ToCharArray();
            var secondStringChars = secondString.ToCharArray();

            if (firstStringChars.Length != secondStringChars.Length)
                return false;

            Array.Sort(firstStringChars);
            Array.Sort(secondStringChars);

            for (var index = 0; index < firstStringChars.Length; index++)
            {
                if (!firstStringChars[index].Equals(secondStringChars[index]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Time complexity O(nlogn)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsUniqueSortApproach(string value)
        {
            var charValue = value.ToCharArray();
            Array.Sort(charValue);
            for (var index = 1; index < charValue.Length; index++)
            {
                if (charValue[index].Equals(charValue[index - 1]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsUniqueBitWise(string value)
        {
            var charValue = value.ToCharArray();
            var checkerLower = 0;
            var checkerUpper = 0;
            foreach (var chr in charValue)
            {
                var intValue = 0;
                if (chr >= 'a' && chr <= 'z')
                {
                    intValue = chr - 'a';
                    if ((checkerLower & (1 << intValue)) > 0)
                        return false;
                    checkerLower |= (1 << intValue);
                }
                else if (chr >= 'A' && chr <= 'Z')
                {
                    intValue = chr - 'A';
                    if ((checkerUpper & (1 << intValue)) > 0)
                        return false;
                    checkerUpper |= (1 << intValue);
                }
            }

            return true;
        }

        #endregion
    }
}