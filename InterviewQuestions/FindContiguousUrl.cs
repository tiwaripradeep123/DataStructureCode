using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.InterviewQuestions
{
    public class FindContiguousUrl
    {
        public static void Tests()
        {
            var input1 = new string[] { "/start", "/green", "/blue", "/pink", "/register", "/orange", "/one/two" };
            var input2 = new string[] { "/start", "/pink", "/register", "/orange", "/red", "a" };
            var result1 = FindLongestSequence(input1, input2);
            foreach (var item in result1)
            {
                Console.Write(item + ",  ");
            }

            var resultLS = FindLargestSubscquence(input1, input2, 0, 0, new List<string>());
            Console.WriteLine("\nFrom LCS");
            foreach (var item in resultLS)
            {
                Console.Write(item + ",  ");
            }

            input1 = new string[] { "/pink", "/orange", "/yellow", "/plum", "/blue", "/tan", "/red", "/amber", "/HotRodPink", "/CornflowerBlue", "/LightGoldenRodYellow", "/BritishRacingGreen" };
             input2 = new string[] { "/pink", "/orange", "/amber", "/BritishRacingGreen", "/plum", "/blue", "/tan", "/red", "/lavender", "/HotRodPink", "/CornflowerBlue", "/LightGoldenRodYellow" };
             result1 = FindLongestSequence(input1, input2);
            foreach (var item in result1)
            {
                Console.Write(item + ",  ");
            }
            resultLS = FindLargestSubscquence(input1, input2, 0, 0, new List<string>());
            Console.WriteLine("\nFrom LCS");
            foreach (var item in resultLS)
            {
                Console.Write(item + ",  ");
            }
        }


        private static List<string> FindLargestSubscquence(string[] input1, string[] input2, int index1, int index2, List<string> result)
        {
            if (input1.Length == index1 || input2.Length == index2)
            {
                return result;
            }

            if (input1[index1] == input2[index2])
            {
                result.Add(input1[index1]);
                return FindLargestSubscquence(input1, input2, index1 + 1, index2 + 1, result);
            }
            else
            {
                var result1 = new List<string>(result.ToArray());
                var result2 = new List<string>(result.ToArray());
                var first = FindLargestSubscquence(input1, input2, index1, index2 + 1, result1);
                var second = FindLargestSubscquence(input1, input2, index1 + 1, index2, result2);
                return first.Count >= second.Count ? first : second;
            }
        }


        private static List<string> FindLargestSubscquenceBottomUp(string[] input1, string[] input2, int index1, int index2)
        {
            if (input1.Length == index1 -1 && input2.Length == index2 -1)
            {
                return input1[index1] == input2[index2] ? new List<string> { input1[index1] } : new List<string>();
            }

            return new List<string>();
        }

        private static List<string> FindLongestSequence(string[] input1, string[] input2)
        {
            var result = new List<string>();
            var matrix = new int[input1.Length + 1, input2.Length + 1];
            for (int i = 0; i < input1.Length; i++)
            {
                for (int j = 0; j < input2.Length; j++)
                {
                    int previousMax = Math.Max(matrix[i, j + 1], matrix[i + 1, j]);
                    matrix[i + 1, j + 1] = input1[i] == input2[j] ? 1 + previousMax : previousMax;
                }
            }

            HelperFunctions.PrintMatrix(matrix);

            int col = input2.Length;
            int row = 1;
            while (row < matrix.GetLength(0))
            {
                if (matrix[row - 1, col] != matrix[row, col])
                {
                    result.Add(input1[row-1]);
                }
                row++;
            }

            return result;
        }

    }
}
