using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.LeetCode
{
    public static class SudokuSolver
    {
        public static void Tests()
        {
            Console.WriteLine("Hello, world!");
            var board = new char[][]{
                new char[]{'5','3','.','.','7','.','.','.','.'},
                new char[]{'6','.','.','1','9','5','.','.','.'},
                new char[]{'.','9','8','.','.','.','.','6','.'},
                new char[]{'8','.','.','.','6','.','.','.','3'},
                new char[]{'4','.','.','8','.','3','.','.','1'},
                new char[]{'7','.','.','.','2','.','.','.','6'},
                new char[]{'.','6','.','.','.','.','2','8','.'},
                new char[]{'.','.','.','4','1','9','.','.','5'},
                new char[]{'.','.','.','.','8','.','.','7','9'}};
            SolveSudoku(board);

            var result = BuildSudolu();
        }

        private static List<char[][]> BuildSudolu()
        {
            var result = new List<char[][]>();
            for (int i = 1; i < 10; i++)
            {
                var board = new char[][] { new char[9]{'.','.','.','.','.','.','.','.','.'},
                                      new char[9]{'.','.','.','.','.','.','.','.','.'},
                                      new char[9]{'.','.','.','.','.','.','.','.','.'},
                                      new char[9]{'.','.','.','.','.','.','.','.','.'},
                                      new char[9]{'.','.','.','.','.','.','.','.','.'},
                                      new char[9]{'.','.','.','.','.','.','.','.','.'},
                                      new char[9]{'.','.','.','.','.','.','.','.','.'},
                                      new char[9]{'.','.','.','.','.','.','.','.','.'},
                                      new char[9]{'.','.','.','.','.','.','.','.','.'}
                                      };
                board[0][0] = (Char)(i.ToString())[0];
                SolveSudoku(board);
                result.Add(board);
            }

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine($"Printing {i}");
                Print(result[i]);
            }

            return result;
        }

        public static void SolveSudoku(char[][] board)
        {
            Print(board);
            int n = board.GetLength(0);
            SolveSudokuRecursive(board, n, 0, 0);
            Print(board);
        }

        public static void Print(char[][] board)
        {
            Console.WriteLine("-------------------------");
            int n = board.GetLength(0);
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write($" {board[r][c]} ");
                }
                Console.WriteLine();
            }
        }

        public static bool SolveSudokuRecursive(char[][] board, int n, int row, int col)
        {
            if (row == n)
            {
                return true;
            }
            int newCol = col + 1 == n ? 0 : col + 1;
            int newRow = col + 1 == n ? row + 1 : row;
            if (board[row][col] == '.')
            {
                var allowedNumbers = GetAllowedNumbers(board, row, col);
                Console.WriteLine($"[{row}, {col}] -> [{string.Join(",", allowedNumbers)}]");
                for (int index = 0; index < allowedNumbers.Count; index++)
                {
                    var val = (Char)(allowedNumbers[index].ToString())[0];
                    board[row][col] = val;
                    Print(board);
                    bool status = SolveSudokuRecursive(board, n, newRow, newCol);
                    if (status)
                    {
                        return true;
                    }
                }
            }
            else
            {
                return SolveSudokuRecursive(board, n, newRow, newCol);
            }
            board[row][col] = '.';
            return false;
        }

        public static List<int> GetAllowedNumbers(char[][] board, int row, int col)
        {
            int n = board.GetLength(0);
            var result = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int c = 0; c < n; c++)
            {
                if (board[row][c] != '.')
                {
                    var value = int.Parse(board[row][c].ToString());
                    if (result.Contains(value))
                    {
                        result.Remove(value);
                    }

                }
            }

            for (int r = 0; r < n; r++)
            {
                if (board[r][col] != '.')
                {
                    var value = int.Parse(board[r][col].ToString());
                    if (result.Contains(value))
                    {
                        result.Remove(value);
                    }


                }
            }

            int rStart = 3 * (row / 3);
            int cStart = 3 * (col / 3);

            for (int r = rStart; r < rStart + 3; r++)
            {
                for (int c = cStart; c < cStart + 3; c++)
                {
                    if (board[r][c] != '.')
                    {
                        var thisChar = board[r][c];
                        var value = int.Parse(thisChar.ToString());
                        if (result.Contains(value))
                        {
                            result.Remove(value);
                        }

                    }
                }
            }

            return result;
        }
    }
}
