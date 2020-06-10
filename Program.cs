using ConsoleApp;
using System;
using System.Linq.Expressions;

namespace ConsoleAppPractice
{
    class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("This is DB practice session..");
            Console.WriteLine("Press 1 for Binary search tree");
            Console.WriteLine("Press 2 for two sum problem");
            Console.WriteLine("Press 3 for Maximum Area Cake problem");
            Console.WriteLine("Press 4 for Find Inflection point.");
            Console.WriteLine("Press 5 for Max heap.");
            Console.WriteLine("Press 6 for Longest substring.");
            Console.WriteLine("Press 7 for Reverse linked list.");

            Console.WriteLine("Press x to exit");
            bool isContinue = true;
            do
            {
                var selection = Console.ReadLine().Trim();
                isContinue = selection.ToLowerInvariant() != "x";
                if (isContinue)
                {
                    if (!int.TryParse(selection, out int option))
                    {
                        Console.WriteLine("Please try again ..");
                    }

                    switch (option)
                    {
                        case 1:
                            BinarySearchOperations();
                        break;
                        case 2:
                            RandomProblems.TwoSumProblem();
                            break;
                        case 3:
                            MaximumAreaCake.MaximumAreaCakeCaller();
                            break;
                        case 4:
                            CodeFindInflectionPoint.FindInflectionPoint();
                            break;
                        case 5:
                            MaxHeap.Test();
                            break;

                        case 6:
                            LongestSubstring.Test();
                            break;
                        case 7:
                            ReverseListSolution.Test();
                            break;
                    }
                }
            } while (isContinue);

            Console.WriteLine("Exited app..");
            Console.ReadLine();
            //StackOperations();
        }

        private static void BinarySearchOperations()
        {
            var binaryTree = BinaryTreeBuilder.BinaryTree(new int[] { 50, 40, 60, 30, 45, 55, 70, 20, 35 });
            BinaryTreeBuilder.PrintBinaryTree(binaryTree);
            BinarySearchTree binarySearchTree = new BinarySearchTree();
            var status = binarySearchTree.FindValue(binaryTree, 45) ? "Found" : "Not Found";
            Console.WriteLine($"Value [45] {status}");

            status = binarySearchTree.FindValue(binaryTree, 10) ? "Found" : "Not Found";
            Console.WriteLine($"Value [10] {status}");

            status = binarySearchTree.FindValue(binaryTree, 70) ? "Found" : "Not Found";
            Console.WriteLine($"Value [70] {status}");
        }

        private static void StackOperations()
        {
            string[] args = new String[]
            {"10",
            "1 97",
            "2",
            "1 21",
            "2",
            "1 26",
            "1 20",
            "2",
            "3",
            "1 91",
            "3" };

            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            Stack stack = new Stack();

            int.TryParse(args[0], out int count);
            if (count > 0)
            {
                for (int i = 1; i <= count; i++)
                {
                    var data = args[i].Trim().Split(new char[] { ' ' });
                    int option = int.Parse(data[0]);
                    switch (option)
                    {
                        case 1:
                            stack.Push(int.Parse(data[1]));
                            break;
                        case 2:
                            stack.Pop();
                            break;
                        case 3:
                            Console.WriteLine(stack.GetMax());
                            break;
                    }
                }
            }
        }
    }

}
