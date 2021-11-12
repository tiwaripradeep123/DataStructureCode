using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.WayFairPrep
{
    public static class LongestPalendromicProduct
    {

        public static void Tests()
        {
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine($"{i}-> {LargestPalindrome(i)}");

            }
        }


        /*
            1. i -> From n to 1
                2. j-> from n to n 
                    1. num = i*j; 
                    2. Check if palindrome
                        1. if palindrome return sum % 1337
                        2. continue
        */
        public static int LargestPalindrome(int n)
        {

            int min = (int)Math.Pow(10, n-1) +1;
            int max = GetMax(n);
            var palindrome = 0;
            for (int i = min; i < max; i++)
            {
                for (int j = min; j < max; j++)
                {
                    var sum = i * j;
                    if (sum > palindrome && IsPalindrome(sum))
                    {
                        palindrome = sum;
                    }
                }
            }
            return palindrome/1337;
        }

        private static int GetMax(int n)
        {
            var num = 0;
            while (n-- >= 0)
            {
                num = 10 * num + 9;
            }

            return num;
        }

        public static  bool IsPalindrome(int sum)
        {
            int length = sum.ToString().Length - 1;
            var divisor = (int)Math.Pow(10, length);
            while (sum > 9)
            {
                if ((sum / divisor) == sum % 10)
                {
                    sum = sum % divisor;
                    divisor /= 100;
                    sum /= 10;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
