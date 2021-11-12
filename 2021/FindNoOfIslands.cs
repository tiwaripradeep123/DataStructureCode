using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp._2021
{
    public class FindNoOfIslands
    {
        public static int CalculateIslands(int[,] input, int row = 0, int col = 0, int count = 0)
        {
            if (row == input.GetLength(0))
            {
                return count;
            }

            if (col == input.GetLength(1))
            {
                return CalculateIslands(input, row+1, 0, count);
            }

            if (input[row, col] == 1)
            {
                count+=1;
                ShortCells(input, row, col);
            }

            return CalculateIslands(input, row, col+1, count);
        }



        public static void ShortCells(int[,] input, int row, int col)
        {
            if (col < 0 || col >= input.GetLength(1) || row < 0 || row >= input.GetLength(1) || input[row, col] == 0)
            {
                return;
            }
            input[row, col] = 0;
            ShortCells(input, row, col - 1);
            ShortCells(input, row - 1, col);
            ShortCells(input, row, col + 1);
            ShortCells(input, row + 1, col);

        }


        public static void Tests()
        {
            var input = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        input[i, j] = 1;
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    Console.Write($" {input[i, j]} ");

                }
                Console.WriteLine();
            }

            var noOfIsland = CalculateIslands(input);
            Console.WriteLine("Hello, World! noOfIsland -> " + noOfIsland);
        }
    }
}
