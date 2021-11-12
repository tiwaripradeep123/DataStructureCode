using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp._2021
{
    public class SlowAndFastPointers
    {
        public static void Tests()
        {
            PairWithGivenSumTest();
            RemoveAllDuplicatesTest();
        }

        private static void RemoveAllDuplicatesTest()
        {
            var input1 = new int[] { 1, 1, 1, 2, 3, 4, 4, 5, 5, 10 };
            var expected1 = 6;
            var actual1 = RemoveAllDuplicates(input1);
            Console.WriteLine($"RemoveAllDuplicates => {expected1 == actual1}");

            var actual2 = RemoveAllDuplicates(new int[] { 1, 1, 1,1 });
            Console.WriteLine($"RemoveAllDuplicates => {1 == actual2}");

            var actual3 = RemoveAllDuplicates(new int[] { 1, 2, 3, 4 });
            Console.WriteLine($"RemoveAllDuplicates => {4 == actual3}");
        }

        private static int RemoveAllDuplicates(int[] input1)
        {
            int duplicateIndex = -1;
            int index = 1;
            if (input1.Length >= 2)
            {
                while (index < input1.Length)
                {
                    if (duplicateIndex == -1 && input1[index - 1] == input1[index])
                    {
                        duplicateIndex = index;
                    }
                    if (duplicateIndex != -1 && input1[index - 1] != input1[index])
                    {
                        input1[duplicateIndex] = input1[index];
                        duplicateIndex++;
                    }
                    index++;
            } }

            return duplicateIndex == -1 ? input1.Length : duplicateIndex;
        }

        private static void PairWithGivenSumTest()
        {
            var Input1 = new List<int> { 1, 2, 3, 4, 6 };
            int target1 = 6;
            var expected1 = new List<int> { 1, 3 };
            var actual1 = PairWithGivenSum(Input1, target1);
            if (actual1.Count == expected1.Count && actual1[0] == expected1[0])
            {
                Console.WriteLine($"found : [{string.Join(",", actual1)}]");
            }
            else {
                Console.WriteLine("Failed.");
            }


            var Input2 = new List<int> { 2, 5, 9, 11 };
            int target2 = 11;
            var expected2 = new List<int> { 0, 2 };
            var actual2 = PairWithGivenSum(Input2, target2);
            if (actual2.Count == expected2.Count && actual2[0] == expected2[0])
            {
                Console.WriteLine($"found : [{string.Join(",", actual2)}]");
            }
            else
            {
                Console.WriteLine("Failed.");
            }
        }

        private static List<int> PairWithGivenSum(List<int> input1, int target1)
        {
            int si = 0;
            int ei = input1.Count - 1;
            while (si < ei)
            { int currentSum = input1[si] + input1[ei];
                if (currentSum == target1)
                {
                    return new List<int> { si, ei };
                }
                else if (currentSum < target1)
                {
                    si++;
                }
                else
                {
                    ei--;
                }
            }

            return new List<int>();
        }
    }
}
