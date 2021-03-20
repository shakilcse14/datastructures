using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.TreesAndGraphs
{
    public class TreesAndGraphs
    {
        public bool IsValidBinarySearchTree(TreeNode headNode)
        {
            return IsValid(headNode, double.MinValue, double.MaxValue);
        }

        public bool IsBalancedTree(TreeNode headNode)
        {
            return IsBalanced(headNode);
        }

        public List<LinkedList<int>> ListOfDepths(TreeNode headNode)
        {
            var lists = new List<LinkedList<int>>();
            PreOrderTraverseLevelTrack(headNode, 0, lists);
            return lists;
        }

        public TreeNode MinimalTree(int[] array)
        {
            var node = GenerateNode(0, array.Length, array);

            return node;
        }

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

        private bool IsValid(TreeNode node, double min, double max)
        {
            if (node == null)
                return true;
            if (node.val <= min || node.val >= max)
                return false;
            return IsValid(node.left, min, node.val) && IsValid(node.right, node.val, max);
        }

        private int GetHeight(TreeNode node)
        {
            if (node == null)
                return -1;

            return 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
        }

        private bool IsBalanced(TreeNode node)
        {
            if (node == null)
                return true;

            var leftHeight = GetHeight(node.left);
            var rightHeight = GetHeight(node.right);
            var height = leftHeight - rightHeight;
            if (Math.Abs(height) > 1)
                return false;

            return IsBalancedTree(node.left) && IsBalancedTree(node.right);
        }

        private void PreOrderTraverseLevelTrack(TreeNode node, int level, List<LinkedList<int>> lists)
        {
            if (node == null)
                return;

            if (lists.Count <= level)
            {
                var linkedList = new LinkedList<int>();
                linkedList.AddLast(node.val);
                lists.Add(linkedList);
            }
            else
                lists[level].AddLast(node.val);

            PreOrderTraverseLevelTrack(node.left, level + 1, lists);
            PreOrderTraverseLevelTrack(node.right, level + 1, lists);
        }

        private TreeNode GenerateNode(int left, int right, int[] array)
        {
            if (left >= right)
                return null;

            var mid = (left + right) / 2;
            var node = new TreeNode
            {
                val = array[mid], 
                left = GenerateNode(left, mid, array),
                right = GenerateNode(mid + 1, right, array)
            };

            return node;
        }

        private int GetUnVisitedConnectedNode(int node, int[,] adjacencyMatrix, IReadOnlyList<bool> visited)
        {
            for (var index = 0; index < Math.Sqrt(adjacencyMatrix.Length); index++)
            {
                if (!visited[index] && adjacencyMatrix[node, index] == 1)
                    return index;
            }

            return -1;
        }

        private IEnumerable<int> GetUnVisitedConnectedNodes(int node, int[,] adjacencyMatrix, IReadOnlyList<bool> visited)
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

    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
    }
}