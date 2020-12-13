using System;
using DataStructures.Core.LinkedList;
using DataStructures.Core.Queue.Contracts.Interfaces;

namespace DataStructures.Core.Queue
{
    public class Queue<T> : IQueue<T>
    {
        private readonly SinglyLinkedList<T> _singlyLinkedList;

        public Queue()
        {
            _singlyLinkedList = new SinglyLinkedList<T>();
        }

        public void Clear()
        {
            _singlyLinkedList.Clear();
        }

        public void Enqueue(T data)
        {
            _singlyLinkedList.Add(data);
        }

        public T Dequeue()
        {
            var data = _singlyLinkedList.Find(1);
            _singlyLinkedList.RemoveFirst();
            return data;
        }

        public bool Contains(T data)
        {
            try
            {
                var value = _singlyLinkedList.Find(data);
                return value != null;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public T Peek()
        {
            var data = _singlyLinkedList.Find(1);
            return data;
        }
    }
}