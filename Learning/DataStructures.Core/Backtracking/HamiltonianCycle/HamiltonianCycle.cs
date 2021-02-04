using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Core.Backtracking.HamiltonianCycle
{
    public class HamiltonianCycle
    {
        private readonly int[,] _adjacencyMatrix;
        private readonly int _totalNode;

        public HamiltonianCycle(int nodes, int[,] adjacencyMatrix)
        {
            _adjacencyMatrix = adjacencyMatrix;
            _totalNode = nodes;
        }

        /// <summary>
        /// 
        /// </summary>
        public void FindAll(int startNode)
        {
            var visited = new Stack<int>(_totalNode);
            visited.Push(startNode);
            Cycles(visited, startNode);
        }

        #region Private methods

        private void Cycles(Stack<int> visited, int startNode)
        {
            if (!visited.Any())
                return;

            for (var index = startNode; index < _totalNode; index++)
            {
                if (!visited.Contains(index) && _adjacencyMatrix[visited.Peek(), index] == 1)
                {
                    visited.Push(index);
                    Cycles(visited, startNode);
                }
            }

            if (visited.Count == (_totalNode - 1) && _adjacencyMatrix[visited.Peek(), startNode] == 1)
            {
                Console.WriteLine($"{startNode},{string.Join(",", visited)}");
            }

            if (visited.Any())
                visited.Pop();
        }

        #endregion
    }
}