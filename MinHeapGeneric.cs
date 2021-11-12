using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace ConsoleApp
{

    public class Interval : IComparable<Interval>
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Interval(int s, int e)
        {
            this.Start = s;
            this.End = e;
        }

        public int CompareTo(Interval other)
        {
            return this.Start - other.Start;
        }
    }
    /// <summary>
    /// This is 0 based index 
    /// </summary>
    public class MinHeapGeneric
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

        public void Swap(Interval[] dataArray, int index1, int index2)
        {
            Interval data = dataArray[index1];
            dataArray[index1] = dataArray[index2];
            dataArray[index2] = data;
        }

        public void Heapify(Interval[] dataArry, int size, int startIndex = -1)
        {
            if (startIndex == -1)
            {
                startIndex = size - 1;
            }

            if (startIndex >= 1 && startIndex < size)
            {
                int pi = ParentIndex(startIndex);
                int rci = RightChildIndex(pi);
                int lci = LeftChildIndex(pi);
                int mci = rci < size && dataArry[rci].Start > dataArry[lci].Start ? rci : lci;
                if (dataArry[pi].Start < dataArry[mci].Start)
                {
                    Swap(dataArry, pi, mci);
                    HeapifyDown(dataArry, size, mci);
                }

                Heapify(dataArry, size, lci - 1);
            }
        }

        private void HeapifyDown(Interval[] dataArry, int size, int pi)
        {
            int rci = RightChildIndex(pi);
            int lci = LeftChildIndex(pi);
            if (pi < size && lci < size)
            {
                int mci = rci < size && dataArry[rci].Start > dataArry[lci].Start ? rci : lci;
                if (dataArry[pi].Start < dataArry[mci].Start)
                {
                    Swap(dataArry, pi, mci);
                    HeapifyDown(dataArry, size, mci);
                }
            }
        }

        public static void Tests()
        {
            var arra = new Interval[5];
            arra[0] = new Interval(5, 6);
            arra[1] = new Interval(1, 3);
            arra[2] = new Interval(0, 2);
            arra[3] = new Interval(9, 11);
            arra[4] = new Interval(6, 8);

            var list = arra.ToList<Interval>();
            list.Sort();

            list.Sort((x, y) => y.Start - x.Start);

            Array.Sort(arra, (x, y) => x.Start - y.Start);

            Array.Sort(arra);
        }

        private static void ProcessAndDisplayResult(int[] input)
        {

        }
    }
}
