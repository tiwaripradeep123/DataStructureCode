using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp._2021
{
    public class CoinChangeProblem2021
    {
        public static void Tests()
        {
            var input1 = new int[] {1,2,5 };
            var sum1 = 11;
            int expected1 = 3;
            int actual1 = GetMinCoinChange(input1, sum1);
            Console.WriteLine($"Expceted ={expected1}, Actual = {actual1}");


             input1 = new int[] { 1, 2, 5 };
             sum1 = 5;
             expected1 = 4;
             actual1 = GetWaysCoinChange(input1, sum1);
            Console.WriteLine($"Expceted ={expected1}, Actual = {actual1}");
        }

        private static int GetMinCoinChange(int[] coins, int sum)
        {
            var dp = new int[sum + 1];
            Array.Fill(dp, sum + 1);
            dp[0] = 0;
            foreach (var coin in coins)
            {
                for (int s = coin; s < dp.Length; s++)
                {
                    dp[s] = Math.Min(dp[s], 1 + dp[s - coin]);
                }
            }

            return dp[sum] == sum + 1 ? -1 : dp[sum];
        }


        private static int GetWaysCoinChange(int[] coins, int sum)
        {
            var dp = new int[sum + 1];
            dp[0] = 1;
            foreach (var coin in coins)
            {
                for (int s = coin; s < dp.Length; s++)
                {
                    if (dp[s - coin] != 0)
                    {
                        dp[s] += dp[s - coin];
                    }
                }
            }

            return dp[sum];
        }
    }
}
