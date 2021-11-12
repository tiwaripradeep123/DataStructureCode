using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleApp
{
    class Job:IComparable<Job>
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int CPUUnit { get; set; }

        public Job(int start, int end, int unit)
        {
            this.Start = start;
            this.End = end;
            this.CPUUnit = unit;
        }

        public int CompareTo([AllowNull] Job other)
        {
            return this.Start - other.Start;
        }

        public override string ToString()
        {
            return $"[{Start}, {End}, {CPUUnit}]";
        }
    }
    public class PriorityQueueTests
    {
        public static void Tests()
        {
            var jobsArray = new int[,] {{ 2, 5, 4 }, { 7, 9, 6 }, { 1, 4, 3 } };
            var jobs = new List<Job>();
            for (int i = 0; i < jobsArray.GetLength(0); i++)
            {
                jobs.Add(new Job(jobsArray[i,0], jobsArray[i,1], jobsArray[i,2]));
            }

            jobs.Sort();
            var pq = new PriorityQueue<Job>();
            var maxCPUCount = 0;
            foreach (var item in jobs)
            {
                while (pq.Count > 0)
                { 
                   
                }

                Console.WriteLine(item.ToString());
            }

                    }
    }

    public class PriorityQueue<Q>
    {
        Dictionary<int, Q> Data { get; set; }

        public int Count
        {
            get
            {
                return Data.Count;
            }
        }

        public void Push(int key, Q value)
        {
            if (Data.ContainsKey(key))
            {
                Data[key]= value;
            }
            else {
                Data.Add(key, value);
            }
        }

        public Q Pop()
        {
            try
            {
                var element = PeekInternal();
                Data.Remove(element.Key);
                return element.Value;
            }
            catch
            {
            }

            return default(Q);
        }


        KeyValuePair<int, Q> PeekInternal()
        {
            if (Data.Count > 0)
            {
                var itr = Data.GetEnumerator();
                itr.MoveNext();
                var min = itr.Current;
                while (itr.MoveNext())
                {
                    if (min.Key > itr.Current.Key)
                    {
                        min = itr.Current;
                    }
                }
               
                return min;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public Q Peek()
        {
            var element = PeekInternal();
            return element.Value;
        }

    }
}
