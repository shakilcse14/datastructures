using System;
using DataStructures.Core.Graphs.Contracts.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Core.Graphs.DFS
{
    public class DFS : IGraph
    {
        private bool[] _visited;
        private LinkedList<int>[] _adjacencyList;
        private int _numberOfVertices;

        public DFS(int totalVertices)
        {
            _numberOfVertices = totalVertices;
            _visited = new bool[totalVertices];
            _adjacencyList = new LinkedList<int>[totalVertices];

            for (var i = 0; i < totalVertices; i++)
            {
                _adjacencyList[i] = new LinkedList<int>();
            }
        }

        public void AddEdge(int from, int to)
        {
            _adjacencyList[from].AddLast(to);
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
            foreach (var current in _adjacencyList[vertex]
                .Where(current => !_visited[current]))
            {
                _visited[current] = true;
                return current;
            }

            return -1;
        }

        #endregion
    }
}