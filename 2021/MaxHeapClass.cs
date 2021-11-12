using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp._2021
{
    public class MaxHeapClass
    {
        public static void Tests ()
        {
            var input1 = new int[] { };
            var result1 = BuildMaxHeap(input1);
            Console.WriteLine($"[{string.Join(",", input1)}] -> [{string.Join(",", result1)}] ");
            input1 = new int[] { 1};
            result1 = BuildMaxHeap(input1);
            Console.WriteLine($"[{string.Join(",", input1)}] -> [{string.Join(",", result1)}] ");
            input1 = new int[] { 1, 2};
            result1 = BuildMaxHeap(input1);
            Console.WriteLine($"[{string.Join(",", input1)}] -> [{string.Join(",", result1)}] ");
            input1 = new int[] { 10, 30, 20 , 90, 50, 25, 11 };
            var inputString =  string.Join(",", input1);
            result1 = BuildMaxHeap(input1);
            Console.WriteLine($"[{inputString}] -> [{string.Join(",", result1)}] ");
            input1 = new int[] { 1, 5, 7, 2, 3, 9, 6};
            inputString = string.Join(",", input1);
            result1 = BuildMaxHeap(input1);
            Console.WriteLine($"[{inputString}] -> [{string.Join(",", result1)}] ");

            input1 = new int[] { 1, 5, 7, 2, 3, 9, 6 };
            inputString = string.Join(",", input1);
            result1 = MaxHeapSort(input1);
            Console.WriteLine($"[{inputString}] -> [{string.Join(",", result1)}] ");

        }


        public static int[] MaxHeapSort(int[] input)
        {

            int index = input.Length - 1;
            HeapifyUp(input, index);
            Swap(input, 0, index);
            index--;
            while (index > 0)
            {
                HeapifyDown(input, 0, index);
                Swap(input, 0, index);
                index--;
            }

            return input;
        }


        private static int[] BuildMaxHeap(int[] input)
        {
            if (input != null || input.Length > 1)
            {

                HeapifyUp(input, input.Length - 1);
            }

            return input;
        }

        private static void HeapifyUp(int[] input, int index)
        {
            if (input.Length > index && index > 0)
            {
                int right = index % 2 == 0 ? index : -1;
                int left = index % 2 == 0 ? index - 1 : index;

                int bigger = right == -1 || input[right] <= input[left] ? left : right;
                int parent = left / 2;
                if (input[parent] < input[bigger])
                {
                    Swap(input, parent, bigger);
                    HeapifyDown(input, bigger);
                }

                HeapifyUp(input, left-1);
            }
        }

        private static void HeapifyDown(int[] input, int parent, int lastIndex = -1)
        {
            int left = parent * 2 + 1;
            lastIndex = lastIndex == -1 ? input.Length - 1 : lastIndex;
            if (left <= lastIndex)
            {
                int right = (left + 1) <= lastIndex ? (left + 1) : -1;

                int bigger = right != -1 && input[right] > input[left] ? right : left;
                if (input[parent] < input[bigger])
                {
                    Swap(input, parent, bigger);
                    HeapifyDown(input, bigger, lastIndex);
                }
            }
        }

        private static void Swap(int[] input, int parent, int bigger)
        {
            var data = input[parent];
            input[parent] = input[bigger];
            input[bigger] = data;
        }
    }
}
