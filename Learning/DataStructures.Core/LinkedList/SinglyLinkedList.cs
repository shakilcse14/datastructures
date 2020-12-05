using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.Core.LinkedList.Contracts.Interfaces;

namespace DataStructures.Core.LinkedList
{
    public class SinglyLinkedList<T> : ILinkedList<T>, IEnumerable
    {
        private Node<T> _headNode;
        private Node<T> _tailNode;

        /// <summary>
        /// Time complexity O(1)
        /// </summary>
        /// <param name="data"></param>
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

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="position"></param>
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

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Time Complexity O(1)
        /// </summary>
        /// <param name="data"></param>
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

        /// <summary>
        /// Time Complexity O(1)
        /// </summary>
        /// <param name="data"></param>
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

        // TODO - Predicate or something
        public void Remove(T data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Time Complexity O(n)
        /// </summary>
        /// <param name="position"></param>
        public void Remove(int position)
        {
            if(position == 1)
            {
                if (_headNode == _tailNode)
                    _headNode = _tailNode = _headNode.NextNode;
                else
                    _headNode = _headNode.NextNode;
                return;
            }

            var currentPosition = 1;
            var currentNode = _headNode;
            var prevNode = _headNode;
            while (currentPosition <= position && currentNode != null)
            {
                if (currentPosition == position)
                {
                    prevNode.NextNode = currentNode.NextNode;
                    if (currentNode == _tailNode)
                        _tailNode = prevNode;
                    return;
                }

                currentPosition++;
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
            }

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Time Complexity O(1)
        /// </summary>
        public void RemoveFirst()
        {
            if(_headNode == null)
                throw new InvalidOperationException();

            _headNode = _headNode.NextNode;
        }

        /// <summary>
        /// Time Complexity O(n)
        /// </summary>
        public void RemoveLast()
        {
            if (_headNode == null || _tailNode == null)
                throw new InvalidOperationException();
            if (_headNode == _tailNode)
            {
                _headNode = _tailNode = null;
                return;
            }

            var currentNode = _headNode;
            while (currentNode.NextNode != _tailNode)
            {
                currentNode = currentNode.NextNode;
            }
            currentNode.NextNode = null;
        }

        /// <summary>
        /// Time Complexity O(n)
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public T Find(int position)
        {
            var currentPosition = 1;
            var currentNode = _headNode;
            while (currentPosition <= position && currentNode != null)
            {
                if (currentPosition == position)
                {
                    return currentNode.Data;
                }

                currentPosition++;
                currentNode = currentNode.NextNode;
            }

            throw new ArgumentOutOfRangeException();
        }

        // TODO - Predicate or something
        public bool Find(T data)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return new LinkedListEnumrator<T>(_headNode);
        }
    }
}
