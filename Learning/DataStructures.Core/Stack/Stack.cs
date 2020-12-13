using System;
using System.Data.Common;
using DataStructures.Core.LinkedList;
using DataStructures.Core.Stack.Contracts.Interfaces;

namespace DataStructures.Core.Stack
{
    public class Stack<T> : IStack<T>
    {
        private readonly SinglyLinkedList<T> _singlyLinkedList;

        public Stack()
        {
            _singlyLinkedList = new SinglyLinkedList<T>();
        }

        public void Clear()
        {
            _singlyLinkedList.Clear();
        }

        public void Push(T data)
        {
            _singlyLinkedList.AddFirst(data);
        }

        public T Pop()
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