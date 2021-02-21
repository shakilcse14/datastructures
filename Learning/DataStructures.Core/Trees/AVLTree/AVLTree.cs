using System;
using System.Data;

namespace DataStructures.Core.Trees.AVLTree
{
    public class AVLTree
    {
        private Node _root;

        public AVLTree() { }

        /// <summary>
        /// Time complexity O(logn)
        /// </summary>
        /// <param name="data"></param>
        public void Insert(int data)
        {
            _root = InsertRecursive(_root, data);
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