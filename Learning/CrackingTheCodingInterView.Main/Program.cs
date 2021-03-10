using System;
using System.Linq;
using CrackingTheCodeInterview.ArraysAndStrings;

namespace CrackingTheCodingInterView.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            TestArrayAndStrings();
        }

        static void TestArrayAndStrings()
        {
            var arraysAndStrings = new ArraysAndStrings();

            /*var value = "GEeks";
            Console.WriteLine($"{value} = {arraysAndStrings.IsUnique(value)}");*/

            //Console.WriteLine($"{arraysAndStrings.IsPermutation("test", "tste")}");

            /*var str = arraysAndStrings.Urlify("Mr John Smith   ", 13);
            foreach (var chr in str)
            {
                Console.Write($"{chr}");
            }*/

            //Console.WriteLine(arraysAndStrings.IsPermutationPalindrome("Tact Coa"));

            //Console.WriteLine(arraysAndStrings.IsOneAway("pale", "ple"));
            //Console.WriteLine(arraysAndStrings.IsOneAway("pales", "pale"));
            //Console.WriteLine(arraysAndStrings.IsOneAway("pale", "bale"));
            //Console.WriteLine(arraysAndStrings.IsOneAway("pale", "bake"));
            //Console.WriteLine(arraysAndStrings.IsOneAway("pale", "peal"));

            //Console.WriteLine(arraysAndStrings.StringCompression("aabcccccaaa"));
            //Console.WriteLine(arraysAndStrings.StringRotation("waterbottle", "erbottlewat"));
            //arraysAndStrings.RotateMatrix(new[]
            //{
            //    new[] {5, 1, 9, 11},
            //    new[] {2, 4, 8, 10},
            //    new[] {13, 3, 6, 7},
            //    new[] {15, 14, 12, 16}
            //});

            arraysAndStrings.ZeroMatrix(new[]
            {
                new[] {0, 1, 2, 0},
                new[] {3, 4, 5, 2},
                new[] {1, 3, 1, 5}
            });
        }
    }
}
