using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.Ranjan
{
    /*
         Given the reference to the root of a binary tree and a value k, return the number of paths in the tree such that the sum of the nodes along the path equals k.
    Note: The path does not need to start at the root of the tree, but must move downward.

    Ex: Given the following binary tree and value k…

          3
         / \
        1   8
      K= 11;


          3
         / \
        1   8
            /
            3 
     
    
    {8, 11}
    {3, 11} ->{null,8}
    {3, 3}=> 0 
     */

    public class NodeStore
    {
        public Node Node;
        public int Index = -1;
        public int RS;


    public NodeStore(Node node, int rs, int index = -1)
        {
            Node = node;
            Index = index;
            RS = rs;
        }
    }

    public class TreePaths
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
            var tree = new TreePaths()
            {
                Root = new Node(3)
                {
                    Left = new Node(1)
                    {
                    },
                    Right = new Node(8)
                    {
                        Left = new Node(3)
                        {
                        },
                    }
                }
            };

            Console.WriteLine($"Number of paths for k = 11 -> {tree.CalculatePaths(11)}");
            Console.WriteLine($"CalculatePathsV2 -> Number of paths for k = 11 -> {tree.CalculatePathsV2(tree.Root, 11)}");

            var tree1 = new TreePaths()
            {
                Root = new Node(1)
                {
                    Right = new Node(2)
                    {
                        Right = new Node(3)
                        {
                            Right = new Node(4)
                            {
                                Right = new Node(5)
                                {
                                },
                            },
                        },
                    }
                }
            };

            Console.WriteLine($"Number of paths for k = 2 -> {tree1.CalculatePaths(3)}");

            Console.WriteLine();
            var tree2 = new TreePaths()
            {
                Root = new Node(50)
                {
                    Left = new Node(25)
                    {
                        Left = new Node(12)
                        , Right = new Node(30)
                    },
                    Right = new Node(75)
                    {
                        Left = new Node(60)
                        , Right = new Node(100)
                    }
                }
            };
            Console.WriteLine();
            Console.WriteLine("Level order");
            tree2.LevelOrder(tree2.Root);
            Console.WriteLine();
            Console.WriteLine("In order");
            tree2.InOrder(tree2.Root);
            tree2.DfsInOrderRecur(tree2.Root);
            Console.WriteLine();
            Console.WriteLine("Pre order");
            tree2.DfsPreOrder(tree2.Root);
            Console.WriteLine();
            Console.WriteLine("Pre order Recursive ");
            tree2.DfsPreOrderRecursive(tree2.Root);
            Console.WriteLine();
            Console.WriteLine("POST order");
            tree2.PostOrder(tree2.Root);

            var paths = new List<List<int>>();
            tree2.PrintPaths(tree2.Root, new List<int>(), paths);
            tree2.Print();
            Console.WriteLine();
            foreach (var item in paths)
            {
                Console.WriteLine(string.Join(" ->", item));
            }

            var prefixSums = new List<int>();
            tree2.PrefixSum(tree2.Root, prefixSums);
            Console.WriteLine();
            foreach (var item in prefixSums)
            {
                Console.Write($"{item}");
            }
        }

        public void PrintPaths(Node root, List<int> parents, List<List<int>> paths)
        {
            if (root != null)
            {
                parents.Add(root.Value);
                if (root.Left == null && root.Right == null)
                {
                    paths.Add(parents.ToArray().ToList());
                    parents.RemoveAt(parents.Count - 1);
                }
                else
                {
                    PrintPaths(root.Left, parents, paths);
                    PrintPaths(root.Right, parents, paths);
                }
            }
        }

        public void PrefixSum(Node root, List<int> sums)
        {
            if (root != null)
            {

            }
        }

        private void LevelOrder(Node root)
        {
            if (root != null)
            {
                var queue = new Queue<Node>();
                queue.Enqueue(root);
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
                    if (current != null)
                    {
                        Console.Write($" {current.Value} ");
                        children.Enqueue(current.Left);
                        children.Enqueue(current.Right);
                    }
                }
            }
        }

        private void InOrder(Node root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                Console.Write($" {root.Value} ");
                InOrder(root.Right);
            }
        }

        public void DfsInOrderRecur(Node root)
        {
            var result = new Queue<int>();
            DfsInOrderRecursive(root, result);
            Console.WriteLine("DfsInOrderRecursive");
            Console.WriteLine($"{string.Join("  ", result.ToArray())}");

        }

        public void DfsInOrderRecursive(Node root, Queue<int> result)
        {
            if (root != null)
            {
                DfsInOrderRecursive(root.Left, result);
                result.Enqueue(root.Value);
                DfsInOrderRecursive(root.Right, result);
            }
        }

        private void PostOrder(Node root)
        {
            if (root != null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                Console.Write($" {root.Value} ");
            }
        }

        public int CalculatePathsV2(Node root, int sum, int sumSoFar = 0, List<int> path = null, int count = 0)
        {
            if (path == null)
            {
                path = new List<int>();
            }
            if (root == null)
            {
                return count;
            }
            sumSoFar += root.Value;
            path.Add(root.Value);
            if (sumSoFar == sum)
            {
                count++;
            }

            count = CalculatePathsV2(root.Left, sum, sumSoFar, path, count);
            count = CalculatePathsV2(root.Right, sum, sumSoFar, path, count);
            path.RemoveAt(path.Count - 1);

            return count;
        }

        public int CalculatePaths(int k)
        {
            var set = new HashSet<int>();
            int count = 0;
            if (Root == null)
            {
                return count;
            }
            var queue = new Queue<NodeStore>();
            queue.Enqueue(new NodeStore(Root, k, 0));
            set.Add(0);
            while (queue.Count > 0)
            {
                var data = queue.Dequeue();
                var node = data.Node;
                int remK = data.RS - data.Node.Value;
                if (remK == 0)
                {
                    count++;
                }

                if (node.Left != null)
                {
                    if (remK != 0)
                    {
                        Console.WriteLine($"[{node.Left.Value} - {remK}]");
                        queue.Enqueue(new NodeStore(node.Left, remK));
                    }
                    var setKey = Left(data.Index);
                    if (!set.Contains(setKey))
                    {
                        Console.WriteLine($"[{node.Left.Value} - {k}]");
                        set.Add(setKey);
                        queue.Enqueue(new NodeStore(node.Left, k, setKey));
                    }
                }
                if (node.Right != null)
                {
                    if (remK != 0)
                    {
                        Console.WriteLine($"[{node.Right.Value} - {remK}]");
                        queue.Enqueue(new NodeStore(node.Right, remK));
                    }

                    var setKey = Right(data.Index);
                    if (!set.Contains(setKey))
                    {
                        Console.WriteLine($"[{node.Right.Value} - {k}]");
                        set.Add(setKey);
                        queue.Enqueue(new NodeStore(node.Right, k, setKey));
                    }
                }
            }

            return count;
        }

        public int Left(int p)
        {
            return 2 * p + 1;
        }
        public int Right(int p)
        {
            return 2 * p + 2;
        }

        public void DfsPreOrder(Node root)
        {
            if (root != null)
            {
                Console.Write($" {root.Value} ");
                DfsPreOrder(root.Left);
                DfsPreOrder(root.Right);
            }

        }

        public void DfsPreOrderRecursive(Node root)
        {
            var result = new List<int>();
            DfsPreOrderRecursive(root, result);
            Console.WriteLine("DfsPreOrderRecursive");
            Console.WriteLine($"{string.Join("  ", result.ToArray())}");
        }

        public void DfsPreOrderRecursive(Node root, List<int> result)
        { 
            if (root != null)
            {
                result.Add(root.Value);
                DfsPreOrderRecursive(root.Left, result);
                DfsPreOrderRecursive(root.Right, result);
            }
        }
    }
}