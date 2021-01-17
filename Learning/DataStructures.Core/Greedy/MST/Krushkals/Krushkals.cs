using System;
using System.Collections.Generic;

namespace DataStructures.Core.Greedy.MST.Krushkals
{
    public class Krushkals
    {
        private Edge[] _edges;
        private int[] _subSets;
        private int _count = 0;

        public Krushkals(int vertices, int edges)
        {
            _edges = new Edge[edges];
            _subSets = new int[vertices];
        }

        public void AddEdge(int from, int to, int weight)
        {
            if(_count >= _edges.Length)
                return;

            _edges[_count++] = new Edge()
            {
                From = from,
                To = to,
                Weight = weight
            };
        }

        /// <summary>
        /// Time complexity O(ELogV)
        /// </summary>
        public List<Tuple<string, int>> MinimumSpanningTree()
        {
            var selectedEdges = new List<Tuple<string, int>>();
            
            // O(ELogE)
            Array.Sort(_edges);

            for (var index = 0; index < _subSets.Length; index++)
            {
                _subSets[index] = -1;
            }

            for (var indexI = 0; indexI < _subSets.Length; indexI++)
            {
                var edge = _edges[indexI];
                var fromParent = Find(edge.From);
                var toParent = Find(edge.To);
                if (fromParent != toParent)
                {
                    Union(edge, fromParent, toParent);
                    selectedEdges.Add(Tuple.Create($"{edge.From} - {edge.To}", edge.Weight));
                }
                else
                {
                    Console.WriteLine("Will create cycle.");
                }
            }

            return selectedEdges;
        }

        #region Private methods

        private void Union(Edge edge, int fromParent, int toParent)
        {
            if (Math.Abs(fromParent) >= Math.Abs(toParent))
            {
                _subSets[fromParent] = _subSets[fromParent] + _subSets[toParent];
                _subSets[toParent] = fromParent;
            }
            else
            {
                _subSets[toParent] = _subSets[fromParent] + _subSets[toParent];
                _subSets[fromParent] = toParent;
            }
        }

        private int Find(int index)
        {
            if (_subSets[index] <= -1)
                return index;

            return Find(_subSets[index]);
        }

        #endregion
    }

    public class Edge : IComparable<Edge>
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }
}