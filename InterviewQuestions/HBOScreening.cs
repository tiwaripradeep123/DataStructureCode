using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.InterviewQuestions
{
    public class StreamingCompanyScreening
    {
        /*

Find all occurrences of string needle, or any anagram of needle, in string haystack

haystack: "abcdefg" needle: "dec"        => [2]
haystack: "abcdecg" needle: "dec"        => [2, 3]

abccdecg
[2,3]

Needed:  - 4 
[d-1]
[c-2]
[e-1]

found
[c-2]
[]

4 

*/



// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
    {
        static void Main(string[] args)
        {


            var result = GetStartingIndexes("bbbc", "bbc");
            for (int end = 0; end < result.Count; end++)
            {
                Console.WriteLine(result[end]);
            }


        }

        /*
           O(n) => 
            abccdecg
            start =1, end = 2
        */

        public static List<int> GetStartingIndexes(string haystack, string needle)
        {

            var result = new List<int>();
            var dict = CreateNeedleWordCount(needle);
            int needleCount = needle.Length;
            var local = new Dictionary<char, int>();
            int start = -1;
            // while( start < end &&  local[chr] > dict[chr]
            for (int end = 0; end < haystack.Length; end++) // n  
            {
                var chr = haystack[end];
                if (dict.ContainsKey(chr))
                {
                    if (!local.ContainsKey(chr))
                    {
                        local.Add(chr, 1);
                    }
                    else
                    {
                        local[chr] += 1;
                    }


                    while (local[chr] > dict[chr])
                    {
                        local[haystack[++start]] -= 1;
                    }
                    if (end - start == needleCount)
                    {
                        result.Add(start + 1);
                    }

                }
                else
                {
                    local = new Dictionary<char, int>();
                    start = end;
                }
            }

            return result;
        }


        public static Dictionary<char, int> CreateNeedleWordCount(string word)
        {
            var result = new Dictionary<char, int>();
            foreach (var chr in word)
            {
                if (result.ContainsKey(chr))
                {
                    result[chr] += 1;
                }
                else
                {
                    result[chr] = 1;
                }
            }

            return result;
        }
    }
    }
}
