using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.InterviewQuestions
{
    public class KPrimeNumbersSum
    {

        // contain all prime numbers, guaranteed to be less than or eq to int n (below)
        private static List<int> ALL_PRIMES = new List<int>();


        // Returns true, if there exists exactly k prime numbers that sum up to n
        // sumPrime(7, 2) -> [2, 3, 5, 7] -> (2, 5) sums up to 7
        // sumPrime(5, 2) -> true, because there exists exactly 2 prime numbers (2, 3) that sums up to 5
        // sumPrime(2, 1) -> true, because there exists exactly 1 prime numbers (2) that sums up to 2
        // false otherwise
        /*
            first input -n -> 2...n , 
             Add all those prim numbers  
            if sum of all those is == n

            sumPrime(9, 3)
          ALL_PRIMES = [2, 3, 5, 7]   , k = 2, n = 7
        */

        //n -> 2*2^n => 2^n

        public static bool SumPrimeRecursive(List<int> ALL_PRIMES, int index, int remSum, int count)
        {
            if (remSum < 0 || ALL_PRIMES.Count <= index)
            {
                return false;
            }
            else if (count == 0)
            {
                return remSum == 0;
            }
            else
            {
                return SumPrimeRecursive(ALL_PRIMES, index + 1, remSum, count) || SumPrimeRecursive(ALL_PRIMES, index + 1, remSum - ALL_PRIMES[index], count - 1);
            }
        }
        public static bool sumPrime(List<int> ALL_PRIMES, int sum, int noOfElements)
        {
            return SumPrimeRecursive(ALL_PRIMES, 1, sum, noOfElements) || SumPrimeRecursive(ALL_PRIMES, 1, sum - ALL_PRIMES[0], noOfElements - 1);
        }

        internal static void Tests()
        {
            var input1 = new List<int> { 2, 3, 5, 7 };
            var sum1 = 7;
            var k = 2;
            var result1 = sumPrime(input1, sum1, k);
            Console.WriteLine(string.Join(" ", input1) + $" k={2} sum = {sum1} result = {result1}");

            input1 = new List<int> { 2, 3, 5, 7 };
            sum1 = 6;
            k = 2;
            result1 = sumPrime(input1, sum1, k);
            Console.WriteLine(string.Join(" ", input1) + $" k={2} sum = {sum1} result = {result1}");
        }
    }
}
