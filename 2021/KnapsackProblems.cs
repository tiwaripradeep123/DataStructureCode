using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp._2021
{
    public static class KnapsackProblems
    {
        public static void Tests()
        {

            var input = new int[] { 2, 3, 7 };
            var partitionResult = SubSetWithGivenSum(input, 4);
            partitionResult = SubSetWithGivenSumTopDown(input, 4);


            input = new int[] { 1, 2, 3, 4 };
            partitionResult = CanPartitionIntoTwo(input);

            int[] weights = { 2,3,1,4 };
            int[] profits = { 4, 5, 3, 7 };
            int result =  GetMaxProfit(weights, profits, 5);
            var memo = new Dictionary<string, int>();

            var result2 = GetMaxProfitRecursion(memo, 0, 0, weights, profits, 5);
            result2 = GetMaxProfitButtonUp(weights, profits, 5);
            GetMaxProfitButtonUp1D(weights, profits, 5);
            weights = new int[] { 4, 5, 3, 7 };
            profits = new int[] { 1, 6, 10, 16 };

            result = GetMaxProfit(weights, profits, 7);

            result2 = GetMaxProfitRecursion(new Dictionary<string, int>(), 0, 0, weights, profits, 7);
            result2 = GetMaxProfitButtonUp(weights, profits, 7);
            GetMaxProfitButtonUp1D(weights, profits, 7);

        }

        private static bool SubSetWithGivenSumTopDown(int[] input, int sum)
        {
            var matrix = new bool[ sum + 1];
            matrix[0] = true;
            for (int r = 0; r < input.Length ; r++)
            {
                int value = input[r];
                for (int c = sum; c >= value; c--)
                {
                    if (matrix[c - value])
                    {
                        matrix[c] = true;
                    }
                }
            }

            return matrix[sum];
        }

        private static bool SubSetWithGivenSum(int[] input, int sum, int index= 0)
        {
            if (index == input.Length)
            {
                return sum == 0;
            }
            if (sum == 0)
            {
                return true;
            } else if (sum < 0)
            {
                return false;
            }
            return SubSetWithGivenSum(input, sum, index + 1) || SubSetWithGivenSum(input, sum - input[index], index + 1);
        }

        private static bool CanPartitionIntoTwo(int[] input)
        {
            var result1 = CanPartitionIntoTwoRecursion(0, 0, 0, input);
            Console.WriteLine($"{result1} -> [{string.Join(",", input)}]");
            return result1;
        }

        private static bool CanPartitionIntoTwoRecursion(int index, int sum1, int sum2, int[] input)
        {
            if (index == input.Length)
            {
                return sum1 == sum2;
            }

            return CanPartitionIntoTwoRecursion(index + 1, sum1 + input[index], sum2, input)
                || CanPartitionIntoTwoRecursion(index + 1, sum1, sum2 + input[index], input);
        }

        private static int GetMaxProfitButtonUp1D(int[] weights, int[] profits, int capcity)
        {
            var result = new int[capcity + 1];
            for (int i = 0; i < weights.Length; i++)
            {
                int weight = weights[i];
                int profit = profits[i];
                for (int j = capcity; j >= weight; j--)
                {
                    if (j - weight != weight)
                    {
                        result[j] = Math.Max(result[j], profit + result[j - weight]);
                    }
                    else {
                        result[j] = Math.Max(result[j], profit);
                    }
                }

            }
            Console.WriteLine($"1D -> {result[capcity]}");
            return result[capcity];
        }

            private static int GetMaxProfitButtonUp(int[] weights, int[] profits, int capcity)
        {
            int[,] matrix = new int[weights.Length + 1, capcity +1];
            for (int r = 1; r <= weights.Length; r++)
            {
                int weight = weights[r - 1];
                int profit = profits[r - 1];
                for (int c = 1; c <= capcity; c++)
                {
                    if (c - weight >= 0)
                    {
                        int prevValue = Math.Max(matrix[r - 1, c], matrix[r, c - 1]);
                        int current = profit + matrix[r -1, c - weight];
                        matrix[r,c] = Math.Max(prevValue, current);
                    }
                    else {
                        matrix[r, c] = Math.Max(matrix[r - 1, c], matrix[r, c - 1]);
                    }

                }
            }

            for (int r1 = 0; r1 <= weights.Length; r1++)
            {
                for (int c = 0; c <= capcity; c++)
                {
                    Console.Write($" {matrix[r1, c] } "); 
                }
                Console.WriteLine();
            }

            Console.WriteLine(matrix[weights.Length, capcity].ToString());

            int remainingCapacity = capcity ;
            var result = new int[weights.Length];
            int index = 0;
            int row = weights.Length; 
            while (remainingCapacity > 0 && row > 0)
            {
                while (matrix[row, remainingCapacity] == matrix[row - 1, remainingCapacity] && row > 0)
                {
                    row--;
                }
                result[index++] = weights[row-1];
                remainingCapacity = remainingCapacity - weights[row-1];
            }

            while (--index >= 0)
            {
                Console.Write($" { result[index]}, ");
            }

            return matrix[weights.Length, capcity];
        }

        public static int GetMaxProfitRecursion(Dictionary<string, int> memo,  int index, int profit, int[] weights, int[] profits, int capacity)
        {
            if (index == profits.Length)
            {
                return profit;
            }
            else
            {
                var key = $"{index}-{capacity}";
                if (!memo.ContainsKey(key))
                {
                    int newProfit = capacity - weights[index] >= 0 ? profit + profits[index] : profit;
                    memo[key] = Math.Max(GetMaxProfitRecursion(memo, index + 1, profit, weights, profits, capacity),
                        GetMaxProfitRecursion(memo, index + 1, newProfit, weights, profits, capacity - weights[index]));
                }
                else {
                    Console.WriteLine($"contains key {key}");
                }
                return memo[key];
            }
        }


        public static  int GetMaxProfit(int[] weights, int[] profits, int capacity)
        {
            int maxProfit = 0;
            var outputs = new List<int[]>();
            for (int i = 0; i < weights.Length; i++)
            {
                int count = outputs.Count;
                var result1 = new int[weights.Length];
                result1[i] = 1;
                outputs.Add(result1);
                maxProfit = Math.Max(maxProfit, GetMaxProfit(result1, profits));
                for (int j = 0; j < count; j++)
                {
                    var result = new int[weights.Length];
                    outputs[j].CopyTo(result, 0);
                    result[i] = 1;
                    if (IsValidCombo(result, weights, capacity))
                    {
                        maxProfit = Math.Max(maxProfit, GetMaxProfit(result, profits));
                        outputs.Add(result);
                    }
                }
            }

            foreach (var item in outputs)
            {
                Console.WriteLine($"[{string.Join(", ", item)}]");
            }

            Console.WriteLine($"Max proft {maxProfit}");
            return maxProfit;
        }

        private static int GetMaxProfit(int[] item, int[] profits)
        {
            int profit = 0;
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i] == 1)
                {
                    profit += profits[i];
                }
            }

            return profit;
        }

        private static bool IsValidCombo(int[] item, int[] weights, int capacity)
        {
            int weight = 0;
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i] == 1)
                {
                    weight += weights[i]; 
                }
            }

            return weight <= capacity;
        }

        private static void Print(int i, int j,int[] weights, int[] profits, int capacity)
        {
            string str = "[";
            for (int c = j; c < j + i; c++)
            {
                str += weights[c].ToString() + " ,";
            }
            str += "]";
            Console.WriteLine(str);
        }
    }
}
