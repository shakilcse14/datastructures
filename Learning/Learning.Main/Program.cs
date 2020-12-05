using System;
using DataStructures.Core.ArrayList;
using DataStructures.Core.LinkedList;

namespace Learning.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestArrayList();

            //TestSinglyLinkedList();

            //TestDoublyLinkedList();

            Console.ReadLine();
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
    }
}
