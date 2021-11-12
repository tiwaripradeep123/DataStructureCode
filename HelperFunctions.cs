using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public static class HelperFunctions
    {
        public static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($" {matrix[i,j]} ");
                }
            }
        }
    }
}
