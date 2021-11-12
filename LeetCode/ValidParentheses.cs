using System;
using System.Collections.Generic;

namespace ConsoleApp.LeetCode
{
    public class ValidParentheses
    {
        public static void Tests()
        {

            var input = "(())";
            var acutal = true; // ValidParenthesesRecursive(input);
            Console.WriteLine($"Expected : true, actual {acutal}");

            var output = RemoveInvalidParameters("()())()");
            output = RemoveInvalidParameters(")(india)(a))()");

            var results = GenerateAllValid("(a)())()");

        }

        private static List<string> GenerateAllValid(string input, Dictionary<string, bool> memo = null)
        {
            if (memo == null)
            {
                memo = new Dictionary<string, bool>();
            }

            if (memo.ContainsKey(input) && memo[input])
            {
                return new List<string> { input };
            }
            else
            { 
               // var 
            }

            return null;
        }



        private static string RemoveInvalidParameters(string input)
        {
            var stack = new Stack<int>();
            int i = 0;
            while (i < input.Length)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else {
                      input = input.Remove(i, 1);
                        i--;
                    }
                }
                i++;
            }

            while (stack.Count > 0)
            {
                input = input.Remove(stack.Pop(), 1);
            }

            return input;
        }

        //private static bool ValidParenthesesRecursive(string input)
        //{
        //    if (input == null || input.Length % 2 == 1 || input.Length <= 1)
        //    {
        //        return false;
        //    }

        //    var index = ValidParenthesesRecursive(input, 0, 1);
        //}

        //private static int ValidParenthesesRecursive(string input, int open, int close)
        //{
        //    if (IsOpening(input[close]))
        //    {
        //        var newclose = ValidParenthesesRecursive(input, close, close + 1);
        //        if (newclose == -1 || newclose == input.Length)
        //        {
        //            return -1;
        //        }
        //    }
        //    else {
        //        if (!IsMatch(input[close], input[open]))
        //        {
        //            return -1;
        //        }
        //        else
        //        {
        //            return close + 1;
        //        }
        //    }
        //}

        public static bool IsMatch(char close, char open)
        {
            bool isMatch = false;
            switch (close)
            {
                case ')':
                    isMatch = open == '(';

                    break;
                case ']':
                    isMatch = open == '[';
                    break;
                case '}':
                    isMatch = open == '{';
                    break;
            }

            return isMatch;
        }

        public static bool IsOpening(char c)
        {
            switch (c)
            {
                case '(':
                case '{':
                case '[':
                    return true;
                    break;
                default:
                    return false;
                    break;
            } 
        }
    }
}