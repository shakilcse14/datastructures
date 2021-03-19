using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.TreesAndGraphs
{
    public class TreesAndGraphs
    {
        public bool IsRouteBetweenNodesBfs(int[,] adjacencyMatrix, int source, int target)
        {
            var visited = new bool[(int) Math.Sqrt(adjacencyMatrix.Length)];
            var queue = new Queue<int>();
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                visited[node] = true;
                var connectedNodes = GetUnVisitedConnectedNodes(node, adjacencyMatrix, visited);
                foreach (var connectedNode in connectedNodes)
                {
                    if (connectedNode.Equals(target))
                        return true;
                    queue.Enqueue(connectedNode);
                }
            }

            return false;
        }

        public bool IsRouteBetweenNodesDfs(int[,] adjacencyMatrix, int source, int target)
        {
            var visited = new bool[(int) Math.Sqrt(adjacencyMatrix.Length)];
            var stack = new Stack<int>();
            stack.Push(source);
            while (stack.Count > 0)
            {
                var connectedNode = GetUnVisitedConnectedNode(stack.Peek(), adjacencyMatrix, visited);
                if (connectedNode.Equals(target))
                    return true;
                if (connectedNode == -1)
                    stack.Pop();
                else
                {
                    visited[connectedNode] = true;
                    stack.Push(connectedNode);
                }
            }

            return false;
        }

        #region Private methods

        private int GetUnVisitedConnectedNode(int node, int[,] adjacencyMatrix, bool[] visited)
        {
            for (var index = 0; index < Math.Sqrt(adjacencyMatrix.Length); index++)
            {
                if (!visited[index] && adjacencyMatrix[node, index] == 1)
                    return index;
            }

            return -1;
        }

        private List<int> GetUnVisitedConnectedNodes(int node, int[,] adjacencyMatrix, IReadOnlyList<bool> visited)
        {
            var connectedNodes = new List<int>();
            for (var index = 0; index < Math.Sqrt(adjacencyMatrix.Length); index++)
            {
                if(adjacencyMatrix[node, index] == 1 && !visited[index])
                    connectedNodes.Add(index);
            }

            return connectedNodes;
        }

        #endregion
    }
}