using QueueNS = ConsoleApp.Queue;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class BinaryTreeBuilder
    {
        public static BinaryTree BinaryTree(int[] data)
        {
            if (data == null || data.Length == 0)
            {
                return null;
            }

            BinaryTree root = new BinaryTree() { Data = data[0] };

            for (int i = 1; i < data.Length; i++)
            {
                InsertNode(root, data[i]);
            }

            return root;
        }

        private static void InsertNode(BinaryTree root, int data)
        {
            if (root.Data > data)
            {
                if (root.LeftSubTree == null)
                {
                    root.LeftSubTree = new BinaryTree { Data = data };
                }
                else
                {
                    InsertNode(root.LeftSubTree, data);
                }
            }
            else
            {
                if (root.RightSubTree == null)
                {
                    root.RightSubTree = new BinaryTree { Data = data };
                }
                else
                {
                    InsertNode(root.RightSubTree, data);
                }
            }
        }

        public static void PrintBinaryTree(BinaryTree binaryTree, int level = 0)
        {
            if (binaryTree == null)
            {
                return;
            }

            QueueNS.Queue<KeyValuePair<BinaryTree, int>> binaryTreeQueue = new QueueNS.Queue<KeyValuePair<BinaryTree, int>>();
            binaryTreeQueue.Push(new KeyValuePair<BinaryTree, int>(binaryTree, level));

            PrintBinaryTreeRecursive(binaryTreeQueue);

        }

        public static void PrintBinaryTreeRecursive(QueueNS.Queue<KeyValuePair<BinaryTree, int>> binaryTreeQueue)
        {
            if (binaryTreeQueue.Peek().Key != null)
            {
                bool printNext = false;
                do
                {
                    printNext = false;
                    var binaryTreeWithLevel = binaryTreeQueue.Pop();
                    if (binaryTreeWithLevel.Key != null)
                    {
                        Console.Write($" [{binaryTreeWithLevel.Key.Data}] ");
                        if (binaryTreeWithLevel.Key.LeftSubTree != null)
                        {
                            binaryTreeQueue.Push(new KeyValuePair<BinaryTree, int>(binaryTreeWithLevel.Key.LeftSubTree, binaryTreeWithLevel.Value + 1));
                        }
                        if (binaryTreeWithLevel.Key.RightSubTree != null)
                        {
                            binaryTreeQueue.Push(new KeyValuePair<BinaryTree, int>(binaryTreeWithLevel.Key.RightSubTree, binaryTreeWithLevel.Value + 1));
                        }
                        printNext = binaryTreeQueue.Peek().Key != null && binaryTreeWithLevel.Value == binaryTreeQueue.Peek().Value;
                    }
                } while (printNext);

                Console.WriteLine();
                PrintBinaryTreeRecursive(binaryTreeQueue);
            }
        }
    }
}
