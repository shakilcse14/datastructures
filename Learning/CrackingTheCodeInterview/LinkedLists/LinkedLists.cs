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

        public ListNode Partition(ListNode headListNode, int value)
        {
            ListNode lessNodePoint = null;
            ListNode greaterNodePoint = null;
            ListNode headLessNodePoint = null;
            ListNode headGreaterNodePoint = null;
            var currentNode = headListNode;

            while (currentNode != null)
            {
                if (int.Parse(currentNode.Data) < value)
                {
                    if (lessNodePoint == null)
                    {
                        lessNodePoint = currentNode;
                        headLessNodePoint = lessNodePoint;
                    }
                    else
                    {
                        lessNodePoint.Next = currentNode;
                        lessNodePoint = currentNode;
                    }
                }
                else
                {
                    if (greaterNodePoint == null)
                    {
                        greaterNodePoint = currentNode;
                        headGreaterNodePoint = currentNode;
                    }
                    else
                    {
                        greaterNodePoint.Next = currentNode;
                        greaterNodePoint = currentNode;
                    }
                }

                currentNode = currentNode.Next;
            }

            if (lessNodePoint != null && headGreaterNodePoint != null)
            {
                lessNodePoint.Next = headGreaterNodePoint;
                greaterNodePoint.Next = null;
                headListNode = headLessNodePoint;
            }

            return headListNode;
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="firstHeadNode"></param>
        /// <param name="secondHeadNode"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbersReverseOrder(ListNode firstHeadNode, ListNode secondHeadNode)
        {
            var carry = 0;
            var currentNode = new ListNode();
            var headCurrentNode = currentNode;

            while (firstHeadNode != null || secondHeadNode != null)
            {
                var firstValue = firstHeadNode == null ? 0 : int.Parse(firstHeadNode.Data);

                var secondValue = secondHeadNode == null ? 0 : int.Parse(secondHeadNode.Data);

                var result = firstValue + secondValue + carry;
                if (result > 9)
                {
                    carry = result / 10;
                    result %= 10;
                }
                else
                    carry = 0;

                currentNode.Next = new ListNode()
                {
                    Data = result.ToString(),
                    Next = null
                };
                currentNode = currentNode.Next;
                firstHeadNode = firstHeadNode?.Next;
                secondHeadNode = secondHeadNode?.Next;
            }

            if (carry != 0)
            {
                currentNode.Next = new ListNode()
                {
                    Data = carry.ToString(),
                    Next = null
                };
            }

            headCurrentNode = headCurrentNode.Next;
            return headCurrentNode;
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="firstHeadNode"></param>
        /// <param name="secondHeadNode"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbersNonReverseOrder(ListNode firstHeadNode, ListNode secondHeadNode)
        {
            var node = new ListNode();
            AddReverseOrder(firstHeadNode, secondHeadNode, firstHeadNode, node);

            return node;
        }

        #region Private methods

        private int AddReverseOrder(ListNode fNode, ListNode sNode, ListNode fNodeHead, ListNode resultNode)
        {
            var carry = 0;
            if (fNode != null || sNode != null)
            {
                resultNode.Next = new ListNode();
                carry = AddReverseOrder(fNode?.Next, sNode?.Next, fNodeHead, resultNode.Next);
            }

            var fValue = fNode == null ? 0 : int.Parse(fNode.Data);
            var sValue = sNode == null ? 0 : int.Parse(sNode.Data);
            var result = fValue + sValue + carry;
            if (result > 9)
            {
                carry = result / 10;
                result %= 10;
            }
            else
                carry = 0;

            if (fNode != null || sNode != null)
                resultNode.Data = result.ToString();
            if (fNode == fNodeHead && carry > 0)
            {
                resultNode.Next = new ListNode()
                {
                    Data = carry.ToString(),
                    Next = null
                };
            }

            return carry;
        }

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