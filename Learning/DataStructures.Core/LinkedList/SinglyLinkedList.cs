using System;
using DataStructures.Core.LinkedList.Contracts.Interfaces;

namespace DataStructures.Core.LinkedList
{
    public class SinglyLinkedList<T> : ILinkedList<T>
    {
        private Node<T> _headNode = null;
        private Node<T> _tailNode = null;

        public SinglyLinkedList() { }

        public void Add(T data)
        {
            if (_headNode == null)
            {
                _headNode = new Node<T>(data);
                _tailNode = _headNode;
            }
            else
            {
                var node = new Node<T>(data);
                _tailNode.NextNode = node;
                _tailNode = node;
            }
        }

        public void AddAfter()
        {
            throw new System.NotImplementedException();
        }

        public void AddBefore()
        {
            throw new System.NotImplementedException();
        }

        public void AddFirst()
        {
            throw new System.NotImplementedException();
        }

        public void AddLast()
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            _headNode = null;
            _tailNode = null;
        }

        public void Remove(T data)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveFirst()
        {
            if(_headNode == null)
                throw new InvalidOperationException();

            _headNode = _headNode.NextNode;
        }

        public void RemoveLast()
        {
            if (_headNode == null || _tailNode == null)
                throw new InvalidOperationException();

            var node = _headNode;
            while (node.NextNode != _tailNode)
            {
                node = node.NextNode;
            }
        }

        public T Find()
        {
            throw new System.NotImplementedException();
        }
    }
}