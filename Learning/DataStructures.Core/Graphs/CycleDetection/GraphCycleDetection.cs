using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Core.Graphs.CycleDetection
{
    public class GraphCycleDetection
    {
        private readonly GraphType _graphType;
        private readonly int[,] _edges;

        private bool[] _visited;

        public GraphCycleDetection(int vertices, GraphType graphGraphType)
        {
            _graphType = graphGraphType;
            _edges = new int[vertices, vertices];

            _visited = new bool[vertices];
            for (var index = 0; index < vertices; index++)
            {
                _visited[index] = false;
            }
        }

        public void AddEdge(int from, int to)
        {
            _edges[from, to] = 1;
            if (_graphType == GraphType.UnDirected)
                _edges[to, from] = 1;
        }

        public bool HasCycle()
        {
            return _graphType == GraphType.UnDirected ? UnDirectedCycle() : DirectedCycle();
        }

        #region Private methods

        private bool UnDirectedCycle()
        {
            var parent = -1;
            var node = 0;
            _visited[node] = true;

            return AdjacentNode(parent, node);
        }

        private bool AdjacentNode(int parent, int node)
        {
            for (var index = 0; index < _visited.Length; index++)
            {
                if (!_visited[index] && _edges[node, index] == 1)
                {
                    _visited[index] = true;
                    var result = AdjacentNode(node, index);
                    if (result)
                        return true;

                    parent = index;
                }

                if (_visited[index] && _edges[node, index] == 1 && parent != index)
                    return true;
            }

            return false;
        }

        private bool DirectedCycle()
        {
            var stack = new Stack<int>();
            var node = 0;
            stack.Push(node);
            _visited[node] = true;
            while (stack.Any())
            {
                node = stack.Peek();
                var noChild = true;
                for (var index = 0; index < _visited.Length; index++)
                {
                    if (!_visited[index] && _edges[node, index] == 1)
                    {
                        _visited[index] = true;
                        stack.Push(index);
                        noChild = false;
                        break;
                    }
                    if (_visited[index] && _edges[node, index] == 1 && stack.Contains(index))
                    {
                        return true;
                    }
                }

                if (noChild)
                    stack.Pop();
            }

            return false;
        }

        #endregion
    }

    public enum GraphType
    {
        Directed,
        UnDirected
    }
}