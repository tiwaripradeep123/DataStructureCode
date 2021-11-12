using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class SlidingWindows
    {
        public static void Test()
        {
            Console.WriteLine($"PermutationInAString -> abcd, permutation dc -> {PermutationInAString("abcd", "dc")}");
            Console.WriteLine($"PermutationInAString -> abcd, permutation dc -> {PermutationInAString("abcxcccdc", "dc")}");
            Console.WriteLine($"PermutationInAString -> abcd, permutation dc -> {PermutationInAString("abcxdcccdca", "dca")}");
            Console.WriteLine($"PermutationInAString -> abcd, permutation dc -> {PermutationInAString("abcxcccdc", "dc")}");
        }

        public static bool PermutationInAString(string str, string permutation)
        {
            if (string.IsNullOrWhiteSpace(permutation))
            {
                return true;
            }
            else if (string.IsNullOrWhiteSpace(str) || str.Length < permutation.Length)
            {
                return false;
            }

            var charDict = CreateCharDictionary(permutation);
            int totalChars = permutation.Length;
            int start = 0;
            for (int end = 0; end < str.Length; end++)
            {
                if (charDict.ContainsKey(str[end]))
                {
                    charDict[str[end]] -= 1;
                    if (charDict[str[end]] >= 0)
                    {
                        totalChars--;
                        if (totalChars == 0)
                        {
                            return true;
                        }
                    }
                    else {
                        if (charDict[str[end]] == charDict[str[start]])
                        {
                            start++;
                            charDict[str[end]] += 1;
                        }
                        else {
                            start = end;
                            charDict = CreateCharDictionary(permutation); ;
                            charDict[str[end]] -= 1;
                            totalChars = permutation.Length - 1;
                        }
                    }
                }
                else
                {
                    start = end+1;
                    charDict = CreateCharDictionary(permutation);
                    totalChars = permutation.Length ;
                }
            }
            return false;
        }

        private static Dictionary<char, int> CreateCharDictionary(string permutation)
        {
            var result = new Dictionary<char, int>();
            foreach (char c in permutation)
            {
                if (result.ContainsKey(c))
                {
                    result[c] += 1;
                }
                else {
                    result.Add(c, 1);
                }
            }

            return result;
        }
    }
}
