using System;
using System.Collections;
using System.Linq;
using DataStructures.Core.LinkedList.Contracts.Interfaces;

namespace DataStructures.Core.LinkedList
{
    public class DoublyLinkedList<T> : ILinkedList<T>, IEnumerable
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
                node.PreviousNode = _tailNode;
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
                    node.PreviousNode = currentNode;
                    if (currentNode.NextNode != null)
                        currentNode.NextNode.PreviousNode = node;
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
                _headNode.PreviousNode = node;
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
                node.PreviousNode = _tailNode;
                _tailNode = node;
            }
        }

        public void Clear()
        {
            _headNode = null;
            _tailNode = null;
        }

        /// <summary>
        /// Time Complexity O(n)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="propertyName"></param>
        public void Remove(object data, string propertyName = "")
        {
            var currentNode = _headNode;
            if (!string.IsNullOrEmpty(propertyName))
            {
                if (!typeof(T).GetProperties()
                    .Any(x => x.Name.Equals(propertyName)))
                    throw new InvalidOperationException();

                while (currentNode != null)
                {
                    if (currentNode.Data.GetType()
                        .GetProperty(propertyName)
                        .GetValue(currentNode.Data)
                        .Equals(data))
                    {
                        Remove(currentNode);
                        return;
                    }

                    currentNode = currentNode.NextNode;
                }
            }
            else
            {
                while (currentNode != null)
                {
                    if (currentNode.Data.Equals(data))
                    {
                        Remove(currentNode);
                        return;
                    }

                    currentNode = currentNode.NextNode;
                }
            }
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Time Complexity O(n)
        /// </summary>
        /// <param name="position"></param>
        public void Remove(int position)
        {
            if (position == 1)
            {
                if (_headNode == _tailNode)
                    _headNode = _tailNode = _headNode.NextNode;
                else
                    _headNode = _headNode.NextNode;
                return;
            }

            var currentPosition = 1;
            var currentNode = _headNode;
            while (currentPosition <= position && currentNode != null)
            {
                if (currentPosition == position)
                {
                    Remove(currentNode);
                    return;
                }

                currentPosition++;
                currentNode = currentNode.NextNode;
            }

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Time Complexity O(1)
        /// </summary>
        public void RemoveFirst()
        {
            if (_headNode == null)
                throw new InvalidOperationException();

            _headNode = _headNode.NextNode;
            _headNode.PreviousNode = null;
        }

        /// <summary>
        /// Time Complexity O(1)
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

            _tailNode.PreviousNode.NextNode = null;
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

        /// <summary>
        /// Time Complexity O(n)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public T Find(object data, string propertyName = "")
        {
            var currentNode = _headNode;
            if (!string.IsNullOrEmpty(propertyName))
            {
                if (!typeof(T).GetProperties()
                    .Any(x => x.Name.Equals(propertyName)))
                    throw new InvalidOperationException();

                while (currentNode != null)
                {
                    if (currentNode.Data.GetType()
                        .GetProperty(propertyName)
                        .GetValue(currentNode.Data)
                        .Equals(data))
                    {
                        return currentNode.Data;
                    }

                    currentNode = currentNode.NextNode;
                }
            }
            else
            {
                while (currentNode != null)
                {
                    if (currentNode.Data.Equals(data))
                    {
                        return currentNode.Data;
                    }

                    currentNode = currentNode.NextNode;
                }
            }
            throw new InvalidOperationException();
        }

        public IEnumerator GetEnumerator()
        {
            return new LinkedListEnumrator<T>(_headNode);
        }

        #region Private methods

        private void Remove(Node<T> currentNode)
        {
            if (currentNode.NextNode != null)
                currentNode.NextNode.PreviousNode = currentNode.PreviousNode;
            currentNode.PreviousNode.NextNode = currentNode.NextNode;
            return;
        }

        #endregion
    }
}