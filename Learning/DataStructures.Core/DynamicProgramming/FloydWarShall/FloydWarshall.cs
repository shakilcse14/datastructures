using System;

namespace DataStructures.Core.DynamicProgramming.FloydWarShall
{
    /// <summary>
    /// All pairs shortest path
    /// </summary>
    public class FloydWarshall
    {
        public FloydWarshall() { }

        /// <summary>
        /// Time complexity O(V^3)
        /// </summary>
        public int[,] AllPairShortestPaths(int[,] adjacencyMatrix)
        {
            var vertices = Math.Sqrt(adjacencyMatrix.Length);
            for (var index = 0; index < vertices; index++)
            {
                for (var indexI = 0; indexI < vertices; indexI++)
                {
                    if(indexI == index)
                        continue;
                    for (var indexJ = 0; indexJ < vertices; indexJ++)
                    {
                        if (indexJ == index)
                            continue;
                        if (indexI == indexJ)
                            continue;
                        int value;
                        if (adjacencyMatrix[indexI, index] == int.MaxValue ||
                            adjacencyMatrix[index, indexJ] == int.MaxValue)
                        {
                            value = int.MaxValue;
                        }
                        else
                        {
                            value = adjacencyMatrix[indexI, index] + adjacencyMatrix[index, indexJ];
                        }
                        if (adjacencyMatrix[indexI, indexJ] > value)
                            adjacencyMatrix[indexI, indexJ] = value;
                    }
                }
            }

            return adjacencyMatrix;
        }
    }
}