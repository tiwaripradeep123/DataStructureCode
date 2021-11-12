using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Educative
{
    public class FindCommonAvailability
    {
        public class Interval
        {
            public int Start { get; set; }
            public int End { get; set; }

            public Interval(int start, int end)
            {
                this.Start = start;
                this.End = end;
            }
        }

        public static void Tests()
        {
            // [
            // [[1,3], [5,6]],
            // [[1,2], [2,4], [6,8]]
            // [[3,4], [5,9]]
            // ]

            var input = new List<List<Interval>>();
            input.Add(
                new List<Interval>
                {
                    new Interval(1,3),
                    new Interval(5,6),
                });
            input.Add(
                new List<Interval>
                {
                    new Interval(1,2),
                    new Interval(2,4),
                    new Interval(6,8),
                });
            input.Add(
               new List<Interval>
               {
                    new Interval(3,4),
                    new Interval(5,9),
               });

            var result = FindCommonAvailabilityIntervals(input);
            foreach (var item in result)
            {
                Console.WriteLine($"[{item.Start}, {item.End}]");
            }
            Console.WriteLine($"-------------------------");
            input = new List<List<Interval>>();
            input.Add(
                new List<Interval>
                {
                    new Interval(1,3),
                    new Interval(5,6),
                });
            input.Add(
                new List<Interval>
                {
                    new Interval(2,3),
                    new Interval(6,8),
                });
            result = FindCommonAvailabilityIntervals(input);
            foreach (var item in result)
            {
                Console.WriteLine($"[{item.Start}, {item.End}]");
            }

            Console.WriteLine($"-------------------------");
            input = new List<List<Interval>>();
            input.Add(
                new List<Interval>
                {
                    new Interval(1,3),
                    new Interval(9, 12),
                });
            input.Add(
                new List<Interval>
                {
                    new Interval(2,4),
                    new Interval(6,8),
                });
            result = FindCommonAvailabilityIntervals(input);
            foreach (var item in result)
            {
                Console.WriteLine($"[{item.Start}, {item.End}]");
            }

            Console.WriteLine($"-------------------------");
            input = new List<List<Interval>>();
            input.Add(
                new List<Interval>
                {
                    new Interval(1,3),
                });
            input.Add(
                new List<Interval>
                {
                    new Interval(2,4),
                });
            input.Add(
                new List<Interval>
                {
                    new Interval(3,5),
                    new Interval(7,9),
                });
            result = FindCommonAvailabilityIntervals(input);
            foreach (var item in result)
            {
                Console.WriteLine($"[{item.Start}, {item.End}]");
            }
        }

        private static List<Interval> FindCommonAvailabilityIntervals(List<List<Interval>> input)
        {
            var first = input[0];
            for (int i = 1; i < input.Count; i++)
            {
                int index = 0;
                foreach (var ivs in input[i])
                {
                    bool isProcessed = false;
                    while (index < first.Count && (first[index].End  < ivs.Start || ivs.End < first[index].Start))
                    {
                        if (ivs.End < first[index].Start)
                        {
                            first.Insert(index, ivs);
                            isProcessed = true;
                            break;
                        }
                        index++;
                    }
                    if (!isProcessed)
                    {
                        if (index >= first.Count)
                        {
                            first.Add(ivs);
                        }
                        else
                        {
                            first[index].Start = Math.Min(first[index].Start, ivs.Start);
                            first[index].End = Math.Max(first[index].End, ivs.End);
                            while ((index + 1 < first.Count) && first[index].End >= first[index + 1].Start)
                            {
                                first[index].End = Math.Max(first[index].End, first[index + 1].End);
                                first.RemoveAt(index + 1);
                            }
                        }
                    }
                }
            }

            var result = new List<Interval>();
            for (int i = 1; i < first.Count; i++)
            {
                result.Add(new Interval(first[i - 1].End, first[i].Start));
            }

            return result;
        }
    }
}