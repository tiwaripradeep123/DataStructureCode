using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.LeetCode
{
    public static class GridIlluminationClass
    {
        public static int[] GridIllumination(int n, int[][] lamps, int[][] queries)
        {
            var matrix = new int[n, n];
            PlaceLampsAndIlluminate(lamps, matrix, n);

            var result = new int[queries.GetLength(0)];
            for (int i = 0; i < queries.GetLength(0); i++)
            {
                int r = queries[i][0];
                int c = queries[i][1];
                result[i] = matrix[r, c] > 0 ? 1 : 0;
                TurnOfSurroundingLamps(matrix, r, c);
                Print(matrix);
            }

            return result;
        }

        public static void Print(int[,] matrix)
        {
            Console.WriteLine("----------------");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write($" {matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public static void PlaceLampsAndIlluminate(int[][] lamps, int[,] matrix, int n)
        {
            for (int i = 0; i < lamps.GetLength(0); i++)
            {
                int r = lamps[i][0];
                int c = lamps[i][1];
                IlluminateTheCell(matrix, r, c);
                Print(matrix);
            }
        }

        public static int GetKey(int r, int c)
        {
            return 100 * r + c;
        }

        public static int GetRow(int value)
        {
            return value / 100;
        }

        public static int GetColumn(int value)
        {
            return value % 100;
        }


        public static void TurnOfSurroundingLamps(int[,] matrix, int r, int c)
        {
            var nei = new List<int>();
            nei.Add(GetKey(r - 1, c - 1));
            nei.Add(GetKey(r - 1, c));
            nei.Add(GetKey(r - 1, c + 1));
            nei.Add(GetKey(r,     c - 1));
            nei.Add(GetKey(r,     c + 1));
            nei.Add(GetKey(r + 1, c - 1));
            nei.Add(GetKey(r + 1, c));
            nei.Add(GetKey(r + 1, c + 1));
            var removeList = new List<int>();
            foreach (var item in nei)
            {
                int r1 = GetRow(item);
                int c1 = GetColumn(item);
                int n = matrix.GetLength(0);
                if (r1 >= 0 && r1 < n && c1 >= 0 && c1 < n)
                {
                    if (matrix[r1, c1] >= 1000)
                    {
                        removeList.Add(GetKey(r1 - 1, c1 - 1));
                        removeList.Add(GetKey(r1 - 1, c1));
                        removeList.Add(GetKey(r1 - 1, c1 + 1));
                        removeList.Add(GetKey(r1, c1 - 1));
                        removeList.Add(GetKey(r1, c1 + 1));
                        removeList.Add(GetKey(r1 + 1, c1 - 1));
                        removeList.Add(GetKey(r1 + 1, c1));
                        removeList.Add(GetKey(r1 + 1, c1 + 1));
                    }
                }
            }

            foreach (var item in removeList)
            {
                if (nei.Contains(item))
                {
                    nei.Remove(item);
                }
            }

            foreach (var item in nei)
            {
                int r1 = GetRow(item);
                int c1 = GetColumn(item);
                int n = matrix.GetLength(0);
                if (r1 >= 0 && r1 < n && c1 >= 0 && c1 < n)
                {
                    if (matrix[r1, c1] >= 1000)
                    {
                        TurnOffTheCells(matrix, r1, c1);
                        matrix[r1, c1] -= 1000;
                    }
                    else
                    {
                        matrix[r1, c1] -= 1;
                    }
                }
            }
        }

        public static void TurnOffTheCells(int[,] input, int row, int col)
        {
            int tr = input.GetLength(0); // 4
            int tc = input.GetLength(1); // 4 
            if (input == null || tr <= row || tc <= col)
            {
                return;
            }
            for (int r = 0; r < tr; r++)
            {
                int x = Math.Abs(row - r);
                int lc = col - x;
                int rc = col + x;
                for (int c = 0; c < tc; c++)
                {
                    if ((r == row || c == col || lc == c || rc == c))
                    {
                        if (!(r == row && c == col))
                        {
                            input[r, c] -= 1;
                        }
                    }
                }
            }
        }

        public static void IlluminateTheCell(int[,] input, int row, int col)
        {
            int tr = input.GetLength(0); // 4
            int tc = input.GetLength(1); // 4 
            if (input == null || tr <= row || tc <= col)
            {
                return;
            }
            for (int r = 0; r < tr; r++)
            {
                int x = Math.Abs(row - r);
                int lc = col - x;
                int rc = col + x;
                for (int c = 0; c < tc; c++)
                {
                    if ((r == row || c == col || lc == c || rc == c))
                    {
                        if (r == row && c == col)
                        {
                            input[r, c] += 1000;
                        }
                        else
                        {
                            input[r, c] += 1;
                        }
                    }
                }
            }
        }

        public static void Tests()
        {
            int length = 5;
            var lamps = new int[3][] { new int[2] { 0, 0 }, new int[] { 0, 1 }, new int[] { 0, 4 } };
            var queries = new int[3][] { new int[2] { 0, 0 }, new int[2] { 0, 1 }, new int[2] { 0, 2 } };
            var result = GridIllumination(length, lamps, queries);
        }
    }
}
