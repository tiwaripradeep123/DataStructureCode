using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.InterviewQuestions
{
    
    public class CalculateFCDistances
    {

        /*
        XXX has multiple fulfillment centers across the US. Each fulfillment center is represented by coordinates on the map.
        Design an algorithm that takes a list of FC coordinates and returns a matrix where each element represents location on 
        the map and contains a distance to the closest fulfillment center. 
        For simplicity, assume that only vertical and horizontal moves are allowed on the map.

        Example input: 
            map size 4x6
            fulfillment centers locations (0 based) - (1,2), (3,3)  K (n*M)

           int.max 0 0 0 0 0
           0 0 0 0 0 0
           0 0 0 0 0 0
           0 0 0 0 0 0

           0. Take an FC (fcRow, fcCol)
           1. for each row, col - row, col 
           2. calculate distanse based on to points
           3. check if this distance is lesser than current assigned FC distance - update it 
           4. repeat this for all FCs in the list. 


        Output:
            3 2 1 2 3 4
            2 1 0 1 2 3 
            3 2 1 1 2 3
            3 2 1 0 1 2
        */
        public static int[,] InitMatrixWithMaxDistance(int rows, int cols)
        {
            var input = new int[rows, cols];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                {
                    input[r, c] = int.MaxValue;
                }

            return input;
        }


        // o(m*n) + o(k*n*m) = o(k*n*m) 
        // o(m*n)
        public static int[,] PopulateFCDistance(int rows, int cols, List<KeyValuePair<int, int>> fcList)
        {
            var input = InitMatrixWithMaxDistance(rows, cols);
            foreach (var item in fcList) // K
            {
                int fcRow = item.Key;
                int fcCol = item.Value;
                for (int r = 0; r < rows; r++) // n 
                {
                    for (int c = 0; c < cols; c++) // m 
                    {
                        int distance = Math.Abs(r - fcRow) + Math.Abs(c - fcCol);
                        if (input[r, c] > distance)
                        {
                            input[r, c] = distance;
                        }
                    }
                }
            }

            return input;
        }
        public static void Tests()
        {
            var fcList = new List<KeyValuePair<int, int>>();
            fcList.Add(new KeyValuePair<int, int>(1, 2));
            fcList.Add(new KeyValuePair<int, int>(3,3));
            var output = PopulateFCDistance(4, 6, fcList);

            for (int r = 0; r < 4; r++) // n 
            {
                for (int c = 0; c < 6; c++) // m 
                {
                    Console.Write($" {output[r,c]} ");
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

}
