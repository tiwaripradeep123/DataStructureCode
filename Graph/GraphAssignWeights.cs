using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.Graph
{
    //public class UndirectedGraphNVertices
    //{


    //    public class Graph
    //    {

    //        private int V;//No of vertices

    //        private LinkedList<Integer> adjlist[];//Adj list to keep track of edges

    //        //constructor

    //        Graph(int v)

    //        {

    //            V = v;

    //            adjlist = new LinkedList[v];

    //            for (int i = 0; i < v; ++i)

    //                adjlist[i] = new LinkedList();

    //        }

    //        // solution function

    //        public boolean solution(int N, int[] A, int[] B)

    //        {

    //            for (int i = 1; i < N; i++)

    //            {

    //                Iterator<Integer> it = adjlist[i].listIterator();

    //                int flag = 0;

    //                //iterating through all the adjacent vertices

    //                while (it.hasNext())

    //                {

    //                    int k = it.next();

    //                    //if we get the next vertex i.e. i+1

    //                    if (k == i + 1)

    //                    {

    //                        flag = 1;

    //                        break;

    //                    }

    //                }

    //                //if no adjacent vertex matches the next vertex

    //                if (flag == 0)

    //                    return false;

    //            }

    //            return true;

    //        }

    //        //Main function

    //        public static void main(String[] args)
    //        {

    //            int N, m;

    //            Scanner sc = new Scanner(System.in);

    //            N = sc.nextInt();

    //            m = sc.nextInt();

    //            int[] A = new int[m]; //first array

    //            int[] B = new int[m]; //second array

    //            for (int i = 0; i < m; i++)

    //                A[i] = sc.nextInt();

    //            for (int i = 0; i < m; i++)

    //                B[i] = sc.nextInt();

    //            Graph g = new Graph(N + 1); //Initializing graph

    //            for (int i = 0; i < m; i++)

    //            {

    //                //adding edges to the list of edges

    //                adjlist[A[i]].add(B[i]);

    //                adjlist[B[i]].add(A[i]);

    //            }

    //            boolean res = g.solution(N, A, B);

    //            if (res == true)

    //                System.out.println("It is possible");

    //        else

    //                System.out.println("Not possible");

    //        }

    //    }
    //}

    public static class GraphAssignWeights
    {

        public static void Tests()
        {
            var a = new int[] { 2, 2, 1, 2 };
            var b = new int[] { 1, 3, 4, 4 };

            int vertexCount = 5;

            var actual = CalculateGraphWeight(a, b, vertexCount);
            Console.WriteLine(actual);


             a = new int[] { 3};
             b = new int[] { 1 };

             vertexCount = 3;

             actual = CalculateGraphWeight(a, b, vertexCount);
            Console.WriteLine(actual);


             a = new int[] { 1, 1, 1, 1, 2, 2, 4 };
             b = new int[] { 2, 3, 4, 5, 3, 5, 5 };

            vertexCount = 5;

            actual = CalculateGraphWeight(a, b, vertexCount);
            Console.WriteLine(actual);

        }

        private static int CalculateGraphWeight(int[] a, int[] b, int vertexCount)
        {
            var matrix = new int[vertexCount +1, vertexCount+1];

            for (int i = 0; i < a.Length; i++)
            {
                int row = a[i];
                int col = b[i];
                matrix[row, col] = 1;
                matrix[col, row] = 1;

            }

            Print(matrix);
            var vertexDegree = new Dictionary<int, int>();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int count = 0;
                for (int c = 0; c < matrix.GetLength(0); c++)
                {
                    if (matrix[r,c] == 1)
                    {
                        count++;
                    }
                }

                vertexDegree.Add(r, count);
            }

            for (int i = 0; i < vertexDegree.Count; i++)
            {
                Console.WriteLine($"{vertexDegree.ElementAt(i).Key} has Degree {vertexDegree.ElementAt(i).Value}");
            }


            // 0 : 1
            // 1 : 3 
            var positionDict = new Dictionary<int, int>();
            int count1 = matrix.GetLength(0)-1;
            while (vertexDegree.Count > 0)
            {
                var max = vertexDegree.ElementAt(0);
                for (int i = 1;  i < vertexDegree.Count; i++)
                {
                    if (vertexDegree.ElementAt(i).Value > max.Value)
                    {
                        max = vertexDegree.ElementAt(i);
                    }
                }
                Console.WriteLine($"index {max.Key}, value : {count1}");
                positionDict.Add(max.Key, count1);
                count1--;
                vertexDegree.Remove(max.Key);
            }

            
            var total = 0;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(0); c++)
                {
                    if (matrix[r, c] == 1)
                    {
                        total += (positionDict[r] + positionDict[c]); 
                    }
                }
            }

            return total/2;
        }

        public static void Print(int[,] matrix)
        {

            Console.WriteLine();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write($" {matrix[i, j]} ");
                }
                Console.WriteLine();
            }


            Console.WriteLine();
        }
    }
}
