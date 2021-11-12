using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.Pramp
{
    public static class CoinChangeProblem
    {
        public static void Tests()
        {
            int result = MinCoinsChangeMemo(new int[] { 5, 2, 3 }, 10);

            var result2 = MinCoinsChangeWithLimitedCoins(new int[] { 3, 2, 1 }, new int[] { 2, 2, 1 }, 5);
            Console.WriteLine($"actual : {result2}. Expected - 2");

            result2 = MinCoinsChangeWithLimitedCoins(new int[] { 3, 2, 1 }, new int[] { 2, 2, 1 }, 11);
            Console.WriteLine($"actual : {result2}. Expected - 5");

            result2 = MinCoinsChangeWithLimitedCoins(new int[] { 3, 10, 2, 1 }, new int[] { 1, 2, 2, 1 }, 11);
            Console.WriteLine($"actual : {result2}. Expected - 2");

            result2 = MinCoinsChangeWithLimitedCoins(new int[] { 3, 2, 1 }, new int[] { 2, 2, 1 }, 15);
            Console.WriteLine($"actual : {result2}. Expected - -1");

            result2 = MinCoinsChangeWithLimitedCoins(new int[] { 2, 137, 65, 35, 30, 9, 123, 81, 71 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 141);
            Console.WriteLine($"actual : {result2}. Expected - -1");

            var coins = MinCoinsChangeCoinsWithLimitedCoins(new int[] { 2, 137, 65, 35, 30, 9, 123, 81, 71 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 141);

            Console.WriteLine($"{string.Join(",", coins)}");
        }

        private static int MinCoinsChangeMemo(int[] coins, int sum)
        {
            var matrix = new int[coins.Length + 1, sum + 1];
            for (int row = 1; row <= coins.Length; row++)
            {
                int coin = coins[row - 1];
                for (int col = 1; col <= sum; col++)
                {
                    if (col < coin)
                    {
                        matrix[row, col] = matrix[row - 1, col];
                    }
                    else if (col == coin)
                    {
                        matrix[row, col] = 1;
                    }
                    else if (matrix[row, col - coin] > 0)
                    {
                        int option1 = 1 + matrix[row, col - coin];
                        int option2 = matrix[row - 1, col] != 0 ? matrix[row - 1, col] : option1;
                        matrix[row, col] = option1 <= option2 ? option1 : option2;
                    }
                    else
                    {
                        matrix[row, col] = matrix[row - 1, col];
                    }
                }
            }

            return matrix[coins.Length, sum] == 0 ? -1 : matrix[coins.Length, sum];
        }

        /*
        3   1  2
        2 , 1, 2

        5 
        0   1   2   3   4   5  
        ----------------------
        0   i   i   i   i   i
        0   i   i   1   i   i
        0   1   i   1   2   i
        0   1   1   1   2   2


        

         */
        private static int MinCoinsChangeWithLimitedCoins(int[] coins, int[] counts, int sum)
        {
            var dp = new int[sum + 1];
            Array.Fill(dp, int.MaxValue);
            dp[0] = 0;
            for (int i = 0; i < coins.Length; i++) // n
            {
                int coin = coins[i];
                for (int j = 0; j < counts[i]; j++) // 
                {
                    for (int s = sum; s >= coin ; s--) // sum
                    {
                        int remainder = s - coin;
                        if (remainder >= 0 && dp[remainder] != int.MaxValue)
                        {
                            dp[s] = Math.Min(1 + dp[remainder], dp[s]);
                        }
                    }
                }

            }
            
            return dp[sum] == int.MaxValue ? -1 : dp[sum];
        }

        private static int[] MinCoinsChangeCoinsWithLimitedCoins(int[] coins, int[] counts, int sum)
        {
            var list = new List<int>[sum + 1];
            list[0] = new List<int>();
            for (int i = 0; i < coins.Length; i++) // n
            {
                int coin = coins[i];
                for (int j = 0; j < counts[i]; j++) // 
                {
                    for (int s = sum; s >= coin; s--) // sum
                    {
                        int remainder = s - coin;
                        if (remainder >= 0 && list[remainder] != null)
                        {
                            if (list[s] == null || list[s].Count > 1 + list[remainder].Count)
                            {
                                var clone = list[remainder].ToArray<int>().ToList();
                                list[s] = clone;
                                list[s].Add(coin);
                            }
                            
                        }
                    }
                }

            }

            return list[sum] == null ? new int[0] : list[sum].ToArray();
        }
    }
}
