using System.Collections.Generic;

namespace CrackingTheCodeInterview.LinkedLists
{
    public class LinkedLists
    {
        private ListNode HeadListNode { get; set; }
        private ListNode _leftNode;

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
            AddReverseOrder(firstHeadNode, secondHeadNode, firstHeadNode, ref node);

            return node;
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="headListNode"></param>
        /// <returns></returns>
        public ListNode ReverseLinkedList(ListNode headListNode)
        {
            var currentNode = headListNode;
            ListNode previousNode = null;

            while (currentNode != null)
            {
                var tempNode = currentNode.Next;
                currentNode.Next = previousNode;

                previousNode = currentNode;
                currentNode = tempNode;
            }

            return previousNode;
        }

        public ListNode FindMiddleNode(ListNode headListNode)
        {
            var slowNode = headListNode;
            var fastNode = headListNode;
            var times = 0;

            while (fastNode.Next != null)
            {
                times++;
                if (times % 2 == 0)
                {
                    times = 0;
                    slowNode = slowNode.Next;
                }
                fastNode = fastNode.Next;
            }

            return slowNode;
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="headListNode"></param>
        /// <returns></returns>8
        public bool IsPalindrome(ListNode headListNode)
        {
            HeadListNode = headListNode;

            //return IsPalindromeUtilRecursive(headListNode);

            var currentNode = headListNode;
            var middleNode = FindMiddleNode(headListNode);
            var reverseMiddleHeadNode = ReverseLinkedList(middleNode.Next);

            while (currentNode != null && reverseMiddleHeadNode != null)
            {
                if (!reverseMiddleHeadNode.Data.Equals(currentNode.Data))
                    return false;

                reverseMiddleHeadNode = reverseMiddleHeadNode.Next;
                currentNode = currentNode.Next;
            }

            return true;
        }

        /// <summary>
        /// Time complexity O(n)
        /// </summary>
        /// <param name="headF"></param>
        /// <param name="headS"></param>
        /// <returns></returns>
        public ListNode IntersectionTwoLists(ListNode headF, ListNode headS)
        {
            var headFCount = 0;
            var headSCount = 0;
            var currentF = headF;
            var currentS = headS;
            while (currentF != null)
            {
                headFCount++;
                currentF = currentF.Next;
            }
            while (currentS != null)
            {
                headSCount++;
                currentS = currentS.Next;
            }

            var diff = headFCount - headSCount;
            currentF = headF;
            currentS = headS;

            var count = 0;
            if (diff > 0)
            {
                while (count < diff)
                {
                    count++;
                    currentF = currentF.Next;
                }
            }

            count = 0;
            if (diff < 0)
            {
                while (count < -diff)
                {
                    count++;
                    currentS = currentS.Next;
                }
            }

            while (currentF != null && currentS != null)
            {
                if (currentF == currentS)
                    return currentF;
                currentF = currentF.Next;
                currentS = currentS.Next;
            }

            return null;
        }

        public ListNode CyclePointAt(ListNode headListNode)
        {
            var currentNodeSlow = headListNode;
            var currentNodeFast = headListNode;
            var count = 0;

            while (currentNodeSlow != null && currentNodeFast != null)
            {
                currentNodeFast = currentNodeFast.Next;
                count++;
                if (count >= 2)
                {
                    count = 0;
                    currentNodeSlow = currentNodeSlow.Next;
                    if (currentNodeFast == currentNodeSlow)
                        return currentNodeFast;
                }
            }

            return null;
        }

        public ListNode CycleStartingNode(ListNode head)
        {
            var cyclePointMet = CyclePointAt(head);
            if (cyclePointMet != null)
            {
                var currentNode = head;

                while (cyclePointMet != currentNode)
                {
                    cyclePointMet = cyclePointMet.Next;
                    currentNode = currentNode.Next;
                }
            }

            return cyclePointMet;
        }

        #region Private methods

        private bool IsPalindromeUtilRecursive(ListNode rightNode)
        {
            _leftNode = HeadListNode;
            if (rightNode == null)
                return true;

            var palindrome = IsPalindromeUtilRecursive(rightNode.Next);
            if (!palindrome)
                return false;

            palindrome = rightNode.Data.Equals(_leftNode.Data);
            _leftNode = _leftNode.Next;

            return palindrome;
        }

        private int AddReverseOrder(ListNode fNode, ListNode sNode, ListNode fNodeHead, ref ListNode resultNode)
        {
            var carry = 0;
            if (fNode != null || sNode != null)
            {
                resultNode.Next = new ListNode();
                var nxt = resultNode.Next;
                carry = AddReverseOrder(fNode?.Next, sNode?.Next, fNodeHead, ref nxt);
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
                var node = new ListNode()
                {
                    Data = carry.ToString(),
                    Next = resultNode
                };
                resultNode = node;
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