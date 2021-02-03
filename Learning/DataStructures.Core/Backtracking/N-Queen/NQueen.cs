using System;
using System.Collections.Generic;

namespace DataStructures.Core.Backtracking
{
    public class NQueen
    {
        private readonly int[] _items;

        public NQueen(int [] items)
        {
            _items = items;
        }

        public void FindAll()
        {
            var position = new Stack<int>();
            Find(position, 0);
        }

        #region Private Methods

        private void Find(Stack<int> position, int col)
        {
            if (col >= _items.Length)
            {
                if (position.Count == _items.Length)
                    Console.WriteLine($"{string.Join(", ", position)}");

                position.Clear();
                return;
            }

            for (var index = 0; index < _items.Length; index++)
            {
                if (position.Count <= 0 || (!position.Contains(index) &&
                                            position.Peek() + 1 != index) && position.Peek() - 1 != index)
                {
                    position.Push(index);
                    Find(position, col + 1);
                }
            }

            if (position.Count != _items.Length)
            {
                if (position.Count > 0)
                    position.Pop();
            }
        }

        #endregion
    }
}