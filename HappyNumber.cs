using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{

    /// <summary>
    /// Happy number 
    /// Input: n = 19
    /// Output: true
    /// Explanation:
    /// 1^2 + 9^2 = 82
    /// 8^2 + 2^2 = 68
    /// 62 + 82 = 100
    /// 12 + 02 + 02 = 1
    /// 19 => Square(1)+Sqaure(9) == 1 
    /// input range -> +ve number 
    /// 1. 19 => 1 , 9 
    /// 2. X = Sum of all numbers 
    /// 3. Is X == 1 
    ///     >> true 
    ///     >> False
    ///     Perform same opration for X
    ///     
    /// 1*1 +  9*9 = 82 = 8*8 + 2*2= 68 
    /// ==1  
    /// 
    /// numbers -> 19, 82, b, v
    /// 
    /// </summary>
    public static class HappyNumber
    {

        public static bool IsHappyNumber(int input)
        {
            var numbers = new List<int>();
            while (!numbers.Contains(input))
            {
                if (!numbers.Contains(input))
                {
                    numbers.Add(input);
                }
                input = GetNewNumber(input);
                if (input == 1)
                {
                    return true;
                }
            }

            return false; 
        }

        public static bool IsHappyNumberRecursion(int input, List<int> nums = null)
        {
            if (nums == null)
            {
                nums = new List<int>();
            }

            if (input == 1)
            {
                return true;
            }
            else if (nums.Contains(input))
            {
                return false;
            }
            else
            {
                nums.Add(input);
                return IsHappyNumberRecursion(GetNewNumber(input), nums);
            }
        }



        public static int GetNewNumber(int input)
        {
            int result = 0;
            int number = 0;
            while (input > 0)
            {
                number = input % 10;
                result += (number * number);
                input = input / 10; 
            }

            return result;
        }
    }
}
