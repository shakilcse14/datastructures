using System.Collections.Generic;

namespace CrackingTheCodeInterview.LinkedLists
{
    public class LinkedLists
    {
        /// <summary>
        /// Time complexity O(n^2)
        /// </summary>
        /// <param name="headListNode"></param>
        public void RemoveDuplicatesFromUnSortedNoSpace(ListNode headListNode)
        {
            var firstNode = headListNode;

            while (firstNode != null)
            {
                var secondNode = firstNode.Next;
                var preSecondNode = firstNode;
                while (secondNode != null)
                {
                    if (firstNode.Data.Equals(secondNode.Data))
                    {
                        preSecondNode.Next = secondNode.Next;
                    }
                    else
                        preSecondNode = secondNode;

                    secondNode = secondNode.Next;
                }

                firstNode = firstNode.Next;
            }
        }

        /// <summary>
        /// Time complexity O(n), space complexity O(n)
        /// </summary>
        /// <param name="headListNode"></param>
        public void RemoveDuplicatesFromUnSorted(ListNode headListNode)
        {
            var dictionary = new Dictionary<string, ListNode>();
            var node = headListNode.Next;
            var prevNode = headListNode;
            dictionary.Add(prevNode.Data, prevNode);
            while (node != null)
            {
                if (dictionary.ContainsKey(node.Data))
                {
                    prevNode.Next = node.Next;
                }
                else
                {
                    dictionary.Add(node.Data, node);
                    prevNode = node;
                }

                node = node.Next;
            }
        }

        public string ReturnKthLastElement(ListNode headListNode, int kEnd)
        {
            //KthLastElement(headListNode, kEnd);
            return IterativeTwoPointerKthLastElement(headListNode, kEnd);
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public void DeleteMiddleNode(ListNode node)
        {
            if (node.Next == null) return;

            node.Data = node.Next.Data;
            node.Next = node.Next.Next;
        }

        #region Private methods

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="kEnd"></param>
        /// <returns></returns>
        private int KthLastElement(ListNode node, int kEnd)
        {
            if (node == null)
                return 0;

            var count = 1 + KthLastElement(node.Next, kEnd);
            if (count == kEnd)
            {
                return 0;
            }

            return count;
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="kEnd"></param>
        /// <returns></returns>
        private string IterativeTwoPointerKthLastElement(ListNode node, int kEnd)
        {
            var currentNode = node;
            var kthCurrentNode = node;
            var count = 1;
            while (count != kEnd)
            {
                if (kthCurrentNode == null)
                    return string.Empty;

                kthCurrentNode = kthCurrentNode.Next;
                count++;
            }

            while (kthCurrentNode.Next != null)
            {
                kthCurrentNode = kthCurrentNode.Next;
                currentNode = currentNode.Next;
            }

            return currentNode.Data;
        }

        #endregion
    }

    public class ListNode
    {
        public ListNode Next { get; set; }
        public string Data { get; set; }
    }
}