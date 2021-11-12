using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Ranjan
{
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int data) : this(data, null, null)
        { 
        
        }

        public Node(int data, Node left, Node right)
        {
            this.Value = data;
            this.Left = left;
            this.Right = right;
        }
    }
    public class TreeRemove
    {
        public Node Root { get; set; }

        public void Print()
        {
            Console.WriteLine();
            var queue = new Queue<Node>();
            if (Root != null)
            {
                queue.Enqueue(Root);
            }
            var children = new Queue<Node>();
            while (queue.Count > 0 || children.Count > 0)
            {
                if (queue.Count == 0)
                {
                    queue = children;
                    children = new Queue<Node>();
                    Console.WriteLine();
                }

                var current = queue.Dequeue();
                Console.Write($" {current.Value} ");
                if (current.Left != null)
                {
                    children.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    children.Enqueue(current.Right);
                }
            }
            Console.WriteLine();
        }
        public static void Tests()
        {
            var tree = new TreeRemove();
            tree.Root = new Node(1)
            {
                Left = new Node(1)
                {
                    Left = new Node(0)
                    {
                        Left = new Node(1),
                        Right = new Node(0)
                    }
                },
                Right = new Node(0)
                {
                    Left = new Node(1),
                }
            };

            tree.Print();
            tree.PerformTrim();
            tree.Print();


            var returnBottomLeft = new TreeRemove();
            returnBottomLeft.Root = new Node(1)
            {
                Left = new Node(2)
                {
                    Left = new Node(4)
                    {
                        
                    }
                },
                Right = new Node(3)
                {
                }
            };

            var returnBottomLeft1 = new TreeRemove();
            returnBottomLeft1.Root = new Node(8)
            {
                Left = new Node(1)
                ,
                Right = new Node(4)
                {
                    Left = new Node(2)
                    {

                    }
                }
            };

            Console.WriteLine(returnBottomLeft1.ReturnBottomLeft());
            Console.WriteLine(returnBottomLeft.ReturnBottomLeft());

        }

        public int ReturnBottomLeft()
        {
            var data = ReturnBottomLeftRecursive(Root, 0, true);
            return data.Value;
        }

        public KeyValuePair<int, int> ReturnBottomLeftRecursive(Node root, int level=0, bool isLeft = false)
        {
            var left = new KeyValuePair<int, int>(-1, -1);
            var right = new KeyValuePair<int, int>(-1, -1);
            if (root.Left != null)
            {
                left = ReturnBottomLeftRecursive(root.Left, level + 1, true);
            }
            else
            {
                if (isLeft)
                {
                    left = new KeyValuePair<int, int>(level, root.Value);
                }
                else
                {
                    left = new KeyValuePair<int, int>(-1, -1);
                }
            }

            if (root.Right != null)
            { 
                right = ReturnBottomLeftRecursive(root.Right, level + 1, false);
            }

            return right.Key == -1 || left.Key > right.Key ? left : right;
            
        }

        public void PerformTrim()
        {
            var queue = new Queue<Node>();
            if (Root != null)
            {
                if (Root.Value == 0)
                {
                    Root = null;
                }
                else
                {
                    queue.Enqueue(Root);
                    while (queue.Count > 0)
                    {
                        var current = queue.Dequeue();
                        if (current.Left != null)
                        {
                            if (current.Left.Value == 0)
                            {
                                current.Left = null;
                            }
                            else
                            {
                                queue.Enqueue(current.Left);
                            }
                        }
                        if (current.Right != null)
                        {
                            if (current.Right.Value == 0)
                            {
                                current.Right = null;
                            }
                            else
                            {
                                queue.Enqueue(current.Right);
                            }
                        }
                    }
                }
            }
        }
    }
}
