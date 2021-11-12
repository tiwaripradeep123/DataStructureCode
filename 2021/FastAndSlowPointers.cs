using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp._2021
{
    public static class FastAndSlowPointers
    {
        class ListNode
        {
            int value = 0;
            public ListNode next { get; set; }

            public ListNode(int value)
            {
                this.value = value;
            }
        }

        public static void Tests()
        {
            SinglyLinkedListCycle();
        }

        private static void SinglyLinkedListCycle()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(6);
        }
    }
}
