using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp._2021
{
    public static class MergeIntervals
    {
        public class Interval
        {
            public int Start { get; set; }
            public int End { get; set; }
        }

        public class Job : Interval
        {
            public int Load { get; set; }
        }

        public static void Tests()
        {
            var Intervals = new Interval[] { 
            new Interval { Start = 2, End = 5 },
            new Interval { Start = 1, End = 2 },
            new Interval { Start = 10, End = 15 },
            new Interval { Start = 11, End = 12 },
            new Interval { Start = 17, End = 19 },
            new Interval { Start = 20, End = 22 },
            new Interval { Start = 21, End = 24 }};

            var result = MergeIntervalsExamples(Intervals);

            var result2 = IncludeIntervals(result, new Interval { Start = 14, End = 18 });

            var II2 = new Interval[] {
            new Interval { Start = 1, End = 3 },
            new Interval { Start = 5, End = 7 },
            new Interval { Start = 8, End = 12 }};
            var result3 = IncludeIntervals(II2.ToList(), new Interval { Start = 4, End = 6 });

            var result4 = IncludeIntervals(II2.ToList(), new Interval { Start = 4, End = 10 });


            var jobs = new Job[] {
            new Job { Start = 1, End =4, Load = 3 },
            new Job { Start = 2, End = 5, Load=4 },
            new Job { Start = 7, End = 9, Load = 6 }};

            int resultMaxCPULoad = Max_CPU_Load(jobs.ToList());

            jobs = new Job[] {
            new Job { Start = 6, End =9, Load = 10 },
            new Job { Start = 2, End = 4, Load= 11 },
            new Job { Start = 8, End = 12, Load = 15 }};

            Array.Sort(jobs, (a, b) => a.Start < b.Start ? -1 : 1);

            resultMaxCPULoad = Max_CPU_Load(jobs.ToList());

        }

        public static int Max_CPU_Load(List<Job> jobs)
        {
            int lmax = 0;
            for (int i = 0; i < jobs.Count; i++)
            {
                int ll = GetLoadAt(jobs, jobs[i].Start, i);
                lmax = lmax > ll ? lmax : ll;
            }
            return lmax;
        }

        private static int GetLoadAt(List<Job> jobs, int start, int lastIndex)
        {
            int load = 0;
            int index = -1;
            while (++index <= lastIndex)
            {
                if (jobs[index].Start <= start && jobs[index].End >= start)
                {
                    load += jobs[index].Load;
                }
            }

            return load;
        }

        private static List<Interval> IncludeIntervals(List<Interval> result, Interval interval)
        {
            if (interval.End < result[0].Start)
            {
                result.Insert(0, interval);
            }
            else if (interval.Start > result[result.Count - 1].End)
            {
                result.Add(interval);
            }
            int index = -1;
            while (++index < result.Count && !IsNotOverlapping(interval, result[index]));
            if (interval.Start < result[index].Start)
            {
                result[index].Start = interval.Start;
            }
            if (interval.End > result[index].End)
            {
                result[index].End = interval.End;
            }
            bool repeat = true;
            index++;
            while (repeat && index < result.Count)
            {
                if (result[index - 1].End > result[index].Start)
                {
                    if (result[index - 1].End < result[index].End)
                    {
                        result[index - 1].End = result[index].End;
                        repeat = false;
                    }

                    result.RemoveAt(index);
                }
                else {
                    repeat = false;
                }
            }
            return result;
        }

        private static bool IsNotOverlapping(Interval interval1, Interval interval2)
        {
            return (interval1.Start >= interval2.Start && interval1.Start <= interval2.End) ||
                (interval1.End >= interval2.Start && interval1.End <= interval2.End) ||
                (interval1.Start <= interval2.Start && interval1.End >= interval2.End) ||
                (interval1.Start >= interval2.Start && interval1.End <= interval2.End);
        }

        private static List<Interval> MergeIntervalsExamples(Interval[] Intervals)
        {
            Array.Sort<Interval>(Intervals, (a, b) => a.Start < b.Start ? -1 : 1);
            var result = new List<Interval>();
            var thisInterval = Intervals[0];
            for (int i = 1; i < Intervals.Length; i++)
            {
                if (thisInterval.End < Intervals[i].Start)
                {
                    result.Add(thisInterval);
                    thisInterval = Intervals[i];
                }
                else if (thisInterval.End < Intervals[i].End)
                {
                    thisInterval.End = Intervals[i].End;
                }
            }

            result.Add(thisInterval);

            return result;
        }
    }
}
