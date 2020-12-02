using System;
using DataStructures.Core.ArrayList;

namespace Learning.Main
{
    class Program
    {
        static void Main(string[] args)
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

            Console.ReadLine();
        }
    }
}
