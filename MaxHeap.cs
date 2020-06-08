using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    /// <summary>
    /// This is 0 based index 
    /// </summary>
    public class MaxHeap
    {
        public int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        public int LeftChildIndex(int pIndex)
        {
            return 2 * pIndex + 1;
        }

        public int RightChildIndex(int pIndex)
        {
            return 2 * pIndex + 2;
        }

        public void Swap(int[] dataArray, int index1, int index2)
        {
            int data = dataArray[index1];
            dataArray[index1] = dataArray[index2];
            dataArray[index2] = data;
        }



        public void Heapify(int[] dataArry, int size, int startIndex = -1)
        {
            if (startIndex == -1)
            {
                startIndex = size -1;
            }

            if (startIndex >= 1 && startIndex < size)
            {
                int pi = ParentIndex(startIndex);
                int rci = RightChildIndex(pi);
                int lci = LeftChildIndex(pi);
                int mci = rci < size && dataArry[rci] > dataArry[lci] ?  rci : lci;
                if (dataArry[pi] < dataArry[mci])
                {
                    Swap(dataArry, pi, mci);
                    HeapifyDown(dataArry, size, mci);
                }

                Heapify(dataArry, size, lci-1);
            }
        }

        private void HeapifyDown(int[] dataArry, int size,int pi)
        {
            int rci = RightChildIndex(pi);
            int lci = LeftChildIndex(pi);
            if (pi < size && lci < size)
            {
                int mci = rci < size && dataArry[rci] > dataArry[lci] ? rci : lci;
                if (dataArry[pi] < dataArry[mci])
                {
                    Swap(dataArry, pi, mci);
                    HeapifyDown(dataArry, size, mci);
                }
            }
        }

        public static void Test()
        {
            var input = new int[] { 10, 11, 3, 1, 2, 16, 100, 88, 17 };
            var input2 = new int[] { 4, 10, 3, 5, 1 };
            var input3 = new int[] { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17 };
            ProcessAndDisplayResult(input);
            ProcessAndDisplayResult(input2);
            ProcessAndDisplayResult(input3);
        }

        private static void ProcessAndDisplayResult(int[] input)
        {
            Console.WriteLine($"Input : {string.Join(" , ", input)}");
            var maxHeap = new MaxHeap();
            maxHeap.Heapify(input, input.Length);
            Console.WriteLine($"Max Heap : {string.Join(" , ", input)}");
        }
    }
}
