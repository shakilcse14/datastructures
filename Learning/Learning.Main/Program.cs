using System;
using System.Collections.Generic;
using DataStructures.Core.ArrayList;
using DataStructures.Core.Backtracking;
using DataStructures.Core.Backtracking.GraphColoring;
using DataStructures.Core.Backtracking.HamiltonianCycle;
using DataStructures.Core.Backtracking.Subsets;
using DataStructures.Core.Backtracking.SumOfSubsets;
using DataStructures.Core.Bits;
using DataStructures.Core.DynamicProgramming.BellmanFord;
using DataStructures.Core.DynamicProgramming.EditDistance;
using DataStructures.Core.DynamicProgramming.EggDrop;
using DataStructures.Core.DynamicProgramming.Fibonacci;
using DataStructures.Core.DynamicProgramming.FloydWarShall;
using DataStructures.Core.DynamicProgramming.Knapsack;
using DataStructures.Core.DynamicProgramming.LCS;
using DataStructures.Core.DynamicProgramming.MatrixMultiplication;
using DataStructures.Core.DynamicProgramming.MultiStageGraph;
using DataStructures.Core.DynamicProgramming.OptimalBinarySearchTree;
using DataStructures.Core.Graphs.ArticulationPoint;
using DataStructures.Core.Graphs.AStar;
using DataStructures.Core.Graphs.BFS;
using DataStructures.Core.Graphs.BST;
using DataStructures.Core.Graphs.CycleDetection;
using DataStructures.Core.Graphs.DFS;
using DataStructures.Core.Graphs.TopologicalSort;
using DataStructures.Core.Greedy.Dijkstra;
using DataStructures.Core.Greedy.MST.Krushkals;
using DataStructures.Core.Greedy.MST.Prims;
using DataStructures.Core.HashTable;
using DataStructures.Core.Heap;
using DataStructures.Core.LinkedList;
using DataStructures.Core.NumberTheory.GCD;
using DataStructures.Core.NumberTheory.LCM;
using DataStructures.Core.NumberTheory.PrimeNumber;
using DataStructures.Core.Search.BinarySearch;
using DataStructures.Core.Sorting.CountingSort;
using DataStructures.Core.Sorting.BubbleSort;
using DataStructures.Core.Sorting.HeapSort;
using DataStructures.Core.Sorting.InsertionSort;
using DataStructures.Core.Sorting.MergeSort;
using DataStructures.Core.Sorting.QuickSort;
using DataStructures.Core.Sorting.SelectionSort;
using DataStructures.Core.Trees.AVLTree;
using DataStructures.Core.Trees.BinarySearchTree;
using DataStructures.Core.Trees.BinaryTree;
using DataStructures.Core.Trees.Contracts;
using DataStructures.Core.Trees.SegmentTree;
using DataStructures.Core.Trie;
using Knapsack = DataStructures.Core.Greedy.Knapsack.Knapsack;
using DataStructures.Core.Sorting.RadixSort;

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

            //TestTopologicalSort();

            //TestKnapsackGreedy();

            //TestKnapsackDP();

            //TestInsertionSort();

            //TestSelectionSort();

            //TestPrimeNumber();

            //TestGCD();

            //TestLCM();

            //TestDijkstra();

            //TestPrims();

            //TestKrushkals();

            //TestGraphCycleDetection();

            //TestFibonacci();

            //TestBellmanFord();

            //TestFloydWarshall();

            //TestLcs();

            //TestMultiStageGraph();

            //TestOptimalBinarySearchTree();

            //TestMatrixMultiplication();

            //TestSubsets();

            //TestNQueen();

            //TestHamiltonianCycle();

            //TestGraphColoring();

            //TestSumOfSubsets();

            //TestEggDrop();

            //TestEditDistance();

            //TestArticulationPoint();

            //TestSumOfSubsetsDp();

            //TestAStar();

            //TeatBST();

            //TestAVLTree();

            //TestBits();

            //TestSegmentTree();

            //TestCountingSort();

            TestRadixSort();

            Console.ReadLine();
        }

        static void TestRadixSort()
        {
            #region RadixSort

            var radixSort = new RadixSort();
            var sortedArray = radixSort.Sort(new int[] { 170, 45, 75, 90, 802, 24, 2, 66 });
            Console.WriteLine("[{0}]", string.Join(", ", sortedArray));

            #endregion
        }

        static void TestCountingSort()
        {
            #region CountingSort

            var countingSort = new CountingSort();
            var sortedArray = countingSort.Sort(new int[] { 170, 45, 75, 90, 802, 24, 2, 66 });
            Console.WriteLine("[{0}]", string.Join(", ", sortedArray));

            #endregion
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
            var arrayList = new ArrayList<int> {10, 20, 30, 40, 50, 60, 70, 80, 90};

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
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
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
                5, 1, 3, 4, 2, 8, 6
            });

            Console.WriteLine(string.Join(',', bubbleSort.Sort()));

            #endregion
        }

        static void TestMergeSort()
        {
            #region MergeSort

            var mergeSort = new MergeSort<int>(new int[]
            {
                5, 1, 3, 4, 2, 8, 6
            });

            Console.WriteLine(string.Join(',', mergeSort.Sort()));

            #endregion
        }

        static void TestQuickSort()
        {
            #region QuickSort

            var quickSort = new QuickSort<int>(new int[]
            {
                5, 1, 3, 4, 2, 8, 6
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

            var stack = new DataStructures.Core.Stack.Stack<int>();
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

            var queue = new DataStructures.Core.Queue.Queue<int>();
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
                5, 1, 3, 4, 2, 8, 6
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
                new int [7] {10, 5, 15, 7, 6, 18, 3},
                new int [7] {2, 3, 5, 7, 1, 4, 1});
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
                5, 1, 3, 4, 2, 8, 6
            });

            Console.WriteLine(string.Join(',', insertionSort.Sort()));

            #endregion
        }

        static void TestSelectionSort()
        {
            #region SelectionSort

            var selectionSort = new SelectionSort<int>(new[]
            {
                5, 1, 3, 4, 2, 8, 6
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

        static void TestDijkstra()
        {
            #region Dijkstra

            var dijkstra = new Dijkstra(new[,]
            {
                {0, 4, 0, 0, 0, 0, 0, 8, 0},
                {4, 0, 8, 0, 0, 0, 0, 11, 0},
                {0, 8, 0, 7, 0, 4, 0, 0, 2},
                {0, 0, 7, 0, 9, 14, 0, 0, 0},
                {0, 0, 0, 9, 0, 10, 0, 0, 0},
                {0, 0, 4, 14, 10, 0, 2, 0, 0},
                {0, 0, 0, 0, 0, 2, 0, 1, 6},
                {8, 11, 0, 0, 0, 0, 1, 0, 7},
                {0, 0, 2, 0, 0, 0, 6, 7, 0}
            });

            var dist = dijkstra.ShortestPath(0);
            Console.WriteLine(string.Join("\n", dist));

            #endregion
        }

        static void TestPrims()
        {
            #region Prims

            var prims = new Prims(new[,]
            {
                {0, 2, 0, 6, 0},
                {2, 0, 3, 8, 5},
                {0, 3, 0, 0, 7},
                {6, 8, 0, 0, 9},
                {0, 5, 7, 9, 0}
            });

            var dist = prims.MinimumSpanningTree();
            Console.WriteLine(string.Join("\n", dist));

            #endregion
        }

        static void TestKrushkals()
        {
            #region Krushkals

            var krushkals = new Krushkals(4, 5);
            krushkals.AddEdge(0, 1, 10);
            krushkals.AddEdge(0, 2, 6);
            krushkals.AddEdge(0, 3, 5);
            krushkals.AddEdge(1, 3, 15);
            krushkals.AddEdge(2, 3, 4);

            var dist = krushkals.MinimumSpanningTree();
            Console.WriteLine(string.Join("\n", dist));

            #endregion
        }

        static void TestGraphCycleDetection()
        {
            #region GraphCycleDetection

            var graphCycleDetection = new GraphCycleDetection(5, GraphType.Directed);
            graphCycleDetection.AddEdge(1, 0);
            graphCycleDetection.AddEdge(0, 2);
            graphCycleDetection.AddEdge(2, 1);
            graphCycleDetection.AddEdge(0, 3);
            graphCycleDetection.AddEdge(3, 4);

            Console.WriteLine(graphCycleDetection.HasCycle());

            graphCycleDetection = new GraphCycleDetection(3, GraphType.Directed);
            graphCycleDetection.AddEdge(0, 1);
            graphCycleDetection.AddEdge(1, 2);

            Console.WriteLine(graphCycleDetection.HasCycle());


            graphCycleDetection = new GraphCycleDetection(5, GraphType.UnDirected);
            graphCycleDetection.AddEdge(0, 1);
            graphCycleDetection.AddEdge(0, 2);
            graphCycleDetection.AddEdge(2, 3);
            graphCycleDetection.AddEdge(2, 4);
            graphCycleDetection.AddEdge(3, 4);

            Console.WriteLine(graphCycleDetection.HasCycle());

            graphCycleDetection = new GraphCycleDetection(3, GraphType.UnDirected);
            graphCycleDetection.AddEdge(0, 1);
            graphCycleDetection.AddEdge(1, 2);

            Console.WriteLine(graphCycleDetection.HasCycle());

            #endregion
        }

        static void TestFibonacci()
        {
            #region Fibonacci

            var fibonacci = new Fibonacci();

            Console.WriteLine(string.Join(",", fibonacci.GetFibonacciNumbers(10)));

            #endregion
        }

        static void TestBellmanFord()
        {
            #region Fibonacci

            var bellmanFord = new BellmanFord(5);
            bellmanFord.AddEdge(0, 1, -1);
            bellmanFord.AddEdge(0, 2, 4);
            bellmanFord.AddEdge(1, 2, 3);
            bellmanFord.AddEdge(1, 3, 2);
            bellmanFord.AddEdge(1, 4, 2);
            bellmanFord.AddEdge(3, 2, 5);
            bellmanFord.AddEdge(3, 1, 1);
            bellmanFord.AddEdge(4, 3, -3);

            Console.WriteLine(string.Join(",", bellmanFord
                .ShortestPath(0)));

            #endregion
        }


        static void TestFloydWarshall()
        {
            #region FloydWarshall

            var floydWarShall = new FloydWarshall();
            var dist = floydWarShall.AllPairShortestPaths(new[,]
            {
                {0, 5, int.MaxValue, 10},
                {int.MaxValue, 0, 3, int.MaxValue},
                {int.MaxValue, int.MaxValue, 0, 1},
                {int.MaxValue, int.MaxValue, int.MaxValue, 0}
            });

            for (var i = 0; i < dist.GetLength(0); i++)
            {
                for (var j = 0; j < dist.GetLength(1); j++)
                {
                    Console.Write(dist[i, j] + "\t");
                }

                Console.WriteLine();
            }

            #endregion
        }

        static void TestLcs()
        {
            #region Lcs

            var lcs = new LongestCommonSubsequence();
            Console.WriteLine(lcs.MaxLcs("AGGTAB", "GXTXAYB"));

            #endregion
        }

        static void TestMultiStageGraph()
        {
            #region MultiStageGraph

            var msg = new MultiStageGraph(8, new int[,]
            {
                {int.MaxValue, 1, 2, 5, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue},
                {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 4, 11, int.MaxValue, int.MaxValue},
                {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 9, 5, 16, int.MaxValue},
                {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 2, int.MaxValue},
                {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 18},
                {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 13},
                {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 2}
            });
            var path = msg.ShortestPath();
            Console.WriteLine(path.Item1 + "\n" + path.Item2);

            #endregion
        }

        static void TestOptimalBinarySearchTree()
        {
            #region OptimalBinarySearchTree

            var ost = new OptimalSearchTree(new[] {10, 12, 20}, new[] {34, 8, 50});
            var path = ost.FindCost();
            Console.WriteLine(path);

            #endregion
        }

        static void TestMatrixMultiplication()
        {
            #region MatrixMultiplication

            var matrixMultiplication = new MatrixMultiplication(new[] { 1, 2, 3, 4 });
            Console.WriteLine(matrixMultiplication.TotalMultiplication());

            #endregion
        }

        static void TestSubsets()
        {
            #region Subsets

            var subsets = new Subsets(new[] { 1, 2, 3 });
            var list = subsets.FindAll();
            Console.WriteLine(string.Join("\n", list));

            #endregion
        }

        static void TestNQueen()
        {
            #region N-Queen

            var nQueen = new NQueen(new int[] {1, 2, 3, 4});
            nQueen.FindAll();

            #endregion
        }

        static void TestHamiltonianCycle()
        {
            #region HamiltonianCycle

            var hamiltonianCycle = new HamiltonianCycle(6,
                new[,]
                {
                    {0, 0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 0, 1},
                    {0, 1, 0, 1, 1, 1},
                    {0, 1, 1, 0, 1, 0},
                    {0, 0, 1, 1, 0, 1},
                    {0, 1, 1, 0, 1, 0}
                });
            hamiltonianCycle.FindAll(1);

            #endregion
        }

        static void TestGraphColoring()
        {
            #region GraphColoring

            var graphColoring = new GraphColoring(3, 4, new[,]
            {
                {0, 1, 1, 1},
                {1, 0, 1, 0},
                {1, 1, 0, 1},
                {1, 0, 1, 0}
            });
            graphColoring.Find();

            #endregion
        }

        static void TestSumOfSubsets()
        {
            #region SumOfSubsets

            var sumOfSubsets = new SumOfSubsets(30, new[] {5, 10, 12, 13, 15, 18});
            sumOfSubsets.FindAll();

            #endregion
        }

        static void TestEggDrop()
        {
            #region EggDrop

            var eggDrop = new EggDrop(10, 2);
            Console.WriteLine(eggDrop.Find());

            #endregion
        }

        static void TestEditDistance()
        {
            #region EditDistance

            var editDistance = new EditDistance();
            Console.WriteLine(editDistance.Find("sunday", "saturday"));

            #endregion
        }

        static void TestArticulationPoint()
        {
            #region ArticulationPoint

            var articulationPoint = new ArticulationPoint(5, new[,]
            {
                {false, true, true, true, false},
                {true, false, true, false, false},
                {true, true, false, false, false},
                {true, false, false, false, true},
                {false, false, false, true, false}
            });
            //var articulationPoint = new ArticulationPoint(4, new[,]
            //{
            //    { false, true, false, false},
            //    { true, false, true, false},
            //    { false, true, false, true},
            //    { false, false, true, false}
            //});
            //var articulationPoint = new ArticulationPoint(7, new[,]
            //{
            //    { false, true, true, false, false, false, false},
            //    { true, false, true, true, true, false, true},
            //    { true, true, false, false, false, false, false},
            //    { false, true, false, false, false, true, false},
            //    { false, true, false, false, false, true, false},
            //    { false, false, false, true, true, false, false},
            //    { false, true, false, false, false, false, false}
            //});

            Console.WriteLine(articulationPoint.Find());

            #endregion
        }

        static void TestSumOfSubsetsDp()
        {
            #region SumOfSubset

            var sumOfSubsets = new DataStructures.Core.DynamicProgramming.SumOfSubsets.SumOfSubsets();
            Console.WriteLine(sumOfSubsets.Find(new[] { 3, 34, 4, 12, 5, 2 }, 9));
            Console.WriteLine(sumOfSubsets.Find(new[] { 3, 34, 4, 12, 5, 2 }, 30));

            #endregion
        }

        static void TestAStar()
        {
            #region AStar

            var aStar = new AStar();
            aStar.AddEdge('s', 'b', 4, 14);
            aStar.AddEdge('s', 'c', 3);
            aStar.AddEdge('b', 'f', 5, 12);
            aStar.AddEdge('b', 'e', 12);
            aStar.AddEdge('c', 'e', 10, 11);
            aStar.AddEdge('c', 'd', 7);
            aStar.AddEdge('f', 'g', 16, 11);
            aStar.AddEdge('d', 'e', 2, 6);
            aStar.AddEdge('e', 'g', 5, 4);

            aStar.FindRoute('s', 'g');

            #endregion
        }

        static void TeatBST()
        {
            #region BST

            var bst = new BestFirstSearch();
            bst.AddEdge(0, 1, 3);
            bst.AddEdge(0, 2, 6);
            bst.AddEdge(0, 3, 5);
            bst.AddEdge(1, 4, 9);
            bst.AddEdge(1, 5, 8);
            bst.AddEdge(2, 6, 12);
            bst.AddEdge(2, 7, 14);
            bst.AddEdge(3, 8, 7);
            bst.AddEdge(8, 9, 5);
            bst.AddEdge(8, 10, 6);
            bst.AddEdge(9, 11, 1);
            bst.AddEdge(9, 12, 10);
            bst.AddEdge(9, 13, 2);

            bst.Find(0, 9);

            #endregion
        }

        static void TestAVLTree()
        {
            #region AVLTree

            var avlTree = new AVLTree();
            //avlTree.Insert(10);
            //avlTree.Insert(20);
            //avlTree.Insert(30);
            //avlTree.Insert(40);
            //avlTree.Insert(50);
            //avlTree.Insert(25);

            //avlTree.Insert(40);
            //avlTree.Insert(20);
            //avlTree.Insert(10);
            //avlTree.Insert(25);
            //avlTree.Insert(30);
            //avlTree.Insert(22);
            //avlTree.Insert(50);

            avlTree.Insert(9);
            avlTree.Insert(5);
            avlTree.Insert(10);
            avlTree.Insert(0);
            avlTree.Insert(6);
            avlTree.Insert(11);
            avlTree.Insert(-1);
            avlTree.Insert(1);
            avlTree.Insert(2);

            avlTree.PreOrder();

            avlTree.Delete(10);

            Console.WriteLine();

            avlTree.PreOrder();

            #endregion
        }

        static void TestBits()
        {
            #region Bits

            var bit = new BitsBasic();
            Console.WriteLine(bit.GetBit(105, 6));
            Console.WriteLine(bit.SetBit(165, 6));
            Console.WriteLine(bit.ClearBit(105, 6));

            Console.WriteLine(bit.ToggleBit(105, 6));
            Console.WriteLine(bit.ChangeBit(6, 5, 1));

            Console.WriteLine(bit.CountSetBits(2321));

            #endregion
        }

        static void TestTopologicalSort()
        {
            #region TopologicalSort

            var topologicalSort = new TopologicalSort();
            var result = topologicalSort.Sort(new[,]
            {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0 },
                { 0, 1, 0, 0, 0, 0 },
                { 1, 1, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 0, 0 }
            });
            Console.WriteLine(string.Join(',', result));

            #endregion
        }

        static void TestSegmentTree()
        {
            #region SegmentTree

            var segmentTree = new SegmentTree(new []{ 1, 3, 5, 7, 9, 11 });
            Console.WriteLine(string.Join(',', segmentTree.RunningSum));
            Console.WriteLine(segmentTree.GetSum(1, 3));
            segmentTree.Update(1, 10);
            Console.WriteLine(string.Join(',', segmentTree.RunningSum));
            Console.WriteLine(segmentTree.GetSum(1, 3));

            #endregion
        }
    }
}
