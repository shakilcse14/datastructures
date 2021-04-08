using System;
using System.Collections.Generic;
using System.Linq;
using CrackingTheCodeInterview.ArraysAndStrings;
using CrackingTheCodeInterview.LinkedLists;
using CrackingTheCodeInterview.StacksAndQueues;
using CrackingTheCodeInterview.TreesAndGraphs;

namespace CrackingTheCodingInterView.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestArrayAndStrings();
            //TestLinkedList();
            //TestStacksAndQueues();
            TestTreesAndGraphs();
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
            //var stacksAndQueues = new StacksAndQueues();
            //stacksAndQueues.Push(-2);
            //stacksAndQueues.Push(0);
            //stacksAndQueues.Push(-1);
            //Console.WriteLine(stacksAndQueues.GetMin()); // return -3
            //Console.WriteLine(stacksAndQueues.Top());
            //stacksAndQueues.Pop();    // return 0
            //Console.WriteLine(stacksAndQueues.GetMin()); // return -2
            //var queueUsingStack = new QueueUsingStack();
            //queueUsingStack.Enqueue(1);
            //queueUsingStack.Enqueue(2);
            //queueUsingStack.Enqueue(3);
            //queueUsingStack.Enqueue(4);
            //Console.WriteLine(queueUsingStack.Dequeue());
            //Console.WriteLine(queueUsingStack.Dequeue());
            //queueUsingStack.Enqueue(5);
            //Console.WriteLine(queueUsingStack.Dequeue());

            //var stack = new Stack<int>();
            //stack.Push(5);
            //stack.Push(3);
            //stack.Push(2);
            //stack.Push(4);
            //stack.Push(1);

            //var sortedStack = new SortedStack(stack);
            //Console.WriteLine(sortedStack.Pop());
            //Console.WriteLine(sortedStack.Pop());
            //Console.WriteLine(sortedStack.Pop());
            //Console.WriteLine(sortedStack.Pop());
            //Console.WriteLine(sortedStack.Pop());

            //var animalShelter = new AnimalShelter();
            //animalShelter.Enqueue(1);
            //animalShelter.Enqueue(1);
            //animalShelter.Enqueue(0);
            //animalShelter.Enqueue(1);
            //animalShelter.Enqueue(1);
            //animalShelter.Enqueue(0);

            //Console.WriteLine(animalShelter.DequeueDog().Type);
            //Console.WriteLine(animalShelter.DequeueCat().Type);
        }

        static void TestTreesAndGraphs()
        {
            var treesAndGraphs = new TreesAndGraphs();
            //var adjacencyMatrix = new[,]
            //{
            //    { 0, 1, 0, 1 },
            //    { 1, 0, 1, 0 },
            //    { 0, 1, 0, 0 },
            //    { 1, 0, 0, 0 }
            //};
            //Console.WriteLine(treesAndGraphs.IsRouteBetweenNodesBfs(adjacencyMatrix, 1, 3));
            //Console.WriteLine(treesAndGraphs.IsRouteBetweenNodesDfs(adjacencyMatrix, 1, 3));
            //treesAndGraphs.MinimalTree(new[] {-10, -3, 0, 5, 9});
            var headNode = new TreeNode()
            {
                val = 4
            };
            headNode.left = new TreeNode()
            {
                val = 2,
                parent = headNode
            };
            headNode.left.left = new TreeNode()
            {
                val = 1,
                parent = headNode.left
            };
            var nodeA = headNode.left.right = new TreeNode()
            {
                val = 3,
                parent = headNode.left
            };
            var nodeB = headNode.right = new TreeNode()
            {
                val = 6,
                parent = headNode
            };
            headNode.right.left = new TreeNode()
            {
                val = 5,
                parent = headNode.right
            };
            headNode.right.right = new TreeNode()
            {
                val = 7,
                parent = headNode.right
            };
            //treesAndGraphs.ListOfDepths(headNode);
            //Console.WriteLine(treesAndGraphs.IsBalancedTree(headNode));
            //Console.WriteLine(treesAndGraphs.IsValidBinarySearchTree(headNode));
            //Console.WriteLine(treesAndGraphs.FindSuccessor(headNode.right.left));
            //var adjacencyMatrix = new[,]
            //{
            //    { 0, 0, 0, 0, 0, 0 },
            //    { 0, 0, 0, 0, 0, 0 },
            //    { 0, 0, 0, 1, 0, 0 },
            //    { 0, 1, 0, 0, 0, 0 },
            //    { 1, 1, 0, 0, 0, 0 },
            //    { 1, 0, 1, 0, 0, 0 }
            //};
            //var result = treesAndGraphs.BuildOrderDFS(adjacencyMatrix);
            //var result = treesAndGraphs.BuildOrderBFS(adjacencyMatrix);
            //Console.WriteLine($"{string.Join(",", result)}");
            //treesAndGraphs.LowestCommonAncestorBTWithParent(headNode, nodeA, nodeB);
            //treesAndGraphs.LowestCommonAncestorBTNoParent(headNode, nodeA, nodeB);
            //treesAndGraphs.LowestCommonAncestorBST(headNode, nodeA, nodeB);
            //treesAndGraphs.IsSubTree(new TreeNode()
            //{
            //    val = 3,
            //    left = new TreeNode()
            //    {
            //        val = 4,
            //        left = new TreeNode()
            //        {
            //            val = 1
            //        }
            //    },
            //    right = new TreeNode()
            //    {
            //        val = 5,
            //        left = new TreeNode()
            //        {
            //            val = 2
            //        }
            //    }
            //}, new TreeNode()
            //{
            //    val = 3,
            //    left = new TreeNode()
            //    {
            //        val = 1
            //    },
            //    right = new TreeNode()
            //    {
            //        val = 2
            //    }
            //});
            //treesAndGraphs.ConvertMirror(headNode);
            Console.WriteLine(treesAndGraphs.IsMirror(headNode));
        }
    }
}
