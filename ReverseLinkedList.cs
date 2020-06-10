using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{

    /// <summary>
    /// reference from Leetcode
    /// https://leetcode.com/problems/reverse-linked-list/submissions/
    /// </summary>
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

    public static  class ReverseListSolution
    {

        public static void Test()
        {
            ListNode head = CreateLinkedList();
            var iterator = head;
            PrintLinkedList(iterator);
            iterator = head;
            Console.WriteLine("Reversed -> ");
            PrintLinkedList(ReverseList(iterator));

            Console.WriteLine("Reversed recursion -> ");
            PrintLinkedList(ReverseLinkedList(iterator));
        }

        private static ListNode CreateLinkedList()
        {
            var head = new ListNode(1);
            var iterator = head;
            for (int i = 2; i < 5; i++)
            {
                iterator.next = new ListNode(i);
                iterator = iterator.next;
            }

            return head;
        }

        private static void PrintLinkedList(ListNode iterator)
        {
            while (iterator != null)
            {
                Console.Write($" {iterator.val} ");
                iterator = iterator.next;
            }
        }

        public static ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var newHead = new ListNode(head.val);
            while (head.next != null)
            {
                newHead = new ListNode(head.next.val, newHead);
                head = head.next;
            }
            return newHead;
        }

        public static ListNode ReverseLinkedList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var newhead = ReverseLinkedList(head.next);
            var iterator = newhead;
            while (iterator.next != null)
            {
                iterator = iterator.next;
            }
            iterator.next = new ListNode(head.val);
            return newhead;
        }
    }
}
