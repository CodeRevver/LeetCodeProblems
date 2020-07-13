using FluentAssertions;
using Xunit;

namespace LeetCodeProblems
{
    public class ListNode
    {
        public int val;

        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class AddTwoNumbersProblem
    {
        /// https://leetcode.com/problems/add-two-numbers/
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
            {
                return null;
            }

            ListNode answerNode = null;
            var sumOfNodes = (l1?.val ?? 0) + (l2?.val ?? 0);
            if (sumOfNodes >= 10)
            {
                // Carry the 1 from the 10 on the next node
                var nextFirstNode = l1?.next;
                var carry = 1;

                if (nextFirstNode != null)
                {
                    nextFirstNode.val = nextFirstNode.val + carry;
                }
                else
                {
                    nextFirstNode = new ListNode(carry);
                }

                answerNode = new ListNode(sumOfNodes - 10, AddTwoNumbers(nextFirstNode, l2?.next));
            }
            else
            {
                answerNode = new ListNode(sumOfNodes, AddTwoNumbers(l1?.next, l2?.next));
            }

            return answerNode;
        }

        [Fact]
        public void Test1()
        {
            var node1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            var node2 = new ListNode(5, new ListNode(6, new ListNode(4)));

            var answer = AddTwoNumbers(node1, node2);

            var expectedAnswer = new ListNode(7, new ListNode(0, new ListNode(8)));
            answer.Should().BeEquivalentTo(expectedAnswer);
        }
    }
}
