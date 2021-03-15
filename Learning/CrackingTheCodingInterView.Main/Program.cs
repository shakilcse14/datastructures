using System;
using System.Linq;
using CrackingTheCodeInterview.ArraysAndStrings;
using CrackingTheCodeInterview.LinkedLists;
using CrackingTheCodeInterview.StacksAndQueues;

namespace CrackingTheCodingInterView.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestArrayAndStrings();
            //TestLinkedList();
            TestStacksAndQueues();
        }

        static void TestLinkedList()
        {
            var linkedLists = new LinkedLists();
            //var headNode = new ListNode()
            //{
            //    Data = "1",
            //    Next = new ListNode()
            //    {
            //        Data = "4",
            //        Next = new ListNode()
            //        {
            //            Data = "1",
            //            Next = new ListNode()
            //            {
            //                Data = "4",
            //                Next = new ListNode()
            //                {
            //                    Data = "4",
            //                    Next = null
            //                }
            //            }
            //        }
            //    }
            //};
            //linkedLists.RemoveDuplicatesFromUnSorted(headNode);
            //var toDelete = new ListNode()
            //{
            //    Data = "5",
            //    Next = new ListNode()
            //    {
            //        Data = "3",
            //        Next = new ListNode()
            //        {
            //            Data = "2",
            //            Next = null
            //        }
            //    }
            //};
            //var headNode = new ListNode()
            //{
            //    Data = "4",
            //    Next = new ListNode()
            //    {
            //        Data = "1",
            //        Next = new ListNode()
            //        {
            //            Data = "6",
            //            Next = toDelete
            //        }
            //    }
            //};

            //Console.WriteLine(linkedLists.ReturnKthLastElement(headNode, 2));
            //linkedLists.DeleteMiddleNode(toDelete);
            //linkedLists.Partition(headNode, 2);
            //linkedLists.AddTwoNumbersReverseOrder(new ListNode()
            //{
            //    Data = "9",
            //    Next = new ListNode()
            //    {
            //        Data = "8",
            //        Next = new ListNode()
            //        {
            //            Data = "9",
            //            Next = null
            //        }
            //    }
            //}, new ListNode()
            //{
            //    Data = "5",
            //    Next = new ListNode()
            //    {
            //        Data = "7",
            //        Next = new ListNode()
            //        {
            //            Data = "6",
            //            Next = null
            //        }
            //    }
            //});
            //linkedLists.AddTwoNumbersNonReverseOrder(new ListNode()
            //{
            //    Data = "3",
            //    Next = new ListNode()
            //    {
            //        Data = "4",
            //        Next = new ListNode()
            //        {
            //            Data = "2",
            //            Next = null
            //        }
            //    }
            //}, new ListNode()
            //{
            //    Data = "4",
            //    Next = new ListNode()
            //    {
            //        Data = "6",
            //        Next = new ListNode()
            //        {
            //            Data = "5",
            //            Next = null
            //        }
            //    }
            //});

            //linkedLists.ReverseLinkedList(new ListNode()
            //{
            //    Data = "3",
            //    Next = new ListNode()
            //    {
            //        Data = "4",
            //        Next = new ListNode()
            //        {
            //            Data = "2",
            //            Next = null
            //        }
            //    }
            //});

            //linkedLists.FindMiddleNode(new ListNode()
            //{
            //    Data = "m",
            //    Next = new ListNode()
            //    {
            //        Data = "a",
            //        Next = new ListNode()
            //        {
            //            Data = "d",
            //            Next = new ListNode()
            //            {
            //                Data = "a",
            //                Next = new ListNode()
            //                {
            //                    Data = "m",
            //                    Next = null
            //                }
            //            }
            //        }
            //    }
            //});

            //var isPalindrome = linkedLists.IsPalindrome(new ListNode()
            //{
            //    Data = "a",
            //    Next = new ListNode()
            //    {
            //        Data = "b",
            //        Next = new ListNode()
            //        {
            //            Data = "b",
            //            Next = new ListNode()
            //            {
            //                Data = "a",
            //                Next = null
            //            }
            //        }
            //    }
            //});
            //Console.WriteLine($"{isPalindrome}");

            //var headNodeS = new ListNode()
            //{
            //    Data = "4",
            //    Next = new ListNode()
            //    {
            //        Data = "1",
            //        Next = toDelete
            //    }
            //};
            //linkedLists.IntersectionTwoLists(headNode, headNodeS);

            //var nodeF = new ListNode()
            //{
            //    Data = "3",
            //    Next = null
            //};
            //var nodeS = new ListNode()
            //{
            //    Data = "5",
            //    Next = new ListNode()
            //    {
            //        Data = "6",
            //        Next = nodeF
            //    }
            //};
            //nodeF.Next = nodeS;

            //var headNodeS = new ListNode()
            //{
            //    Data = "3",
            //    Next = nodeS
            //};
            //linkedLists.CycleStartingNode(headNodeS);
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

            //arraysAndStrings.ZeroMatrix(new[]
            //{
            //    new[] {0, 1, 2, 0},
            //    new[] {3, 4, 5, 2},
            //    new[] {1, 3, 1, 5}
            //});
        }

        static void TestStacksAndQueues()
        {
            var stacksAndQueues = new StacksAndQueues();
            stacksAndQueues.Push(-2);
            stacksAndQueues.Push(0);
            stacksAndQueues.Push(-1);
            Console.WriteLine(stacksAndQueues.GetMin()); // return -3
            Console.WriteLine(stacksAndQueues.Top());
            stacksAndQueues.Pop();    // return 0
            Console.WriteLine(stacksAndQueues.GetMin()); // return -2
        }
    }
}
