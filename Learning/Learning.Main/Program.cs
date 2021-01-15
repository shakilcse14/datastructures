using System;
using DataStructures.Core.ArrayList;
using DataStructures.Core.DynamicProgramming.Knapsack;
using DataStructures.Core.Graphs.BFS;
using DataStructures.Core.Graphs.DFS;
using DataStructures.Core.HashTable;
using DataStructures.Core.Heap;
using DataStructures.Core.LinkedList;
using DataStructures.Core.NumberTheory.GCD;
using DataStructures.Core.NumberTheory.LCM;
using DataStructures.Core.NumberTheory.PrimeNumber;
using DataStructures.Core.Queue;
using DataStructures.Core.Search.BinarySearch;
using DataStructures.Core.Sorting.BubbleSort;
using DataStructures.Core.Sorting.HeapSort;
using DataStructures.Core.Sorting.InsertionSort;
using DataStructures.Core.Sorting.MergeSort;
using DataStructures.Core.Sorting.QuickSort;
using DataStructures.Core.Sorting.SelectionSort;
using DataStructures.Core.Stack;
using DataStructures.Core.Trees.BinarySearchTree;
using DataStructures.Core.Trees.BinaryTree;
using DataStructures.Core.Trees.Contracts;
using DataStructures.Core.Trie;
using Knapsack = DataStructures.Core.Greedy.Knapsack.Knapsack;

namespace Learning.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestArrayList();

            //TestSinglyLinkedList();

            //TestDoublyLinkedList();

            //TestHashTable();

            //TestBinarySearch();

            //TestBubbleSort();

            //TestMergeSort();

            //TestQuickSort();

            //TestCircularLinkedList();

            //TestStack();

            //TestQueue();

            //TestHeap();

            //TestHeapSort();

            //TestBinaryTree();

            //TestBinarySearchTree();

            //TestTries();

            //TestBFS();

            //TestDFS();

            //TestKnapsackGreedy();

            //TestKnapsackDP();

            //TestInsertionSort();

            //TestSelectionSort();

            //TestPrimeNumber();

            //TestGCD();

            TestLCM();

            Console.ReadLine();
        }

        static void TestSinglyLinkedList()
        {
            #region SinglyLinkedList

            var singlyLinkedList = new SinglyLinkedList<string>();
            singlyLinkedList.Add("A1");
            singlyLinkedList.Add("A2");
            singlyLinkedList.Add("A3");
            singlyLinkedList.Add("AM_2", 2);
            singlyLinkedList.AddLast("AL");
            singlyLinkedList.AddFirst("A0");
            foreach (var single in singlyLinkedList)
            {
                Console.WriteLine(single);
            }
            Console.WriteLine("\n");
            singlyLinkedList.Remove(2);
            singlyLinkedList.RemoveLast();
            singlyLinkedList.Remove(2);
            singlyLinkedList.RemoveFirst();
            foreach (var single in singlyLinkedList)
            {
                Console.WriteLine(single);
            }

            Console.WriteLine("\n" + singlyLinkedList.Find(2));
            Console.WriteLine(singlyLinkedList.Find("A3"));
            singlyLinkedList.Remove("A3");

            Console.WriteLine();
            foreach (var single in singlyLinkedList)
            {
                Console.WriteLine(single);
            }

            #endregion
        }

        static void TestDoublyLinkedList()
        {
            #region DoublyLinkedList

            var doublyLinkedList = new DoublyLinkedList<string>();
            doublyLinkedList.Add("A1");
            doublyLinkedList.Add("A2");
            doublyLinkedList.Add("A3");
            doublyLinkedList.Add("AM_2", 2);
            doublyLinkedList.AddLast("AL");
            doublyLinkedList.AddFirst("A0");
            foreach (var single in doublyLinkedList)
            {
                Console.WriteLine(single);
            }
            Console.WriteLine("\n");
            doublyLinkedList.Remove(2);
            doublyLinkedList.RemoveLast();
            doublyLinkedList.Remove(2);
            doublyLinkedList.RemoveFirst();
            foreach (var single in doublyLinkedList)
            {
                Console.WriteLine(single);
            }

            Console.WriteLine("\n" + doublyLinkedList.Find(1));
            Console.WriteLine(doublyLinkedList.Find("A3"));
            doublyLinkedList.Remove("A3");

            Console.WriteLine();
            foreach (var doubly in doublyLinkedList)
            {
                Console.WriteLine(doubly);
            }

            #endregion
        }

        static void TestArrayList()
        {
            #region ArrayList

            Console.WriteLine("!!! Array List !!!");
            var arrayList = new ArrayList<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

            foreach (var number in arrayList)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Removing ..");
            arrayList.Remove(1);
            arrayList.Remove(1);
            arrayList.Remove(1);
            arrayList.Remove(1);
            arrayList.Remove(1);
            arrayList.Remove(1);
            foreach (var number in arrayList)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Adding ..");
            arrayList.Add(1);
            arrayList.Add(5);
            arrayList.Add(7);
            arrayList.Add(10);
            arrayList.Add(36);
            arrayList.Add(21);
            foreach (var number in arrayList)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("Length: " + arrayList.Length);

            #endregion
        }

        static void TestHashTable()
        {
            #region HashTable

            var hashTable = new HashTable<string, int>();
            hashTable.Add("a", 65);
            hashTable.Add("A", 97);
            hashTable.Add("b", 66);
            hashTable.Add("B", 98);

            Console.WriteLine(hashTable.Get("A"));
            Console.WriteLine(hashTable.Get("b"));
            Console.WriteLine(hashTable.Get("B"));
            Console.WriteLine(hashTable.Size);
            hashTable.Remove("B");
            Console.WriteLine(hashTable.Size);
            #endregion
        }

        static void TestBinarySearch()
        {
            #region BinarySearch

            var binarySearch = new BinarySearch<int>(new int[]
            {
                1,2,3,4,5,6,7,8,9,10
            });

            Console.WriteLine(binarySearch.Find(2));
            Console.WriteLine(binarySearch.Find(7));
            Console.WriteLine(binarySearch.Find(52));

            #endregion
        }

        static void TestBubbleSort()
        {
            #region BubbleSort

            var bubbleSort = new BubbleSort<int>(new int[]
            {
                5,1,3,4,2,8,6
            });

            Console.WriteLine(string.Join(',', bubbleSort.Sort()));

            #endregion
        }

        static void TestMergeSort()
        {
            #region MergeSort

            var mergeSort = new MergeSort<int>(new int[]
            {
                5,1,3,4,2,8,6
            });

            Console.WriteLine(string.Join(',', mergeSort.Sort()));

            #endregion
        }

        static void TestQuickSort()
        {
            #region QuickSort

            var quickSort = new QuickSort<int>(new int[]
            {
                5,1,3,4,2,8,6
            });

            Console.WriteLine(string.Join(',', quickSort.Sort()));

            #endregion
        }

        static void TestCircularLinkedList()
        {
            #region CircularLinkedList

            var circularLinkedList = new CircularLinkedList<string>();
            circularLinkedList.Add("A1");
            circularLinkedList.Add("A2");
            circularLinkedList.Add("A3");
            circularLinkedList.Add("AM_2", 2);
            circularLinkedList.AddLast("AL");
            circularLinkedList.AddFirst("A0");
            foreach (var single in circularLinkedList)
            {
                Console.WriteLine(single);
            }
            Console.WriteLine("\n");
            circularLinkedList.Remove(2);
            circularLinkedList.RemoveLast();
            circularLinkedList.Remove(2);
            circularLinkedList.RemoveFirst();
            foreach (var single in circularLinkedList)
            {
                Console.WriteLine(single);
            }

            Console.WriteLine("\n" + circularLinkedList.Find(1));
            Console.WriteLine(circularLinkedList.Find("A3"));
            circularLinkedList.Remove("A3");

            Console.WriteLine();
            foreach (var doubly in circularLinkedList)
            {
                Console.WriteLine(doubly);
            }

            #endregion
        }

        static void TestStack()
        {
            #region Stack

            var stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            
            #endregion
        }

        static void TestQueue()
        {
            #region Queue

            var queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Peek());

            #endregion
        }

        static void TestHeap()
        {
            #region Heap

            var priorityQueue = new PriorityQueue<int>();
            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(1);
            priorityQueue.Enqueue(3);
            priorityQueue.Enqueue(4);
            priorityQueue.Enqueue(2);
            priorityQueue.Enqueue(8);

            foreach (var queue in priorityQueue)
            {
                Console.WriteLine(queue);
            }
            Console.WriteLine("Dequeuing ... ");
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());

            #endregion
        }

        static void TestHeapSort()
        {
            #region HeapSort

            var heapSort = new HeapSort<int>(new int[]
            {
                5,1,3,4,2,8,6
            });

            Console.WriteLine(string.Join(',', heapSort.Sort()));

            #endregion
        }

        static void TestBinaryTree()
        {
            #region BinaryTree

            var binaryTree = new BinaryTree<int>
            {
                ParentNode = new TreeNode<int>()
                {
                    Data = 1,
                    Left = new TreeNode<int>()
                    {
                        Data = 2,
                        Left = new TreeNode<int>()
                        {
                            Data = 4
                        },
                        Right = new TreeNode<int>()
                        {
                            Data = 5
                        }
                    },
                    Right = new TreeNode<int>()
                    {
                        Data = 3
                    }
                }
            };


            Console.WriteLine("PreOrder");
            binaryTree.Traverse(TraverseType.PreOrder);
            Console.WriteLine("InOrder");
            binaryTree.Traverse(TraverseType.InOrder);
            Console.WriteLine("PostOrder");
            binaryTree.Traverse(TraverseType.PostOrder);

            #endregion
        }

        static void TestBinarySearchTree()
        {
            #region BinarySearch

            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Insert(5);
            binarySearchTree.Insert(1);
            binarySearchTree.Insert(3);
            binarySearchTree.Insert(4);
            binarySearchTree.Insert(2);
            binarySearchTree.Insert(8);

            Console.WriteLine(binarySearchTree.Contains(2));
            Console.WriteLine(binarySearchTree.Contains(12));

            Console.WriteLine("PreOrder");
            binarySearchTree.Traverse(TraverseType.PreOrder);
            Console.WriteLine("InOrder");
            binarySearchTree.Traverse(TraverseType.InOrder);
            Console.WriteLine("PostOrder");
            binarySearchTree.Traverse(TraverseType.PostOrder);

            Console.WriteLine("Deleting 4 ..");
            binarySearchTree.Remove(4);
            Console.WriteLine("InOrder");
            binarySearchTree.Traverse(TraverseType.InOrder);
            Console.WriteLine("Deleting 3 ..");
            binarySearchTree.Remove(3);
            Console.WriteLine("InOrder");
            binarySearchTree.Traverse(TraverseType.InOrder);
            Console.WriteLine("Deleting 5 ..");
            binarySearchTree.Remove(5);
            Console.WriteLine("InOrder");
            binarySearchTree.Traverse(TraverseType.InOrder);
            #endregion
        }

        static void TestTries()
        {
            #region Tries

            var tries = new Trie();
            tries.Insert("te");
            tries.Insert("ten");
            tries.Insert("tents");
            tries.Insert("tena");
            Console.WriteLine("tents: " + tries.Search("tents"));
            tries.Delete("tents");
            Console.WriteLine("tents: " + tries.Search("tents"));

            //tries.Insert("Card");
            //tries.Insert("Cards");
            //tries.Insert("Calendar");
            //tries.Insert("not");
            //tries.Insert("a");
            //tries.Insert("same");
            //tries.Insert("thing");

            //Console.WriteLine("Calendar: " + tries.Search("Calendar"));
            //Console.WriteLine("hello: " + tries.Search("hello"));
            //Console.WriteLine("Card: " + tries.Search("Card"));
            //Console.WriteLine("Car: " + tries.Search("Car"));
            //tries.Delete("Cards");
            //Console.WriteLine("Card: " + tries.Search("Cards"));

            #endregion
        }

        static void TestBFS()
        {
            #region BFS

            var bfs = new BFS(4);
            bfs.AddEdge(0, 1);
            bfs.AddEdge(0, 2);
            bfs.AddEdge(1, 2);
            bfs.AddEdge(2, 0);
            bfs.AddEdge(2, 3);
            bfs.AddEdge(3, 3);

            bfs.Traverse(2);

            #endregion
        }

        static void TestDFS()
        {
            #region DFS

            var dfs = new DFS(4);
            dfs.AddEdge(0, 1);
            dfs.AddEdge(0, 2);
            dfs.AddEdge(1, 2);
            dfs.AddEdge(2, 0);
            dfs.AddEdge(2, 3);
            dfs.AddEdge(3, 3);

            dfs.Traverse(2);

            #endregion
        }

        static void TestKnapsackGreedy()
        {
            #region Knapsack

            var knapsack = new Knapsack(15, 
                new int [7]{10, 5, 15, 7, 6, 18, 3},
                new int [7] { 2, 3, 5, 7, 1, 4, 1 });
            var x = knapsack.FindMaximum();
            Console.WriteLine(string.Join(',', x));
            #endregion
        }

        static void TestKnapsackDP()
        {
            #region Knapsack

            var knapsack = new DataStructures.Core.DynamicProgramming.Knapsack.Knapsack(50,
                new[] {60, 100, 120},
                new[] {20, 10, 30});

            var x = knapsack.FindMaximum(Solution.Recursion);
            Console.WriteLine(string.Join(',', x));
            
            x = knapsack.FindMaximum(Solution.Memoization);
            Console.WriteLine(string.Join(',', x));

            x = knapsack.FindMaximum(Solution.Tabulation);
            Console.WriteLine(string.Join(',', x));

            #endregion
        }

        static void TestInsertionSort()
        {
            #region InsertionSort

            var insertionSort = new InsertionSort<int>(new[]
            {
                5,1,3,4,2,8,6
            });

            Console.WriteLine(string.Join(',', insertionSort.Sort()));

            #endregion
        }

        static void TestSelectionSort()
        {
            #region SelectionSort

            var selectionSort = new SelectionSort<int>(new[]
            {
                5,1,3,4,2,8,6
            });

            Console.WriteLine(string.Join(',', selectionSort.Sort()));

            #endregion
        }

        static void TestPrimeNumber()
        {
            #region PrimeNumber

            var primeNumber = new PrimeNumber();

            Console.WriteLine(string.Join(',', primeNumber.GetPrimeNumbers(1000)));
            Console.WriteLine("389: " + primeNumber.IsPrime(389));

            #endregion
        }

        static void TestGCD()
        {
            #region GCD

            var gcd = new GCD();

            Console.WriteLine("GCD: " + gcd.GetGcd(11, 13));

            #endregion
        }

        static void TestLCM()
        {
            #region LCM

            var lcm = new LCM();

            Console.WriteLine("LCM: " + lcm.GetLcm(11, 13));

            #endregion
        }
    }
}
