using System;
using DataStructures.Core.Trees.Contracts;
using DataStructures.Core.Trees.Contracts.Interfaces;

namespace DataStructures.Core.Trees.BinaryTree
{
    public class BinaryTree<T> : ITree<T> where T : IComparable
    {
        public TreeNode<T> ParentNode { get; set; }
        
        public BinaryTree() { }

        public void Traverse(TraverseType traverseType)
        {
            if (traverseType == TraverseType.PreOrder)
            {
                PreOrder(ParentNode);
            }
            else if (traverseType == TraverseType.InOrder)
            {
                InOrder(ParentNode);
            }
            else if(traverseType == TraverseType.PostOrder)
            {
                PostOrder(ParentNode);
            }
        }

        #region Private methods

        private void PreOrder(TreeNode<T> node)
        {
            if(node == null) return;
            
            Console.WriteLine(node.Data);
            PreOrder(node.Left);
            PreOrder(node.Right);
        }

        private void InOrder(TreeNode<T> node)
        {
            if (node == null) return;

            InOrder(node.Left);
            Console.WriteLine(node.Data);
            InOrder(node.Right);
        }

        private void PostOrder(TreeNode<T> node)
        {
            if (node == null) return;

            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.WriteLine(node.Data);
        }
        #endregion
    }
}