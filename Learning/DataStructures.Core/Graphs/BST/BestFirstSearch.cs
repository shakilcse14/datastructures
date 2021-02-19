using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Core.Graphs.BST
{
    public class BestFirstSearch
    {
        private readonly Dictionary<int, Dictionary<int, int>> _list;

        public BestFirstSearch()
        {
            _list = new Dictionary<int, Dictionary<int, int>>();
        }

        public void AddEdge(int from, int to, int weight)
        {
            if(!_list.ContainsKey(from))
                _list.Add(from, new Dictionary<int, int>());
            if (!_list.ContainsKey(to))
                _list.Add(to, new Dictionary<int, int>());

            _list[from][to] = weight;
            _list[to][from] = weight;
        }

        public void Find(int start, int goal)
        {
            var sortedSet = new SortedSet<Tuple<int, int>>(new TupleComparer());// node, weight
            var visited = new Dictionary<int, bool>();
            sortedSet.Add(Tuple.Create(start, 0));
            visited[start] = true;

            while (sortedSet.Count > 0)
            {
                var top = sortedSet.First();
                sortedSet.Remove(top);
                visited[top.Item1] = true;
                Console.WriteLine(top.Item1);
                if (top.Item1.Equals(goal))
                    break;
                foreach (var val in _list[top.Item1])
                {
                    if(visited.ContainsKey(val.Key) && visited[val.Key])
                        continue;

                    sortedSet.Add(Tuple.Create(val.Key, val.Value));
                }
            }
        }

        #region Private methods


        public class TupleComparer : IComparer<Tuple<int, int>>
        {
            public int Compare(Tuple<int, int> x, Tuple<int, int> y)
            {
                if (x == null || y == null)
                    throw new InvalidOperationException();

                var result = x.Item2.CompareTo(y.Item2);

                return result;
            }
        }

        #endregion
    }
}