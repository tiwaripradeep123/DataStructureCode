using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    /// <summary>
    /// https://leetcode.com/contest/weekly-contest-191/problems/maximum-area-of-a-piece-of-cake-after-horizontal-and-vertical-cuts/
    /// </summary>
    public static class MaximumAreaCake
    {
        public static void MaximumAreaCakeCaller()
        {
            var actual = MaxArea(5, 4, new int[] { 3, 1 }, new int[] { 1 });
            Console.WriteLine($"Is MaximumAreaCake success = {actual == 6}");

            actual = MaxArea(5, 4, new int[] { 3, 1 }, new int[] { 1 });
            Console.WriteLine($"Is MaximumAreaCake success = {actual == 6}");
        }

        public static int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            var dataHorizontal = horizontalCuts.ToList();
            dataHorizontal.Sort();
            var horizontalCutsSorted = dataHorizontal.ToArray();
            int horizontalCutGap = horizontalCutsSorted[0];
            for (int i = 1; i < horizontalCutsSorted.Length; i++)
            {
                var thisCut = horizontalCutsSorted[i] - horizontalCutsSorted[i - 1];
                if (thisCut > horizontalCutGap)
                {
                    horizontalCutGap = thisCut;
                }
            }
            var lastHorizontalCutGap = h - horizontalCutsSorted[horizontalCutsSorted.Length-1];
            if (lastHorizontalCutGap > horizontalCutGap)
            {
                horizontalCutGap = lastHorizontalCutGap;
            }

            var dataVertical = verticalCuts.ToList();
            dataVertical.Sort();
            var verticalCutsSorted = dataVertical.ToArray();

            int verticalCutGap = verticalCutsSorted[0];
            for (int i = 1; i < verticalCutsSorted.Length; i++)
            {
                var thisCut = verticalCutsSorted[i] - verticalCutsSorted[i - 1];
                if (thisCut > verticalCutGap)
                {
                    verticalCutGap = thisCut;
                }
            }

            var lastVerticalCutGap = w - verticalCutsSorted[verticalCutsSorted.Length -1 ];
            if (lastVerticalCutGap > verticalCutGap)
            {
                verticalCutGap = lastVerticalCutGap;
            }

            return horizontalCutGap * verticalCutGap;
        }
    }
}
