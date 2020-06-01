using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp
{
    /// <summary>

    /// </summary>
    public static class RandomProblems
    {
        /// <summary>
        /// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// Example:
        /// Given nums = [2, 7, 11, 15], target = 9,
        /// Because nums[0] + nums[1] = 2 + 7 = 9,
        /// return [0, 1].
        /// </summary>
        public static void TwoSumProblem()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            int target = 9;
            var expected = new int[] { 0, 1 };
            var actual = TwoSum(nums, target);
            for (int i = 0; i < expected.Length; i++)
            {
                if (expected[i] != actual[i])
                {
                    Console.WriteLine("Failed !");
                    return;
                }
            }
            Console.WriteLine("Passed !");
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, List<int>> hashTable = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (hashTable.ContainsKey(nums[i]))
                {
                    hashTable[nums[i]].Add(i);
                }
                else
                {
                    hashTable.Add(nums[i], new List<int> { { i } });

                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var lookupKey = target - nums[i];
                if (hashTable.ContainsKey(lookupKey))
                {
                    var data = hashTable[nums[i]].FirstOrDefault(x => x != i);
                    if (data > 0)
                    {
                        return new int[] { i, data };
                    }
                }
            }

            return new int[] { };
        }
    }
}
