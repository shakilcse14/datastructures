using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Core.Backtracking.GraphColoring
{
    public class GraphColoring
    {
        private readonly int _numberOfColors;
        private readonly int _totalNodes;

        private readonly int[,] _adjacenyMatrix;
        
        public GraphColoring(int numberOfColors, int totalNode, int[,] adjacenyMatrix)
        {
            _numberOfColors = numberOfColors;
            _totalNodes = totalNode;

            _adjacenyMatrix = adjacenyMatrix;
        }

        /// <summary>
        /// Time complexity O(n^m)
        /// </summary>
        public void Find()
        {
            BacktrackingApproach();
            BfsApproach();
        }

        #region Private methods

        private void BfsApproach()
        {
            Console.WriteLine("\n");
            var visited = new bool[_totalNodes];
            var verticesColor = new int[_totalNodes];
            var queue = new Queue<int>();
            var color = 0;
            while (color < _numberOfColors)
            {
                queue.Clear();
                for (var index = 0; index < _totalNodes; index++)
                {
                    verticesColor[index] = color;
                    visited[index] = false;
                }
                queue.Enqueue(0);
                visited[0] = true;
                while (queue.Any())
                {
                    var currentNode = queue.Dequeue();
                    visited[currentNode] = true;
                    var connectedNodes = ConnectedNodes(currentNode, visited);
                    if (connectedNodes.Count > _numberOfColors)
                    {
                        Console.WriteLine("Not possible");
                    }
                    foreach (var node in connectedNodes)
                    {
                        if (verticesColor[currentNode] == verticesColor[node])
                            verticesColor[node] += 1;
                        if (verticesColor[node] >= _numberOfColors)
                            verticesColor[node] = 0;
                        queue.Enqueue(node);
                    }
                }

                color++;
                Console.WriteLine($"{string.Join(",", verticesColor)}");
            }
        }

        private List<int> ConnectedNodes(int node, bool[] visited)
        {
            var list = new List<int>();
            for (var index = 0; index < _totalNodes; index++)
            {
                if (_adjacenyMatrix[node, index] == 1 && !visited[index])
                {
                    list.Add(index);
                }
            }

            return list;
        }

        private void BacktrackingApproach()
        {
            var verticesColor = new int[_totalNodes];
            for (var index = 0; index < _totalNodes; index++)
            {
                verticesColor[index] = -1;
            }

            Backtracking(0, verticesColor);
        }

        private void Backtracking(int node, int[] verticesColor)
        {
            if (node == _totalNodes)
            {
                Console.WriteLine($"{string.Join(",", verticesColor)}");
                verticesColor[node - 1] = -1;
                return;
            }

            for (var colorIndex = 0; colorIndex < _numberOfColors; colorIndex++)
            {
                if (CanSetColor(node, colorIndex, verticesColor))
                {
                    verticesColor[node] = colorIndex;
                    Backtracking(node + 1, verticesColor);
                }
            }

            verticesColor[node] = -1;
        }

        private bool CanSetColor(int node, int color, int[] verticesColor)
        {
            for (var index = 0; index < _totalNodes; index++)
            {
                if (_adjacenyMatrix[node, index] == 1 && verticesColor[index] == color)
                    return false;
            }

            return true;
        }

        #endregion
    }
}