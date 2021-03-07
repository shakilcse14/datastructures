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
            Console.WriteLine(arraysAndStrings.StringRotation("waterbottle", "erbottlewat"));
        }
    }
}
