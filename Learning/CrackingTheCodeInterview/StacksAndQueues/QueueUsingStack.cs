using System.Collections.Generic;

namespace CrackingTheCodeInterview.StacksAndQueues
{
    public class QueueUsingStack
    {
        private Stack<int> _stackFirst;
        private Stack<int> _stackSecond;

        public QueueUsingStack()
        {
            _stackFirst = new Stack<int>();
            _stackSecond = new Stack<int>();
        }

        /// <summary>
        /// Time complexity O(1)
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(int value)
        {
            _stackFirst.Push(value);
        }

        /// <summary>
        /// Time complexity O(1)[Amortized time]
        /// </summary>
        /// <returns></returns>
        public int Dequeue()
        {
            if (_stackSecond.Count > 0)
                return _stackSecond.Pop();

            while (_stackFirst.Count > 0)
            {
                _stackSecond.Push(_stackFirst.Pop());
            }

            return _stackSecond.Pop();
        }
    }
}