using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Linq;

namespace ConsoleApp._2021
{
    public class DataStructuresPractice
    {
        /// <summary>
        /// Array, Queue, List, Stack
        /// Comparare
        /// Heap Class
        /// </summary>
        public static void Tests()
        {
            PracticeQueueOperations(GetInterval(10));
            PracticeStackOperations(GetInterval(10));
            PracticeDictionaryOperations(GetInterval(10));
        }

        private static void PracticeDictionaryOperations(List<Interval> intervals)
        {
            
        }

        private static void PracticeStackOperations(List<Interval> intervals)
        {
            
        }

        private static void PracticeQueueOperations(List<Interval> intervals)
        {
            Console.WriteLine("Dictionary operations --------------");
            var dict = new Dictionary<int, Interval>();
            foreach (var item in intervals)
            {
                if (!dict.ContainsKey(item.Start))
                {
                    dict.Add(item.Start, item);
                }
            }

            Console.WriteLine($"Dict count = {dict.Count}");

            var iterator = dict.GetEnumerator();
            while (iterator.MoveNext())
            {
                PrintInterval(iterator.Current.Value);
            }

            Console.WriteLine("Accessing index 0 al the times");
            int count = dict.Count - 1;
            while (count > 0)
            {
                PrintInterval(dict.ElementAt(0).Value);
                dict.Remove(dict.ElementAt(0).Key);
                count--;
            }

            Console.WriteLine("END ----- Dictionary operations --------------");
        }

        public static void PrintList(List<Interval> intervals)
        {
            foreach (var item in intervals)
            {
                PrintInterval(item);
            }
        }

        private static void PrintInterval(Interval item)
        {
            Console.WriteLine($"[{item.Start}, {item.End}]");
        }

        public static List<Interval> GetInterval(int count)
        {
            var output = new List<Interval>(count);
            var random = new Random(1);
            for (int i = 0; i < count; i++)
            {
                int start = random.Next(0, 50);
                int end = random.Next(start + 1, start + 10);
                output.Add(new Interval(start, end));
            }

            return output;
        }

    }
}
