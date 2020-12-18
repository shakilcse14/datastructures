using System;
using System.Collections;
using DataStructures.Core.ArrayList;
using DataStructures.Core.Heap.Contracts.Interfaces;

namespace DataStructures.Core.Heap
{
    /// <summary>
    /// Using MAX Heap
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T> : IHeap<T>, IEnumerable where T : IComparable
    {
        private readonly ArrayList<T> _arrayList;

        public PriorityQueue()
        {
            _arrayList = new ArrayList<T>();
        }

        /// <summary>
        /// Time complexity O(nlogn)
        /// </summary>
        /// <param name="data"></param>
        public void Enqueue(T data)
        {
            _arrayList.Add(data);
            
            var currentPosition = _arrayList.Length - 1;
            while (currentPosition > 1)
            {
                var parentPosition = GetParentPosition(currentPosition);
                
                if (_arrayList[currentPosition].CompareTo(_arrayList[parentPosition]) > 0)
                {
                    Swap(parentPosition, currentPosition);
                }
                else
                    break;

                currentPosition = parentPosition;
            }
        }

        /// <summary>
        /// Time complexity O(nlogn)
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            var currentPosition = 0;
            var value = _arrayList[currentPosition];
            _arrayList[currentPosition] = _arrayList[_arrayList.Length - 1];
            _arrayList.Remove(_arrayList.Length - 1);

            while (true)
            {
                var leftPosition = GetLeftChildPosition(currentPosition);
                var rightPosition = GetRightChildPosition(currentPosition);
                if (leftPosition >= _arrayList.Length) break;

                if (rightPosition >= _arrayList.Length)
                {
                    if (_arrayList[leftPosition].CompareTo(_arrayList[currentPosition]) > 0)
                    {
                        Swap(leftPosition, currentPosition);
                    }
                    break;
                }

                if (_arrayList[leftPosition].CompareTo(_arrayList[rightPosition]) > 0)
                {
                    if (_arrayList[leftPosition].CompareTo(_arrayList[currentPosition]) > 0)
                    {
                        Swap(leftPosition, currentPosition);
                        currentPosition = leftPosition;
                    }
                    else
                        break;
                }
                else
                {
                    if (_arrayList[rightPosition].CompareTo(_arrayList[currentPosition]) > 0)
                    {
                        Swap(rightPosition, currentPosition);
                        currentPosition = rightPosition;
                    }
                    else
                        break;
                }
            }

            return value;
        }
        /// <summary>
        /// Time complexity O(1)
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return _arrayList[0];
        }

        #region Private methods

        private int GetLeftChildPosition(int index)
        {
            return (2 * index) + 1;
        }

        private int GetRightChildPosition(int index)
        {
            return (2 * index) + 2;
        }

        private int GetParentPosition(int index)
        {
            return (index - 1) / 2;
        }

        private void Swap(int swapPosA, int swapPosB)
        {
            var temp = _arrayList[swapPosA];
            _arrayList[swapPosA] = _arrayList[swapPosB];
            _arrayList[swapPosB] = temp;
        }

        #endregion

        public IEnumerator GetEnumerator()
        {
            return _arrayList.GetEnumerator();
        }
    }
}