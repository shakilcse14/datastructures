using System;
using System.Collections.Generic;
using DataStructures.Core.Trees.BinaryTree;
using DataStructures.Core.Trees.Contracts;

namespace DataStructures.Core.Trees.BinarySearchTree
{
    public class BinarySearchTree<T> : BinaryTree<T>, IBinarySearchTree<T> where T : IComparable
    {
        /// <summary>
        /// Time complexity O(logn)
        /// </summary>
        /// <param name="data"></param>
        public void Insert(T data)
        {
            var node = ParentNode;
            if (node == null)
            {
                ParentNode = new TreeNode<T>()
                {
                    Data = data
                };
                return;
            }
            while (node != null)
            {
                if (data.CompareTo(node.Data) > 0)
                {
                    if (node.Right == null)
                    {
                        node.Right = new TreeNode<T>()
                        {
                            Data = data
                        };
                        break;
                    }
                    node = node.Right;
                }
                else
                {
                    if (node.Left == null)
                    {
                        node.Left = new TreeNode<T>()
                        {
                            Data = data
                        };
                        break;
                    }
                    node = node.Left;
                }
            }
        }

        /// <summary>
        /// Time complexity O(logn)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Contains(T data)
        {
            var node = ParentNode;
            while (node != null)
            {
                if (data.CompareTo(node.Data) > 0)
                    node = node.Right;
                else if (data.CompareTo(node.Data) < 0)
                    node = node.Left;
                else
                    return true;
            }
            return false;
        }

        public void Remove(T data)
        {
            //DeleteIterativeProcess(data);
            ParentNode = Delete(ParentNode, data);
        }

        #region Private methods

        private TreeNode<T> Delete(TreeNode<T> currentNode, T data)
        {
            if (currentNode == null)
                return null;

            if (data.CompareTo(currentNode.Data) > 0)
            {
                currentNode.Right = Delete(currentNode.Right, data);
            }
            else if (data.CompareTo(currentNode.Data) < 0)
            {
                currentNode.Left = Delete(currentNode.Left, data);
            }
            else
            {
                if (currentNode.Left == null)
                    return currentNode.Right;
                if (currentNode.Right == null)
                    return currentNode.Left;

                var leftSubTreeMax = FindLeftSubTreeMaxItem(currentNode.Left);
                currentNode.Data = leftSubTreeMax.Data;
                currentNode.Left = Delete(currentNode.Left, leftSubTreeMax.Data);
            }

            return currentNode;
        }

        private TreeNode<T> FindLeftSubTreeMaxItem(TreeNode<T> node)
        {
            while (node.Right != null)
            {
                node = node.Right;
            }

            return node;
        }

        private void DeleteIterativeProcess(T data)
        {
            var node = ParentNode;
            TreeNode<T> parentNode = null;
            while (node != null)
            {
                if (data.CompareTo(node.Data) > 0)
                {
                    parentNode = node;
                    node = node.Right;
                }
                else if (data.CompareTo(node.Data) < 0)
                {
                    parentNode = node;
                    node = node.Left;
                }
                else
                    break;
            }

            if (node == null) throw new InvalidOperationException();

            if ((node.Left == null || node.Right == null) && parentNode != null)
            {
                if (parentNode.Left == node) parentNode.Left = node.Left ?? node.Right;
                if (parentNode.Right == node) parentNode.Right = node.Right ?? node.Left;
            }
            else
            {
                var leftSubTreeMax = node.Left;
                var parentOfLeftSubTreeMax = node;
                while (leftSubTreeMax.Right != null)
                {
                    parentOfLeftSubTreeMax = leftSubTreeMax;
                    leftSubTreeMax = leftSubTreeMax.Right;
                }

                if (parentOfLeftSubTreeMax.Left == leftSubTreeMax) parentOfLeftSubTreeMax.Left = null;
                if (parentOfLeftSubTreeMax.Right == leftSubTreeMax) parentOfLeftSubTreeMax.Right = null;

                if (parentNode == null)
                {
                    node.Data = leftSubTreeMax.Data;
                    return;
                }

                if (parentNode.Left == node)
                {
                    parentNode.Left = leftSubTreeMax;
                }

                if (parentNode.Right == node)
                {
                    parentNode.Right = leftSubTreeMax;
                }
            }
        }

        #endregion
    }
}