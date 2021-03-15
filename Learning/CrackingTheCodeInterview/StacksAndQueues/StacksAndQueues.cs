using System;

namespace CrackingTheCodeInterview.StacksAndQueues
{
    public class StacksAndQueues
    {
        private Node _head;

        public void Push(int x)
        {
            var node = new Node
            {
                Value = x, Next = _head, MinValue = x
            };
            if (_head != null)
                node.MinValue = Math.Min(x, _head.MinValue);
            _head = node;
        }

        public void Pop()
        {
            _head = _head != null ? _head.Next : _head;
        }

        public int Top()
        {
            return _head?.Value ?? -1;
        }

        public int GetMin()
        {
            return _head?.MinValue ?? -1;
        }

        #region Private methods



        #endregion
    }

    public class Node
    {
        public Node Next { get; set; }
        public int Value { get; set; }
        public int MinValue { get; set; }
    }
}