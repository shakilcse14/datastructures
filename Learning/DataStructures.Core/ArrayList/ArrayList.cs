using System;
using System.Collections;
using DataStructures.Core.ArrayList.Contracts.Interfaces;

namespace DataStructures.Core.ArrayList
{
    /// <summary>
    /// Time complexity O(n)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayList<T> : IArrayList<T>, IEnumerable
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
                _maxSize *= 2;
                var tempArrayList = new T[_maxSize];
                Array.Copy(_arrayList, tempArrayList, _arrayList.Length);

                _arrayList = tempArrayList;
            }

            _arrayList[_currentLength] = item;
            _currentLength++;

            Console.WriteLine($"Current: {_currentLength} MaxSize: {_maxSize}");
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

        public int Length => _currentLength;

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            CheckSize(index);

            if (_currentLength - 1 == index)
                _arrayList[index] = default;
            else
            {
                for (var i = index; i < _currentLength - 1; i++)
                {
                    _arrayList[i] = _arrayList[i + 1];
                }

                _arrayList[_currentLength - 1] = default;
            }

            if (_currentLength * 4 == _maxSize)
            {
                Console.WriteLine("Halving the size ... ");
                _maxSize /= 2;
                var tempArrayList = new T[_maxSize];
                Array.Copy(_arrayList, 0, tempArrayList, 0, _maxSize);

                _arrayList = tempArrayList;
            }

            _currentLength--;

            Console.WriteLine($"Current: {_currentLength} MaxSize: {_maxSize}");
        }

        public IEnumerator GetEnumerator()
        {
            return new ArrayListEnumerator<T>(_arrayList, _currentLength);
        }

        #region Private Methods

        private void CheckSize(int index)
        {
            if (index >= _currentLength)
                throw new IndexOutOfRangeException("Index out of range");
        }

        #endregion
    }

    public class ArrayListEnumerator<T> : IEnumerator
    {
        private readonly T[] _arrayList;
        private readonly int _length;
        private int _position = -1;

        public ArrayListEnumerator(T[] arrayList, int length)
        {
            _arrayList = arrayList;
            _length = length;
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _length;
        }

        public void Reset()
        {
            _position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _arrayList[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

    }
}