using System;
using System.Collections.Generic;

namespace DataStructures.Core.Greedy.Dijkstra
{
    /// <summary>
    /// Single source shortest path (Non negative). Greedy approach.
    /// </summary>
    public class Dijkstra
    {
        private readonly int[,] _connectedGraphWeights;
        private readonly int[] _nodeWeights;
        private readonly bool[] _visitedNodes;

        public Dijkstra(int[,] connectedGraphWeights)
        {
            _connectedGraphWeights = connectedGraphWeights;
            _nodeWeights = new int[(int)Math.Sqrt(connectedGraphWeights.Length)];
            _visitedNodes = new bool[(int)Math.Sqrt(connectedGraphWeights.Length)];
        }

        /// Can reduce to O(ELogV) using heap and adjacency list
        /// <summary>
        /// Time complexity O(V^2)
        /// </summary>
        public IEnumerable<Tuple<int, string>> ShortestPath(int sourceFrom)
        {
            return AdjacencyMatrixApproach(sourceFrom);
        }

        private IEnumerable<Tuple<int, string>> AdjacencyMatrixApproach(int sourceFrom)
        {
            var pathWithWeight = new List<Tuple<int, string>>();
            for (var index = 0; index < _nodeWeights.Length; index++)
            {
                _nodeWeights[index] = int.MaxValue;
            }

            var path = new List<int>();
            _nodeWeights[sourceFrom] = 0;
            for (var indexI = 0; indexI < _nodeWeights.Length; indexI++)
            {
                var minIndex = GetMinWeightNode();
                _visitedNodes[minIndex] = true;
                path.Add(minIndex);
                for (var indexJ = 0; indexJ < _nodeWeights.Length; indexJ++)
                {
                    if (_visitedNodes[indexJ]) continue;
                    if (_connectedGraphWeights[minIndex, indexJ] <= 0) continue;

                    if (_connectedGraphWeights[minIndex, indexJ] + _nodeWeights[minIndex] < _nodeWeights[indexJ])
                        _nodeWeights[indexJ] = _connectedGraphWeights[minIndex, indexJ] + _nodeWeights[minIndex];
                }

                pathWithWeight.Add(Tuple.Create(_nodeWeights[minIndex], string.Join(",", path)));
            }

            return pathWithWeight;
        }

        #region Private methods

        private int GetMinWeightNode()
        {
            var minIndex = 0;
            var min = int.MaxValue;
            for (var index = 0; index < _nodeWeights.Length; index++)
            {
                if(_visitedNodes[index]) continue;
                if (_nodeWeights[index] >= min) continue;

                minIndex = index;
                min = _nodeWeights[index];
            }

            return minIndex;
        }

        #endregion
    }
}