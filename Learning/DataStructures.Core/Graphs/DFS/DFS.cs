using System;
using DataStructures.Core.Graphs.Contracts.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Core.Graphs.DFS
{
    public class DFS : IGraph
    {
        private bool[] _visited;
        private int[,] _adjacencyMatrix;
        private int _numberOfVertices;

        public DFS(int totalVertices)
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
            var stack = new Stack<int>();
            stack.Push(startFrom);
            _visited[startFrom] = true;
            Console.WriteLine(startFrom);

            while (stack.Any())
            {
                var current = GetAdjacentVertex(stack.Peek());
                if (current == -1) 
                    stack.Pop();
                else
                {
                    stack.Push(current);
                    Console.WriteLine(current);
                }
            }
        }

        #region Private methods

        private int GetAdjacentVertex(int vertex)
        {
            for (var current = 0; current < _numberOfVertices; current++)
            {
                if (_adjacencyMatrix[vertex, current] != 1 || _visited[current]) continue;

                _visited[current] = true;
                return current;
            }

            return -1;
        }

        #endregion
    }
}