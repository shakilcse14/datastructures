using System;
using DataStructures.Core.LinkedList.Contracts.Interfaces;

namespace DataStructures.Core.LinkedList
{
    public class SinglyLinkedList<T> : ILinkedList<T>
    {
        private Node<T> _headNode;
        private Node<T> _tailNode;

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

        public void Add(T data, int position)
        {
            if (position == 1)
            {
                AddFirst(data);
                return;
            }

            var currentPosition = 1;
            var currentNode = _headNode;
            while (currentPosition < position && currentNode != null)
            {
                currentPosition++;
                if (currentPosition == position)
                {
                    var node = new Node<T>(data)
                    {
                        NextNode = currentNode.NextNode
                    };
                    currentNode.NextNode = node;
                    return;
                }

                currentNode = currentNode.NextNode;
            }

            throw new InvalidOperationException();
        }

        public void AddFirst(T data)
        {
            if (_headNode == null)
            {
                _headNode = new Node<T>(data);
                _tailNode = _headNode;
            }
            else
            {
                var node = new Node<T>(data)
                {
                    NextNode = _headNode
                };
                _headNode = node;
            }
        }

        public void AddLast(T data)
        {
            if (_tailNode == null)
                _headNode = _tailNode = new Node<T>(data);
            else
            {
                var node = new Node<T>(data);
                _tailNode.NextNode = node;
                _tailNode = node;
            }
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

            var currentNode = _headNode;
            while (currentNode.NextNode != _tailNode)
            {
                currentNode = currentNode.NextNode;
            }
        }

        public T Find(int position)
        {
            throw new System.NotImplementedException();
        }

        public T Find(T data)
        {
            throw new System.NotImplementedException();
        }
    }
}