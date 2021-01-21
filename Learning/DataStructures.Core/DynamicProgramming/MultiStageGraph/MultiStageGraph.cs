using System;
using System.Text;

namespace DataStructures.Core.DynamicProgramming.MultiStageGraph
{
    public class MultiStageGraph
    {
        private readonly int _vertices;
        private readonly int[,] _adjacencyMatrix;

        public MultiStageGraph(int vertices, int[,] adjacencyMatrix)
        {
            _vertices = vertices;
            _adjacencyMatrix = adjacencyMatrix;
        }

        /// <summary>
        /// Time complexity O(n^2)
        /// </summary>
        public Tuple<int, string> ShortestPath()
        {
            var distance = new int[_vertices];
            var path = new int[_vertices];

            distance[_vertices - 1] = 0;
            for (var indexI = _vertices - 2; indexI >= 0; indexI--)
            {
                distance[indexI] = int.MaxValue;
                for (var indexJ = indexI; indexJ < _vertices; indexJ++)
                {
                    if (_adjacencyMatrix[indexI, indexJ] == int.MaxValue)
                        continue;

                    distance[indexI] = Math.Min(distance[indexI], _adjacencyMatrix[indexI, indexJ] + distance[indexJ]);
                    path[indexI] = indexJ;
                }
            }

            var pathString = new StringBuilder();
            for (var index = 0; index < path.Length - 1;)
            {
                index = path[index];
                pathString.Append(index + ">");
            }

            return Tuple.Create(distance[0], pathString.ToString().TrimEnd('>'));
        }
    }
}