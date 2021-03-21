using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Core.Graphs.ToplogicalSort
{
    public class TopologicalSort
    {
        public TopologicalSort() { }

        public List<int> Sort(int [,] adjacencyMatrix)
        {
            var stack = new Stack<int>();
            var visited = new bool[(int) Math.Sqrt(adjacencyMatrix.Length)];
            for (var index = 0; index < Math.Sqrt(adjacencyMatrix.Length); index++)
            {
                if(!visited[index])
                    DFS(index, adjacencyMatrix, stack, visited);
            }

            return stack.ToList();
        }

        #region Private methods

        private void DFS(int node, int[,] adjacencyMatrix, Stack<int> stack, bool[] visited)
        {
            visited[node] = true;
            for (var index = 0; index < Math.Sqrt(adjacencyMatrix.Length); index++)
            {
                if (adjacencyMatrix[node, index] == 1 && !visited[index])
                {
                    DFS(index, adjacencyMatrix, stack, visited);
                }
            }
            stack.Push(node);
        }

        #endregion
    }
}