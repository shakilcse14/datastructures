using System;
using System.Collections.Generic;

namespace DataStructures.Core.Greedy.MST.Prims
{
    /// <summary>
    /// Single source shortest path (Non negative). Greedy approach.
    /// </summary>
    public class Prims
    {
        private readonly int[,] _connectedGraphWeights;
        private readonly int[] _nodeWeights;
        private readonly bool[] _visitedNodes;
        private readonly int[] _parentNodes;

        public Prims(int[,] connectedGraphWeights)
        {
            _connectedGraphWeights = connectedGraphWeights;
            _nodeWeights = new int[(int)Math.Sqrt(connectedGraphWeights.Length)];
            _visitedNodes = new bool[(int)Math.Sqrt(connectedGraphWeights.Length)];
            _parentNodes = new int[(int)Math.Sqrt(connectedGraphWeights.Length)];
        }

        /// <summary>
        /// Time complexity O(V^2)
        /// </summary>
        public IEnumerable<Tuple<string, int>> MinimumSpanningTree()
        {
            var mstPath = new List<Tuple<string, int>>();
            for (var index = 0; index < _nodeWeights.Length; index++)
            {
                _nodeWeights[index] = int.MaxValue;
                _parentNodes[index] = -1;
                _visitedNodes[index] = false;
            }

            _nodeWeights[0] = 0;
            _parentNodes[0] = 0;
            for (var indexI = 0; indexI < _nodeWeights.Length; indexI++)
            {
                var minIndex = GetMinimumWeightNode();
                _visitedNodes[minIndex] = true;
                if(indexI != 0)
                    mstPath.Add(Tuple.Create($"{_parentNodes[minIndex]} - {minIndex}", _nodeWeights[minIndex]));
                for (var indexJ = 0; indexJ < _nodeWeights.Length; indexJ++)
                {
                    if (_visitedNodes[indexJ]) continue;
                    if (_connectedGraphWeights[minIndex, indexJ] <= 0) continue;
                    if (_connectedGraphWeights[minIndex, indexJ] < _nodeWeights[indexJ])
                    {
                        _nodeWeights[indexJ] = _connectedGraphWeights[indexI, indexJ];
                        _parentNodes[indexJ] = minIndex;
                    }
                }
            }

            return mstPath;
        }

        #region Private methods

        private int GetMinimumWeightNode()
        {
            var min = int.MaxValue;
            var minIndex = 0;
            for (var index = 0; index < _nodeWeights.Length; index++)
            {
                if (_nodeWeights[index] < min && !_visitedNodes[index])
                {
                    minIndex = index;
                    min = _nodeWeights[index];
                }
            }

            return minIndex;
        }

        #endregion
    }
}