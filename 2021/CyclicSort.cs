using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp._2021
{
    public class CyclicSort
    {
        public static void Tests()
        {
            SortCyclic(new int[] { 1, 3, 2, 5, 4 });
            Console.WriteLine();
            SortCyclic(new int[] { 5, 4, 3, 2, 1 });

            Console.WriteLine("Find missing number..");
            Console.WriteLine($"Missing no = {FindMissingNo(new int[]{ 4, 0, 3, 1})}");

            Console.WriteLine($"Missing no = {FindMissingNo(new int[] { 8, 3, 5, 2, 4, 6, 0, 1 })}");

            var result = FindMissingNo(new int[] { 2, 3, 1, 8, 2, 3, 5, 1 });

            var result2 = Smallest_Missing_Positive_Number(new int[] { -3, 1, 5, 4, 2});
            var result3 = Smallest_Missing_Positive_Number(new int[] { 3, -2, 0, 1, 2 });
            var result4 = Smallest_Missing_Positive_Number(new int[] { 1, -2, 0, 5, 2 });
        }


        public static int Smallest_Missing_Positive_Number(int[] input)
        {
            int index = -1;
            while (++index < input.Length)
            {
                while (input[index] != index + 1 && (input[index] > 0) && input[index] < input.Length)
                {
                    Swap(input, index, input[index] - 1);
                }
            }

            index = -1;
            while (++index < input.Length && input[index] == index + 1) ;

            return index + 1;
        }

        public static List<int> findMissingNumbers(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] != nums[nums[i] - 1])
                    Swap(nums, i, nums[i] - 1);
                else
                    i++;
            }

            List<int> missingNumbers = new List<int>();
            for (i = 0; i < nums.Length; i++)
                if (nums[i] != i + 1)
                    missingNumbers.Add(i + 1);

            return missingNumbers;
        }

        public static int FindMissingNo(int[] input)
        {
            int missingIndex = input.Length;
            int index = -1;
            while (index++ < input.Length - 1)
            {
                bool swap = true;
                while (swap && input[index] != index)
                {
                    if (input[index] == input.Length || input[index] == -1)
                    {
                        missingIndex = index;
                        input[index] = -1;
                        swap = false;
                    }
                    else if (input[index] == input[input[index]])
                    { 
                    
                    }
                    else
                    {
                        Swap(input, input[index], index);
                    }
                }
            }

            return missingIndex;
        }

        public static int[] SortCyclic(int[] input)
        {
            Console.WriteLine($"Start-> [{string.Join(", ", input)}]");
            int index = 0;
            while (index < input.Length)
            {
                while (input[index] != index + 1)
                {
                    Swap(input, input[index]-1, index);
                }
                index++;
            }
            Console.WriteLine($"End-> [{string.Join(", ", input)}]");

            return input;
        }

        private static void Swap(int[] input, int index1, int index2)
        {
            int temp = input[index1];
            input[index1] = input[index2];
            input[index2] = temp;
            Console.WriteLine($"Swap {index1} - {index2}");
        }
    }
}
