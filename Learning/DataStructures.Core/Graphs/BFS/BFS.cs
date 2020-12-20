using System;
using System.Collections.Generic;
using DataStructures.Core.Graphs.Contracts.Interfaces;

namespace DataStructures.Core.Graphs.BFS
{
    public class BFS : IGraph
    {
        private bool[] _visited;
        private int[,] _adjacencyMatrix;
        private int _numberOfVertices;

        public BFS(int totalVertices)
        {
            _numberOfVertices = totalVertices;
            _visited = new bool[totalVertices];
            _adjacencyMatrix = new int[totalVertices, totalVertices];
        }

        public void AddEdge(int from, int to)
        {
            _adjacencyMatrix[from, to] = 1;
        }

        public void Traverse(int startFrom)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startFrom);
            
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                _visited[current] = true;
                Console.WriteLine(current);

                var connectedVertices = GetAdjacentVertices(current);
                connectedVertices.ForEach(x => queue.Enqueue(x));
            }
        }

        #region Private methods

        private List<int> GetAdjacentVertices(int vertex)
        {
            var connectedVertices = new List<int>();
            for (var current = 0; current < _numberOfVertices; current++)
            {
                if(_adjacencyMatrix[vertex, current] == 1 && !_visited[current])
                    connectedVertices.Add(current);
            }
            return connectedVertices;
        }

        #endregion
    }
}