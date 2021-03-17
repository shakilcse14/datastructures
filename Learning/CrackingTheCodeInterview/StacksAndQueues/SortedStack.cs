using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.StacksAndQueues
{
    public class SortedStack
    {
        private readonly Stack<int> _stackMain;
        private readonly Stack<int> _stackSecondary;

        public SortedStack(Stack<int> stack)
        {
            _stackMain = stack;
            _stackSecondary = new Stack<int>();

            Sort();
        }

        public void Push(int value)
        {
            if(_stackMain == null)
                throw new InvalidOperationException();

            _stackMain.Push(value);
            Sort();
        }

        public int Pop()
        {
            if (_stackSecondary == null || _stackSecondary.Count <= 0)
                throw new InvalidOperationException();
            
            return _stackSecondary.Pop();
        }

        public int Peek()
        {
            if (_stackSecondary == null || _stackSecondary.Count <= 0)
                throw new InvalidOperationException();
            
            return _stackSecondary.Peek();
        }

        public bool IsEmpty()
        {
            if (_stackSecondary == null)
                throw new InvalidOperationException();

            return _stackSecondary.Count <= 0;
        }

        #region Private methods

        /// <summary>
        /// Time complexity O(n^2)
        /// </summary>
        private void Sort()
        {
            while (_stackMain.Count > 0)
            {
                var temp = _stackMain.Pop();

                while (_stackSecondary.Count > 0 && _stackSecondary.Peek() < temp)
                {
                    _stackMain.Push(_stackSecondary.Pop());
                }

                _stackSecondary.Push(temp);
            }
        }

        #endregion
    }
}