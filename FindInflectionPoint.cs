using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    /// <summary>
    /// 
    /// </summary>
    public static class CodeFindInflectionPoint
    {
        public static void FindInflectionPoint()
        {
            Test1();
            Test2();
            Test3();
            Test4();
        }

        private static void Test1()
        {
            var data = new[] { 1, 3, 10, 50, 4 };
            bool isIncreasing = (data[1] - data[0]) > 0;
            var index = FindInflectionPoint(data, 0, data.Length - 1, isIncreasing);
            Console.WriteLine($"Test 1 Passed = { index == 3}");
        }

        private static void Test2()
        {
            var data = new[] { 1, 5, 10, 15, 20, 25, 30, 18, 12, 6, 2};
            bool isIncreasing = (data[1] - data[0]) > 0;
            var index = FindInflectionPoint(data, 0, data.Length - 1, isIncreasing);
            Console.WriteLine($"Test 2 Passed = { index == 8}");

        }
        private static void Test3()
        {
            var data = new[] { 7, 5, 3, 1, 2, 4, 6, 8 };
            bool isIncreasing = (data[1] - data[0]) > 0;
            var index = FindInflectionPoint(data, 0, data.Length - 1, isIncreasing);
            Console.WriteLine($"Test 3 Passed = { index == 3}");
        }

        private static void Test4()
        {
            var data = new int[] { } ;
            if (data.Length > 2)
            {
                bool isIncreasing = (data[1] - data[0]) > 0;
                var index = FindInflectionPoint(data, 0, data.Length - 1, isIncreasing);
                Console.WriteLine($"Test 4 Passed = { index == 3}");
            }
            else
            {
                Console.WriteLine($"Test 4 not valid input");
            }
        }

        public static int FindInflectionPoint(int[] input, int lowerIndex, int higherIndex, bool isIncreasing)
        {
            if (input == null || (higherIndex - lowerIndex) < 2)
            {
                return -1;
            }

            int mid = lowerIndex + (higherIndex - lowerIndex) / 2;
            var lowerIncreasing = input[mid] - input[mid - 1] > 0;
            var higherIncreasing = input[mid + 1] - input[mid] > 0;
            if (lowerIncreasing && higherIncreasing)
            {
                if (isIncreasing && (!lowerIncreasing))
                {
                    isIncreasing = (input[mid + 1] - input[mid]) > 0;
                    return FindInflectionPoint(input, mid, higherIndex, isIncreasing);
                }
                else
                {
                    return FindInflectionPoint(input, mid, higherIndex, isIncreasing);
                }
            }
            else
            {
                return mid;
            }
        }
    }
}
