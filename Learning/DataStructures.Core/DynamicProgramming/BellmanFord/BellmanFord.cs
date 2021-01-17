using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataStructures.Core.DynamicProgramming.BellmanFord
{
    /// <summary>
    /// Single source shortest path (Negative, Acyclic). Greedy approach.
    /// </summary>
    public class BellmanFord
    {
        private readonly List<Edge> _adjacenyList;
        private readonly int[] _nodeWeights;
        private readonly int _vertices;

        public BellmanFord(int vertices)
        {
            _adjacenyList = new List<Edge>();
            _nodeWeights = new int[vertices];
            _vertices = vertices;
            for (var index = 0; index < vertices; index++)
            {
                _nodeWeights[index] = int.MaxValue;
            }
        }

        public void AddEdge(int from, int to, int weight)
        {
            _adjacenyList.Add(new Edge()
            {
                From = from,
                To = to,
                Weight = weight
            });
        }

        /// <summary>
        /// Time complexity O(V^2)
        /// </summary>
        /// <param name="sourceFrom"></param>
        /// <returns></returns>
        public int[] ShortestPath(int sourceFrom)
        {
            _nodeWeights[sourceFrom] = 0;

            for (var index = 1; index < _vertices; index++)
            {
                foreach (var edge in _adjacenyList)
                {
                    var from = edge.From;
                    var to = edge.To;
                    var weight = edge.Weight;
                    if (_nodeWeights[from] != int.MaxValue && 
                        _nodeWeights[from] + weight < _nodeWeights[to])
                    {
                        _nodeWeights[to] = _nodeWeights[from] + weight;
                    }
                }
            }

            // Run one more time, if weight can be decreased
            // then there is negative weight cycle
            foreach (var edge in _adjacenyList)
            {
                var from = edge.From;
                var to = edge.To;
                var weight = edge.Weight;
                if (_nodeWeights[from] != int.MaxValue &&
                    _nodeWeights[from] + weight < _nodeWeights[to])
                {
                    Console.WriteLine("Contains negative weight cycle");
                }
            }

            return _nodeWeights;
        }
    }

    public class Edge
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }
    }
}