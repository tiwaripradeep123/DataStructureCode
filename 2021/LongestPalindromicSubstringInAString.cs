using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp._2021
{
    public static class LongestPalindromicSubstringInAString
    {
        public static void Tests()
        {
            string input1 = "agbdba";
            var result1 = LongestPalindromicSubstringInAStringDP(input1);
            Console.WriteLine($"Biggest Pelindromic in [{input1}] is [{result1}]");

            var result2 = LongestPalindromicSubstringInAStringDP("aaa");
            Console.WriteLine($"Biggest Pelindromic in [{"aaa"}] is [{result2}]");

            var result3 = LongestPalindromicSubstringInAStringDP("aaababbaa");
            Console.WriteLine($"Biggest Pelindromic in [{input1}] is [{result3}]");
        }

        private static string LongestPalindromicSubstringInAStringDP(string input)
        {
            int inpLength = input.Length;
            var matrix = new int[inpLength, inpLength];
            for (int len = 1; len <= inpLength; len++)
            {
                for (int start = 0; start <= (inpLength - len); start++)
                {
                    if (len == 1)
                    {
                        matrix[start, start] = 1;
                    }
                    else {
                        int end = start + (len - 1);
                        if (input[start] == input[end])
                        {
                            matrix[start, end] = 2 + matrix[start + 1, end - 1];
                        }
                        else {
                            int row = matrix[start, end - 1];
                            int column = matrix[start + 1, end];
                            matrix[start, end] = row >= column ? row : column;
                        }
                    }
                   
                }
            }
            var outputLength = matrix[0, inpLength - 1];
            var resultArray = new char[outputLength];
            int rowIndex = 0;
            int columnIndex = inpLength - 1;
            int charIndex = 0;
            while (outputLength >= charIndex)
            {
                int value = matrix[rowIndex, columnIndex];
                if (value == 1)
                {
                    resultArray[charIndex] = input[columnIndex];
                    break;
                }
                else if (value == 0)
                {
                    break;
                }
                else
                {
                    if (value != matrix[rowIndex + 1, columnIndex] && value != matrix[rowIndex, columnIndex - 1])
                    {
                        resultArray[charIndex] = input[columnIndex];
                        resultArray[outputLength - charIndex - 1] = input[columnIndex];
                        charIndex++;
                        rowIndex++;
                        columnIndex--;
                    }
                    else if (matrix[rowIndex + 1, columnIndex] >= matrix[rowIndex, columnIndex - 1])
                    {
                        rowIndex++;
                    }
                    else
                    {
                        columnIndex--;
                    }
                }
            }


            return string.Join(string.Empty, resultArray) ;
        }
    }
}
