using System;
using System.Data;

namespace DataStructures.Core.Trees.AVLTree
{
    public class AVLTree
    {
        private Node _root;

        public AVLTree() { }

        /// <summary>
        /// Time complexity O(logN)
        /// </summary>
        /// <param name="data"></param>
        public void Insert(int data)
        {
            _root = InsertRecursive(_root, data);
        }

        /// <summary>
        /// Time complexity O(logN)
        /// </summary>
        /// <param name="data"></param>
        public void Delete(int data)
        {
            _root = DeleteRecursive(_root, data);
        }

        public void PreOrder()
        {
            PreOrder(_root);
        }

        #region Private methods

        private Node LeftRotation(Node node)
        {
            var temp = node.RightChild;
            node.RightChild = node.RightChild.LeftChild;
            temp.LeftChild = node;

            node.Height = 1 + Math.Max(GetHeight(node.LeftChild), GetHeight(node.RightChild));
            temp.Height = 1 + Math.Max(GetHeight(temp.LeftChild), GetHeight(temp.RightChild));

            return temp;
        }

        private Node RightRotation(Node node)
        {
            var temp = node.LeftChild;
            node.LeftChild = node.LeftChild.RightChild;
            temp.RightChild = node;

            node.Height = 1 + Math.Max(GetHeight(node.LeftChild), GetHeight(node.RightChild));
            temp.Height = 1 + Math.Max(GetHeight(temp.LeftChild), GetHeight(temp.RightChild));

            return temp;
        }

        private void PreOrder(Node node)
        {
            if(node == null)
                return;

            Console.Write($"{node.Data} ");
            PreOrder(node.LeftChild);
            PreOrder(node.RightChild);
        }

        private int GetBalance(Node node)
        {
            if (node == null)
                return 0;

            return GetHeight(node.LeftChild) - GetHeight(node.RightChild);
        }

        private int GetHeight(Node node)
        {
            if (node == null)
                return 0;

            return node.Height;
        }

        private Node MaxValue(Node node)
        {
            if (node.RightChild == null)
                return node;

            return MaxValue(node.RightChild);
        }

        private Node DeleteRecursive(Node node, int data)
        {
            if (node == null)
                return null;

            if (node.Data > data)
                node.LeftChild = DeleteRecursive(node.LeftChild, data);
            else if (node.Data < data)
                node.RightChild = DeleteRecursive(node.RightChild, data);
            else
            {
                // Match found
                if (node.LeftChild == null && node.RightChild == null)
                    node = null;
                else if (node.LeftChild == null)
                    node = node.RightChild;
                else if (node.RightChild == null)
                    node = node.LeftChild;
                else
                {
                    var tempNode = MaxValue(node.LeftChild);
                    node.Data = tempNode.Data;
                    node.LeftChild = DeleteRecursive(node.LeftChild, tempNode.Data);
                }

            }

            // Check traversed every node's balance
            if (node == null)
                return node;

            node.Height = 1 + Math.Max(GetHeight(node.LeftChild), GetHeight(node.RightChild));

            var balance = GetBalance(node);

            if (node.LeftChild != null)
            {
                if (balance > 1 && GetBalance(node.LeftChild) >= 0)
                {
                    // LL
                    node = RightRotation(node);
                }

                if (balance > 1 && GetBalance(node.LeftChild) < 0)
                {
                    // LR
                    node.LeftChild = LeftRotation(node.LeftChild);
                    node = RightRotation(node);
                }
            }

            if (node.RightChild != null)
            {
                if (balance < -1 && GetBalance(node.RightChild) <= 0)
                {
                    // RR
                    node = LeftRotation(node);
                }

                if (balance < -1 && GetBalance(node.RightChild) > 0)
                {
                    // RL
                    node.RightChild = RightRotation(node.RightChild);
                    node = LeftRotation(node);
                }
            }

            return node;
        }

        private Node InsertRecursive(Node node, int data)
        {
            if (node == null)
                return new Node()
                {
                    Data = data
                };

            if (node.Data < data)
                node.RightChild = InsertRecursive(node.RightChild, data);
            else if (node.Data > data)
                node.LeftChild = InsertRecursive(node.LeftChild, data);
            else
                throw new DuplicateNameException();

            node.Height = 1 + Math.Max(GetHeight(node.LeftChild), GetHeight(node.RightChild));

            var balance = GetBalance(node);

            if (node.LeftChild != null)
            {
                if (balance > 1 && data < node.LeftChild.Data)
                {
                    // LL
                    node = RightRotation(node);
                }
                if (balance > 1 && data > node.LeftChild.Data)
                {
                    // LR
                    node.LeftChild = LeftRotation(node.LeftChild);
                    node = RightRotation(node);
                }
            }

            if (node.RightChild != null)
            {
                if (balance < -1 && data > node.RightChild.Data)
                {
                    // RR
                    node = LeftRotation(node);
                }
                if (balance < -1 && data < node.RightChild.Data)
                {
                    // RL
                    node.RightChild = RightRotation(node.RightChild);
                    node = LeftRotation(node);
                }
            }

            return node;
        }

        #endregion
    }

    public class Node
    {
        public int Data { get; set; }
        public int Height { get; set; } = 1;

        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
    }
}