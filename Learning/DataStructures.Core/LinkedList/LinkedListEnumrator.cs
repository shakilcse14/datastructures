using System;
using System.Collections;

namespace DataStructures.Core.LinkedList
{
    public class LinkedListEnumrator<T> : IEnumerator
    {
        private Node<T> _headNode;
        private Node<T> _currentNode;

        public LinkedListEnumrator(Node<T> headNode)
        {
            _headNode = headNode;
        }

        public bool MoveNext()
        {
            if (_headNode == null) return false;

            if (_currentNode == null)
            {
                _currentNode = _headNode;
                return true;
            }

            _currentNode = _currentNode.NextNode;
            return _currentNode != null && _currentNode != _headNode;
        }

        public void Reset()
        {
            _currentNode = null;
            _headNode = null;
        }

        object IEnumerator.Current => Current;

        public T Current
        {
            get
            {
                try
                {
                    return _currentNode.Data;
                }
                catch(ArgumentOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
