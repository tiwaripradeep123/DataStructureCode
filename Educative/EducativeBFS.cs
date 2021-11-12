using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Educative
{
    public class Node
    {
        public int Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

    }

    public class NodeWithNext
    {
        public int Value { get; set; }

        public NodeWithNext Left { get; set; }

        public NodeWithNext Right { get; set; }
        public NodeWithNext Next { get; set; }

    }

    public static class EducativeBFS
    {
        public static void Tests()
        {
            var root = ContructTree();
            var values = GetLevelOrder(root);
            Print(values);

            var reverse = GetReverseLevelOrder(root);
            Print(reverse);

            var nextNodes = ConnectLevelOrderSiblings(ContructTreeWithNext());
            Print(nextNodes);

            var nextNodesV2 = ConnectLevelOrderSiblingsV2(ContructTreeWithNext());
            Print(nextNodesV2);
        }


        public static void Print(int[] values)
        { 
            Console.WriteLine($"[{string.Join(",", values)}]");
        }

        public static void Print(NodeWithNext root)
        {
            var queue = new Queue<NodeWithNext>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var next = current.Next != null ? current.Next.Value.ToString() : "";
                Console.WriteLine($"[{current.Value} -> {next}]");
                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }
        }

        private static NodeWithNext ConnectLevelOrderSiblingsV2(NodeWithNext root)
        {
            var nodes = new Queue<NodeWithNext>();
            nodes.Enqueue(root);
            NodeWithNext previous = null;
            while (nodes.Count > 0)
            {
                var current = nodes.Dequeue();
                if (previous == null)
                {
                    previous = current;
                }
                else {
                    previous.Next = current;
                    previous = current;
                }

                if (current.Left != null)
                {
                    nodes.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    nodes.Enqueue(current.Right);
                }

            }

            return root;
        }

        private static NodeWithNext ConnectLevelOrderSiblings(NodeWithNext root)
        {
            var nodes = new Queue<NodeWithNext>();
            var temp = new Queue<NodeWithNext>();
            nodes.Enqueue(root);
            while (nodes.Count > 0 || temp.Count > 0)
            {
                if (nodes.Count == 0)
                {
                    nodes = temp;
                    temp = new Queue<NodeWithNext>();
                }
                else
                {
                    var current = nodes.Dequeue();
                    if (nodes.Count > 0)
                    {
                        current.Next = nodes.Peek();
                    }
                   
                    if (current.Left != null)
                    {
                        temp.Enqueue(current.Left);
                    }
                    if (current.Right != null)
                    {
                        temp.Enqueue(current.Right);
                    }
                }
            }

            return root;
        }

        private static int[] GetReverseLevelOrder(Node root)
        {
            var values = new int[7];
            int index = values.Length -1;

            var nodes = new Queue<Node>();
            var temps = new Queue<Node>();
            var tempValues = new int[7];
            int tempIndex = 0;
            nodes.Enqueue(root);
            while (nodes.Count > 0 || temps.Count > 0 )
            {
                if (nodes.Count == 0)
                {
                    while (tempIndex > 0)
                    {
                        values[index--] = tempValues[--tempIndex];
                    }
                    if (temps.Count == 0)
                    {
                        break;
                    }
                    else {
                        nodes = temps;
                        temps = new Queue<Node>();
                    }
                }
                var current = nodes.Dequeue();
                tempValues[tempIndex++] = current.Value;
                if (current.Left != null)
                {
                    temps.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    temps.Enqueue(current.Right);
                }
            }

            while (tempIndex > 0)
            {
                values[index--] = tempValues[--tempIndex];
            }

            return values;
        }

        private static int[] GetLevelOrder(Node root)
        {
            var values = new int[7];
            int index = 0;

            var nodes = new Queue<Node>();
            nodes.Enqueue(root);
            while (nodes.Count > 0)
            {
                var current = nodes.Dequeue();
                values[index++] = current.Value;
                if (current.Left != null)
                {
                    nodes.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    nodes.Enqueue(current.Right);
                }
            }

            return values;
        }

        private static Node ContructTree()
        {
            return new Node
            {
                Value = 50,
                Left = new Node
                {
                    Value = 25,
                    Left = new Node
                    {
                        Value = 10
                    },
                    Right = new Node
                    {
                        Value = 30
                    }
                },

                Right = new Node
                {
                    Value = 75,
                    Left = new Node
                    {
                        Value = 60
                    },
                    Right = new Node
                    {
                        Value = 100
                    }
                },
            };
        }

        private static NodeWithNext ContructTreeWithNext()
        {
            return new NodeWithNext
            {
                Value = 50,
                Left = new NodeWithNext
                {
                    Value = 25,
                    Left = new NodeWithNext
                    {
                        Value = 10
                    },
                    Right = new NodeWithNext
                    {
                        Value = 30
                    }
                },

                Right = new NodeWithNext
                {
                    Value = 75,
                    Left = new NodeWithNext
                    {
                        Value = 60
                    },
                    Right = new NodeWithNext
                    {
                        Value = 100
                    }
                },
            };
        }
    }
}
