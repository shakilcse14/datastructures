using System;
using DataStructures.Core.ArrayList.Contracts.Interfaces;

namespace DataStructures.Core.ArrayList
{
    /// <summary>
    /// Time complexity O(n)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayList<T> : IArrayList<T>
    {
        private int _maxSize = 0;
        private T[] _arrayList;
        private int _currentLength = 0;

        public ArrayList()
        {
            _maxSize = 1;
            _arrayList = new T[_maxSize];
        }

        public ArrayList(int length)
        {
            _maxSize = length;
            _arrayList = new T[_maxSize];
        }

        /// <summary>
        /// Time complexity O(1), Amortized time
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (_arrayList == null) return;

            if (_currentLength >= _maxSize)
            {
                Console.WriteLine("Doubling the size ... ");
                var tempArrayList = new T[_maxSize * 2];
                _maxSize *= 2;
                Array.Copy(_arrayList, tempArrayList, _arrayList.Length);

                _arrayList = tempArrayList;
            }

            _arrayList[_currentLength] = item;
            _currentLength++;
        }

        public T this[int index]
        {
            get
            {
                CheckSize(index);
                return _arrayList[index];
            }
            set
            {
                CheckSize(index);
                _arrayList[index] = value;
            }
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            throw new System.NotImplementedException();
        }

        #region Private Methods

        private void CheckSize(int index)
        {
            if (index > _currentLength)
                throw new IndexOutOfRangeException("Out of range");
        }

        #endregion
    }
}