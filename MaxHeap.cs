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
        public int Count { get; private set; }

        int[] Data = new int[10];

        public MaxHeap() : this(null)
        {

        }

        public MaxHeap(int[] data)
        {
            if (data != null)
            {
                this.Data = data;
                Count = data.Length;
            }
        }

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

        public void Swap(int index1, int index2)
        {
            int data = Data[index1];
            Data[index1] = Data[index2];
            Data[index2] = data;
        }


        public void HeapifyUp(int index = -1)
        {
            if (index == -1)
            {
                index = Count - 1;
            }

            if (index >= 1)
            {
                int pi = ParentIndex(index);
                int rci = RightChildIndex(pi);
                int lci = LeftChildIndex(pi);
                int mci = rci < Count && Data[rci] > Data[lci] ? rci : lci;
                if (Data[pi] < Data[mci])
                {
                    Swap(pi, mci);
                    HeapifyDown(mci);
                }

                HeapifyUp(lci - 1);
            }
        }

        private void HeapifyDown(int pi)
        {
            int rci = RightChildIndex(pi);
            int lci = LeftChildIndex(pi);
            if (lci < Count)
            {
                int mci = rci < Count && Data[rci] > Data[lci] ? rci : lci;
                if (Data[pi] < Data[mci])
                {
                    Swap(pi, mci);
                    HeapifyDown(mci);
                }
            }
        }

        public static void Test()
        {
            for (int cnt = 0; cnt < 5; cnt++)
            {
                var random = new Random();
                var input = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    input[i] = random.Next(0, 20);
                    
                }
                var maxHeap = new MaxHeap(input);
                maxHeap.HeapifyUp();
                while (maxHeap.Count > 0)
                {
                    Console.Write($" {maxHeap.Pop()} ->");
                }

                Console.WriteLine();
            }
        }

        private int Pop()
        {
            var max = Data[0];
            Data[0] = Data[--Count];
            HeapifyDown(0);
            return max;
        }
    }
}
