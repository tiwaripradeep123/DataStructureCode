using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{

    /// <summary>
    /// Given a string, find the length of the longest substring without repeating characters
    /// 
    /// </summary>
    public class LongestSubstring
    {
        public static void Test() 
        {
            var input1 = " ";
            Console.WriteLine($"input [{input1}] -> {LengthOfLongestSubstring(input1)}");

            input1 = "abcabcbb"; 
            Console.WriteLine($"input [{input1}] -> {LengthOfLongestSubstring(input1)}");

            input1 = "abcabcbb";
            Console.WriteLine($"input [{input1}] -> {LengthOfLongestSubstring(input1)}");

            input1 = "abcabcbb";
            Console.WriteLine($"input [{input1}] -> {LengthOfLongestSubstring(input1)}");

        }
        public static  int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            if (s.Length == 1)
            {
                return 1;
            }
            else
            {
                var flags = new Dictionary<char, int>();
                int result = 0;
                int startIndex = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    var key = s[i];
                    if (flags.ContainsKey(key) && flags[key] >= startIndex)
                    {
                        result = result < i - startIndex ? i - startIndex : result;
                        startIndex = flags[key] + 1;
                    }

                    flags[key] = i;
                }

                return result > s.Length - startIndex ? result : s.Length - startIndex;
            }
        }
    }
}
