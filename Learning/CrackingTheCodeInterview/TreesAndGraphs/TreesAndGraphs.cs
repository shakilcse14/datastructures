using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrackingTheCodeInterview.TreesAndGraphs
{
    public class TreesAndGraphs
    {
        public int PathsWithSum(TreeNode heaTreeNode, int totalSum)
        {
            return 0;
        }

        public TreeNode ConvertMirror(TreeNode headTreeNode)
        {
            var node = ConvertToMirror(headTreeNode);
            return node;
        }

        public bool IsMirror(TreeNode headTreeNode)
        {
            return HasMirror(headTreeNode.left, headTreeNode.right);
        }

        public bool IsSubTree(TreeNode headNodeSource, TreeNode headNodeToMatch)
        {
            //var source = SubTreePreOrder(headNodeSource);
            //var target = SubTreePreOrder(headNodeToMatch);
            
            //return source.Contains(target);
            var isSub = IsSubTreeRecursion(headNodeSource, headNodeToMatch);
            return isSub;
        }

        public List<int> BuildOrderDFS(int [,] adjacencyMatrix)
        {
            var visited = new bool[(int) Math.Sqrt(adjacencyMatrix.Length)];
            var order = new Stack<int>();
            for (var index = 0; index < Math.Sqrt(adjacencyMatrix.Length); index++)
            {
                var track = new Stack<int>();
                if(!visited[index])
                    DFS(index, adjacencyMatrix, visited, order, track);
            }

            return order.ToList();
        }

        public List<int> BuildOrderBFS(int[,] adjacencyMatrix)
        {
            var adjacencyList = new List<List<int>>();
            var inDegreeList = new int[(int) Math.Sqrt(adjacencyMatrix.Length)];
            for (var indexI = 0; indexI < Math.Sqrt(adjacencyMatrix.Length); indexI++)
            {
                adjacencyList.Add(new List<int>());
                for (var indexJ = 0; indexJ < Math.Sqrt(adjacencyMatrix.Length); indexJ++)
                {
                    if (adjacencyMatrix[indexI, indexJ] == 1)
                    {
                        adjacencyList[indexI].Add(indexJ);
                        inDegreeList[indexJ]++;
                    }
                }
            }

            var queue = new Queue<int>();
            for (var index = 0; index < inDegreeList.Length; index++)
            {
                if(inDegreeList[index] == 0)
                    queue.Enqueue(index);
            }

            var count = 0;
            var result = new List<int>();
            while (queue.Any())
            {
                var node = queue.Dequeue();
                result.Add(node);
                count++;
                foreach (var index in adjacencyList[node])
                {
                    inDegreeList[index]--;
                    if(inDegreeList[index] <= 0)
                        queue.Enqueue(index);
                }
            }

            if(count < Math.Sqrt(adjacencyMatrix.Length))
                throw new Exception("Cycle detected!! Required DAG.");

            return result;
        }

        public TreeNode LowestCommonAncestorBTWithParent(TreeNode headTreeNode, TreeNode nodeA, TreeNode nodeB)
        {
            var nodeAHeight = 0;
            var nodeBHeight = 0;
            var currentNode = nodeA;
            while (currentNode != null)
            {
                nodeAHeight++;
                currentNode = currentNode.parent;
            }
            currentNode = nodeB;
            while (currentNode != null)
            {
                nodeBHeight++;
                currentNode = currentNode.parent;
            }

            var diff = nodeAHeight - nodeBHeight;
            if (diff != 0)
            {
                if (diff > 0)
                {
                    var lessHeight = diff;
                    while (lessHeight > 0 && nodeA != headTreeNode)
                    {
                        nodeA = nodeA.parent;
                        lessHeight--;
                    }
                }
                else
                {
                    var lessHeight = MathF.Abs(diff);
                    while (lessHeight > 0 && nodeB != headTreeNode)
                    {
                        nodeB = nodeB.parent;
                        lessHeight--;
                    }
                }
            }

            var lca = nodeA;
            while (nodeA != nodeB && nodeA != null && nodeB != null)
            {
                nodeA = nodeA.parent;
                nodeB = nodeB.parent;
                lca = nodeA;
            }

            return lca;
        }

        public TreeNode LowestCommonAncestorBTNoParent(TreeNode headTreeNode, TreeNode nodeA, TreeNode nodeB)
        {
            var lca = GoDepth(headTreeNode, nodeA, nodeB);
            return lca;
        }

        public TreeNode LowestCommonAncestorBST(TreeNode headTreeNode, TreeNode nodeA, TreeNode nodeB)
        {
            var lca = GoDepthBST(headTreeNode, nodeA, nodeB);
            return lca;
        }

        public TreeNode FindSuccessor(TreeNode node)
        {
            TreeNode successorNode;
            if (node.right == null)
            {
                var currentNode = node.parent;
                var tempNode = node;
                while (currentNode != null && currentNode.right == tempNode)
                {
                    tempNode = currentNode;
                    currentNode = currentNode.parent;
                }

                successorNode = currentNode ?? tempNode;
            }
            else
            {
                var currentNode = node.right;
                while (currentNode.left != null)
                {
                    currentNode = currentNode.left;
                }

                successorNode = currentNode;
            }

            return successorNode;
        }

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

        private bool HasMirror(TreeNode nodeLeft, TreeNode nodeRight)
        {
            if (nodeLeft == null && nodeRight == null)
                return true;

            if (nodeLeft == null || nodeRight == null)
                return false;

            if (nodeLeft.val.Equals(nodeRight.val))
                return HasMirror(nodeLeft.left, nodeRight.right) && 
                       HasMirror(nodeLeft.right, nodeRight.left);

            return false;
        }

        private TreeNode ConvertToMirror(TreeNode node)
        {
            if(node == null)
                return null;

            var right = ConvertToMirror(node.right);
            var left = ConvertToMirror(node.left);

            node.left = right;
            node.right = left;

            return node;
        }

        private void DFS(int node, int[,] adjacencyMatrix, bool[] visited, Stack<int> stack, Stack<int> track)
        {
            visited[node] = true;
            for (var index = 0; index < Math.Sqrt(adjacencyMatrix.Length); index++)
            {
                if (track.Contains(index) && adjacencyMatrix[node, index] == 1 && visited[index])
                    throw new Exception("Cycle detected!! Required DAG.");

                if (adjacencyMatrix[node, index] == 1 && !visited[index])
                {
                    track.Push(node);
                    DFS(index, adjacencyMatrix, visited, stack, track);
                }
            }
            stack.Push(node);
        }

        private TreeNode GoDepth(TreeNode node, TreeNode nodeA, TreeNode nodeB)
        {
            if (node == null)
                return null;

            if (node == nodeA || node == nodeB)
                return node;

            TreeNode left = null;
            TreeNode right = null;

            if (node.left == nodeA || node.left == nodeB)
                left = node.left == nodeA ? nodeA : nodeB;
            if (node.right == nodeA || node.right == nodeB)
                right = node.right == nodeA ? nodeA : nodeB;

            if(left == null)
                left = GoDepth(node.left, nodeA, nodeB);
            if(right == null)
                right = GoDepth(node.right, nodeA, nodeB);
            if (left != null && right != null)
                return node;

            return left ?? right;
        }

        private TreeNode GoDepthBST(TreeNode node, TreeNode nodeA, TreeNode nodeB)
        {
            if (node.val == nodeA.val || node.val == nodeB.val)
                return node;

            if (node.val > nodeA.val && node.val > nodeB.val)
                return GoDepthBST(node.left, nodeA, nodeB);
            if (node.val < nodeA.val && node.val < nodeB.val)
                return GoDepthBST(node.right, nodeA, nodeB);

            return node;
        }

        private bool IsEqual(TreeNode nodeA, TreeNode nodeB)
        {
            if (nodeA == null && nodeB == null)
                return true;
            if (nodeA == null || nodeB == null)
                return false;

            return nodeA.val.Equals(nodeB.val) && 
                IsEqual(nodeA.left, nodeB.left) && 
                IsEqual(nodeA.right, nodeB.right);
        }

        private bool IsSubTreeRecursion(TreeNode headNodeSource, TreeNode headNodeToMatch)
        {
            return headNodeSource != null && (IsEqual(headNodeSource, headNodeToMatch) ||
                                              IsSubTreeRecursion(headNodeSource.left, headNodeToMatch) ||
                                              IsSubTreeRecursion(headNodeSource.right, headNodeToMatch));
        }

        private string SubTreePreOrder(TreeNode headNodeSource)
        {
            if (headNodeSource == null)
                return ".";

            var value = headNodeSource.val.ToString();
            value += SubTreePreOrder(headNodeSource.left);
            value += SubTreePreOrder(headNodeSource.right);

            return value;
        }

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
        public TreeNode parent { get; set; }
    }
}