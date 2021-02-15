using System;
using System.Text;

namespace DataStructures.Core.Graphs.ArticulationPoint
{
    public class ArticulationPoint
    {
        private readonly int _numberOfVertices;
        private readonly bool[,] _adjacencyMatrix;
        private readonly bool[] _visited;
        private readonly int[] _parent;
        private readonly int[] _low;
        private readonly int[] _childCount;
        private readonly int[] _discoveryTime;
        private readonly bool[] _articulationPoint;

        private int _timer = 0;


        public ArticulationPoint(int vertices, bool[,] adjacencyMatrix)
        {
            _numberOfVertices = vertices;
            _adjacencyMatrix = adjacencyMatrix;

            _visited = new bool[vertices];
            _parent = new int[vertices];
            _low = new int[vertices];
            _discoveryTime = new int[vertices];
            _articulationPoint = new bool[vertices];
            _childCount = new int[vertices];
        }

        public string Find()
        {
            for (var index = 0; index < _numberOfVertices; index++)
            {
                _visited[index] = false;
                _discoveryTime[index] = -1;
                _low[index] = -1;
                _parent[index] = -1;
                _parent[index] = 0;
                _articulationPoint[index] = false;
            }

            _visited[0] = true;
            _discoveryTime[0] = _timer;
            _low[0] = _timer;
            _parent[0] = -1;
            _childCount[0] = 0;
            FindArticulationPoint(0);

            var articulationPoints = new StringBuilder();
            for (var index = 0; index < _numberOfVertices; index++)
            {
                if (_articulationPoint[index])
                    articulationPoints.Append($"{index},");
            }

            return articulationPoints.ToString().TrimEnd(',');
        }

        #region Private methods

        private void FindArticulationPoint(int node)
        {
            for (var index = 0; index < _numberOfVertices; index++)
            {
                if (_adjacencyMatrix[node, index])
                {
                    if (!_visited[index])
                    {
                        _timer++;
                        _visited[index] = true;
                        _discoveryTime[index] = _timer;
                        _low[index] = _timer;
                        _parent[index] = node;

                        _childCount[node]++;
                        FindArticulationPoint(index);
                        _low[node] = Math.Min(_low[node], _low[index]);
                    }

                    // Back edge
                    else if (_visited[index] && _parent[node] != index)
                    {
                        _low[node] = _discoveryTime[index];
                    }
                }
            }

            // root ap check
            if (_parent[node] == -1)
            {
                if (_childCount[node] > 1)
                    _articulationPoint[node] = true;
            }
            // non-root ap check
            else
            {
                for (var index = 0; index < _numberOfVertices; index++)
                {
                    if (_adjacencyMatrix[node, index] && _low[index] >= _discoveryTime[node])
                    {
                        _articulationPoint[node] = true;
                        break;
                    }
                }
            }
        }

        #endregion
    }
}