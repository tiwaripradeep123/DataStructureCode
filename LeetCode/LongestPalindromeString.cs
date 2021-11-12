using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.LeetCode
{
    public static class LongestPalindromeString
    {
        public static void Tests()
        {
            string input1 = "bacac";
            string output1 = LongestPalindromeStringByExpandAroundCorner(input1);
        }

        public static string LongestPalindromeStringByBruteForce(string input)
        {
            return "";
        }

        public static string LongestPalindromeStringByDP(string input)
        {
            return "";
        }

        public static string LongestPalindromeStringByManacherAlog(string input)
        {
            int[] results = new int[input.Length];
            results[0] = 1;
            for (int i = 1; i < input.Length; i++)
            {
                //int j = i;
                //while()
                //int count = ExpandAroundCornerCount(input, i - 1, i + 1);
            }
            
            return "";
        }


        private static string LongestPalindromeStringByExpandAroundCorner(string input1)
        {
            string output = "";
            for (int i = 0; i < input1.Length; i++)
            {
                string localOutputEven = ExpandAroundCorner(input1, i, i + 1);
                string localOutputOdd = ExpandAroundCorner(input1, i-1, i+1);
                if (localOutputEven.Length > output.Length)
                {
                    output = localOutputEven;
                }

                if (localOutputOdd.Length > output.Length)
                {
                    output = localOutputOdd;
                }
            }

            return output;
        }

        private static string ExpandAroundCorner(string input1, int low, int high)
        {
            while (low >= 0 && high < input1.Length && input1[low] == input1[high])
            {
                low--;
                high++;
            }
            low +=1;
            return input1.Substring(low, high - low);
        }

        private static int ExpandAroundCornerCount(string input1, int low, int high)
        {
            while (low >= 0 && high < input1.Length && input1[low] == input1[high])
            {
                low--;
                high++;
            }
            low += 1;
            return high - low - 1;
        }
    }
}
