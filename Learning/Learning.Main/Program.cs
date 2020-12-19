using System;
using DataStructures.Core.ArrayList;
using DataStructures.Core.HashTable;
using DataStructures.Core.Heap;
using DataStructures.Core.LinkedList;
using DataStructures.Core.Queue;
using DataStructures.Core.Search.BinarySearch;
using DataStructures.Core.Sorting.BubbleSort;
using DataStructures.Core.Sorting.HeapSort;
using DataStructures.Core.Sorting.MergeSort;
using DataStructures.Core.Sorting.QuickSort;
using DataStructures.Core.Stack;
using DataStructures.Core.Trees.BinarySearchTree;
using DataStructures.Core.Trees.BinaryTree;
using DataStructures.Core.Trees.Contracts;

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

            TestBinarySearchTree();

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

    }
}
