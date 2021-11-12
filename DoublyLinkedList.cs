using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class Node
    {
        public int Data { get; set; }

        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(int data)
        {
            Data = data;
        }
    }

    public class DoublyLinkedList
    {
        public static void Tests()
        {
            var doublyLinkedList = new DoublyLinkedList();
            for (int i = 0; i < 10; i++)
            {
                doublyLinkedList.Add(new Node(i*i));
                doublyLinkedList.PrintForward();
                doublyLinkedList.PrintBackward();
                if (i % 3 == 0)
                {
                    doublyLinkedList.BrintToTop(new Node((i-1) * (i-1)));
                    doublyLinkedList.PrintForward();
                    doublyLinkedList.PrintBackward();

                }
            }
        }

        public void PrintForward()
        {
            Console.WriteLine();
            var itr = Head;
            while (itr != null)
            {
                Console.Write($"{itr.Data} -> ");
                itr = itr.Next;
            }
            Console.WriteLine();
        }

        public void PrintBackward()
        {
            Console.WriteLine();
            var itr = Tail;
            while (itr != null)
            {
                Console.Write($"{itr.Data} <- ");
                itr = itr.Previous;
            }
            Console.WriteLine();
        }

        public Node Head { get; set; }
        public Node Tail { get; set; }

        public Node AddHead(Node head)
        {
            if (head != null)
            {
                if (Head != null)
                {
                    head.Next = Head;
                    Head.Previous = head;
                    Head = Head.Previous;
                }
                else
                {
                    Head = head;
                    Tail = head;
                }
            }

            return head;
        }

        public void Add(Node node)
        {
            if (node != null)
            {
                if (Head == null)
                {
                    Head = node;
                    Tail = node;
                }
                else
                {
                    Tail.Next = node;
                    node.Previous = Tail;
                    Tail = Tail.Next;
                }
            }
        }

        public void BrintToTop(Node node)
        {
            if (node != null)
            {
                if (Head == null)
                {
                    Head = node;
                    Tail = node;
                }
                else if (Head.Data == node.Data)
                {
                    return;
                }
                else
                {
                    var runner = Head;
                    while (runner.Next != null && runner.Next.Data != node.Data)
                    {
                        runner = runner.Next;
                    }

                    if (runner != null)
                    {
                        runner.Next = runner.Next.Next;
                        if (runner.Next != null)
                        {
                            runner.Next.Previous = runner;
                        }
                    }

                    AddHead(node);
                }
            }
        }
    }
}
