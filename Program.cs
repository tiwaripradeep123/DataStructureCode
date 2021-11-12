using ConsoleApp;
using ConsoleApp._2021;
using ConsoleApp.Educative;
using ConsoleApp.Graph;
using ConsoleApp.InterviewQuestions;
using ConsoleApp.LeetCode;
using ConsoleApp.Pramp;
using ConsoleApp.Ranjan;
using ConsoleApp.WayFairPrep;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace ConsoleAppPractice
{
    class Program
    {

        public static void Main(String[] args)
        {
            

            Console.WriteLine("Press x to exit");
            bool isContinue = true;
            do
            {
                var selection = "12";// Console.ReadLine().Trim();
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
                            ExistingCases();
                            break;

                        case 2:
                            LeetCodeCases();
                            break;
                        case 3:
                            LongestPalindromicSubstringInAString.Tests();
                            break;
                        case 4:
                            PrampCases();
                            break;
                        case 5:
                            CasesFor2021();
                            break;
                        case 6:
                            EducativeProblems();
                            break;
                        case 7:
                            DataStructuresPractice.Tests();
                            break;
                        case 8:
                            FindNoOfIslands.Tests();
                            break;
                        case 9:
                            CoinChangeProblem2021.Tests();
                            break;
                        case 10:
                            CalculateFCDistances.Tests();
                            break;
                        case 11:
                            GraphAssignWeights.Tests();
                            break;
                        case 12:
                            GraphAlgo.Tests();
                            break;
                        case 13:
                            (new GraphClass()).Tests();
                            break;
                        case 14:
                            TestLRUCache.Tests();
                            break;
                        case 15:
                            LongestPalendromicProduct.Tests();
                            break;
                        case 16:
                            PriorityQueueTests.Tests();
                            break;
                        case 17:
                            DoublyLinkedList.Tests();
                            break;
                        case 18:
                            RanjanProgram.MainMethod();
                            break;
                        case 19:
                            GraphWithAdjecencyListTest.Tests();
                            break;
                        case 20:
                            KPrimeNumbersSum.Tests();
                            break;
                        case 21:
                            SimilarSentence.Tests();
                            break;
                        case 22:
                            CheapestFlightWithKStops.Tests();
                            break;
                        case 23:
                            FindContiguousUrl.Tests();
                            break;
                        case 24:
                            SomeGreatTests();
                            break;

                    }
                }
            } while (isContinue);

            Console.WriteLine("Exited app..");
            Console.ReadLine();
            //StackOperations();
        }

        private static void SomeGreatTests()
        {
            var input = new int[] { 1, -1, 2, 2, -6, 3 };
            var result = FindMaxContagiousSum(input);
            Console.WriteLine($"{result}");

            input = new int[] { -10, -20, -30 };
            result = FindMaxContagiousSum(input);
            Console.WriteLine($"{result} =>" + string.Join(",", input));

            input = new int[] { 10, 20, 30 };
            result = FindMaxContagiousSum(input);
            Console.WriteLine($"{result} =>" + string.Join(",", input));

            input = new int[] { -10 };
            result = FindMaxContagiousSum(input);
            Console.WriteLine($"{result} =>" + string.Join(",", input));
        }



        /*
         
         */

        private static void EducativeProblems()
        {
            int option = 8;
            switch (option)
            {
                case 1:
                    (new GraphClass()).Tests();
                    break;
                case 2:
                    KnapsackProblems.Tests();
                    break;
                case 3:
                    FindCommonAvailability.Tests();
                    break;
                case 4:
                    InterviewTestCode();
                    break;
                case 5:
                    GridIlluminationClass.Tests();
                    break;
                case 6:
                    EducativeBFS.Tests();
                    break;
                case 7:
                    EducativeBFS.Tests();
                    break;
                case 8:
                    MinHeapGeneric.Tests();
                    break;
                default:
                    break;

                    
            }
        }

        private static void InterviewTestCode()
        {
            var inputs = new List<int> { 19, 2, 12 };

            foreach (var input in inputs)
            {
                Console.WriteLine($"{input} -> {HappyNumber.IsHappyNumber(input)}");
                Console.WriteLine($"Recursion -> {input} -> {HappyNumber.IsHappyNumberRecursion(input)}");
            }
        }

        private static void CasesFor2021()
        {
            int option = 1;
            switch (option)
            {
                case 1:
                    (new GraphClass()).Tests();
                    break;
                default:
                    break;
            }
        }

        private static void PrampCases()
        {
            int option = 2;
            switch (option)
            {
                case 1:
                    DiffBetweenTwoStrings.Tests();
                    break;
                case 2:
                    CoinChangeProblem.Tests();
                        break;
                case 3:
                    MaxHeapClass.Tests();
                    break;
                default:
                    break;
            }
            
        }

        private static void LeetCodeCases()
        {
            int option = 4;
            switch (option)
            {
                case 1:
                    LongestPalindromeString.Tests();
                    break;
                case 2:
                    SudokuSolver.Tests();
                    break;
                case 3:
                    Test3DArray();
                        break;

                case 4:
                    ValidParentheses.Tests();
                    break;
                default:
                    break;
            }
        }

        private static void Test3DArray()
        {
            var a = new int[2, 2, 4];

            a[0, 0, 0] = 1;
            a[0, 0, 1] = 2;
            a[0, 0, 2] = 3;
            a[0, 0, 3] = 4;
            a[0, 1, 0] = 1;
            a[0, 1, 1] = 2;
            a[0, 1, 2] = 3;
            a[0, 1, 3] = 4;

            a[1, 0, 0] = 1;
            a[1, 0, 1] = 2;
            a[1, 0, 2] = 3;
            a[1, 0, 3] = 4;
            a[1, 1, 0] = 1;
            a[1, 1, 1] = 2;
            a[1, 1, 2] = 3;
            a[1, 1, 3] = 4;


            Console.WriteLine("Hello World");

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($" [");
                    for (int z = 0; z < a.GetLength(2); z++)
                    {
                        Console.Write($" {string.Join(",", a[i, j,z])} ");
                    }
                    Console.Write($" ] ");
                }
                Console.WriteLine();
            }
        }
    

        private static void ExistingCases()
        {
            Console.WriteLine("This is DB practice session..");
            Console.WriteLine("Press 1 for Binary search tree");
            Console.WriteLine("Press 2 for two sum problem");
            Console.WriteLine("Press 3 for Maximum Area Cake problem");
            Console.WriteLine("Press 4 for Find Inflection point.");
            Console.WriteLine("Press 5 for Max heap.");
            Console.WriteLine("Press 6 for Longest substring.");
            Console.WriteLine("Press 7 for Reverse linked list.");
            Console.WriteLine("Press 8 for Reverse linked list.");

            int option = 5;
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
                case 8:
                    SlidingWindows.Test();
                    break;
                case 9:
                    SlowAndFastPointers.Tests();
                    break;
                case 10:
                    CyclicSort.Tests();
                    break;
                case 11:
                    FastAndSlowPointers.Tests();
                    break;
                case 12:
                    MergeIntervals.Tests();
                    break;
                default:
                    break;
            }

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

        /*
         array of ints 
         max possible sum of contigious integers 

         
         

         */
        /*
         [1, -1, 2, 2, -6, 3]
         [-10, -20, -30, 1, ]
         */
        public static int FindMaxContagiousSum(int[] input)
        {
            if (input == null && input.Length == 0)
            {
                throw new ArgumentNullException("Input is null or Empty");
            }
            else if (input.Length == 1)
            {
                return input[0];
            }
            int max = int.MinValue;
            int localMax = input[0];
            for (int index = 1; index < input.Length; index++)
            {
                var current = localMax + input[index];
                if (localMax > current)
                {
                    max = max > localMax ? max : localMax;
                }

                localMax = current > input[index] ? current : input[index];
            }

            return max > localMax ? max : localMax;
        }

        /*
         null, 1 element, many element => all increasing , all decresing, random
         */
    }

}
