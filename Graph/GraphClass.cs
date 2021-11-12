using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Graph
{

    
    public class Cell
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }
        public int Row { get; set; }
        public int Column { get; set; }
    }

    public class GraphClass
    {
        const int Infinity = 999; 
        public int[,] AdjesencyMatrix { get; set; }

        public GraphClass()
        {
            
        }

        public void Tests()
        {
            /*
             A -> [B, C, D]
             B -> [C, D]
             C -> [D, E]
             D -> [E]
             E -> []
             F -> [A,D]
             */
            AdjesencyMatrix = new int[,] {
                { 0 , 15, 6 , 20, 0, 0 },
                { 0 , 0 , 12, 6 , 0, 0},
                { 0 , 0, 0 , 15, 7, 0 },
                { 0 , 0 , 0, 0 , 3, 0},
                { 0 , 0 , 0 , 0 , 0, 0},
                { 1 , 0 , 0 , 1 , 0, 0}
            };

            var result = DijkstrasAlgo(0);
            Console.WriteLine($" Distance from 0 => [{string.Join(",", result)}]");

            //for (int i = 0; i < AdjesencyMatrix.GetLength(0) ; i++)
            //{
            //    var mstParent = CreatePrismMST(i);
            //    PrintMst(mstParent);
            //    Console.WriteLine("CreatePrismMSTPradeep");
            //    mstParent = CreatePrismMSTPradeep(i);
            //    PrintMst(mstParent);
            //}

            var resultDFS = GraphDFS(AdjesencyMatrix);
            foreach (var item in resultDFS)
            {
                Console.Write($"{item} -> ");
            }
            Console.WriteLine();
            var resultBFS = GraphBFS(AdjesencyMatrix);
            foreach (var item in resultBFS)
            {
                Console.Write($"{item} -> ");
            }
            Console.WriteLine();

            var visited = new bool[AdjesencyMatrix.GetLength(0)];
            var resultDFSRecursive = new List<char>();
            for (int i = 0; i < visited.Length; i++)
            {
                if (!visited[i])
                {
                    resultDFSRecursive = GraphDFSRecusrsive(AdjesencyMatrix, visited, i, resultDFSRecursive);
                }
            }
            foreach (var item in resultDFSRecursive)
            {
                Console.Write($"{item} -> ");
            }

            Console.WriteLine();
            var nodes = "ABCDEF";
            var index1 = 0;
            var index2 = 4;
           Console.WriteLine($"Path between {nodes[index1]} - {nodes[index2]} -> {HasPathBetweenTwoNodesDFS(AdjesencyMatrix, index1, index2)}");
            Console.WriteLine();
            index1 = 0;
            index2 = 5;
            Console.WriteLine($"Path between {nodes[index1]} - {nodes[index2]} -> {HasPathBetweenTwoNodesDFS(AdjesencyMatrix, index1, index2)}");


             index1 = 0;
             index2 = 4;
            Console.WriteLine($"Path between {nodes[index1]} - {nodes[index2]} -> {HasPathBetweenTwoNodesBFS(AdjesencyMatrix, index1, index2)}");
            Console.WriteLine();
            index1 = 0;
            index2 = 5;
            Console.WriteLine($"Path between {nodes[index1]} - {nodes[index2]} -> {HasPathBetweenTwoNodesBFS(AdjesencyMatrix, index1, index2)}");

           

            TopologicalSort();
            
        }

        private bool HasPathBetweenTwoNodesDFS(int[,] matrix, int index1, int index2)
        {
            var visited = new bool[matrix.GetLength(0)];
            var stack = new Stack<int>();
            stack.Push(index1);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (current == index2)
                {
                    return true;
                }
                visited[current] = true;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[current, i] > 0 && (!visited[i]))
                    {
                        stack.Push(i);
                    }
                }
            }


            return false;
        }

        private bool HasPathBetweenTwoNodesBFS(int[,] matrix, int index1, int index2)
        {
            var visited = new bool[matrix.GetLength(0)];
            var queue = new Queue<int>();
            queue.Enqueue(index1);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current == index2)
                {
                    return true;
                }
                visited[current] = true;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[current, i] > 0 && (!visited[i]))
                    {
                        queue.Enqueue(i);
                    }
                }
            }


            return false;
        }


        private List<char> GraphDFSRecusrsive(int[,] matrix, bool[] visited, int index, List<char> result)
        {
            if (result == null)
            {
                result = new List<char>();
            }

            var nodes = "ABCDEF";
            result.Add(nodes[index]);
            visited[index] = true;
            for (int i = 0; i < visited.Length; i++)
            {
                if (!visited[i] && matrix[index, i] > 0)
                {
                    GraphDFSRecusrsive(matrix, visited, i, result);
                }
            }

            return result;
        }

        private List<char> GraphDFS(int[,] matrix)
        {
            var unvisitedNodes = new List<int> { 0, 1, 2, 3, 4, 5 };
            var result = new List<char>();
            var nodes = "ABCDEF";
            var stack = new Stack<int>();
            while (stack.Count > 0 || unvisitedNodes.Count > 0)
            {
                if (stack.Count == 0)
                {
                    stack.Push(unvisitedNodes[0]);
                }
                int current = stack.Pop();
                if (unvisitedNodes.Contains(current))
                {
                    result.Add(nodes[current]);
                    unvisitedNodes.Remove(current);
                }
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    if (matrix[current, col] > 0 && unvisitedNodes.Contains(col))
                    {
                        stack.Push(col);
                    }
                }
            }

            return result;
        }

        private List<char> GraphBFS(int[,] matrix)
        {
            var visitedNodes = new bool[matrix.GetLength(0)];
            var result = new List<char>();
            var nodes = "ABCDEF";
            var queue = new Queue<int>();
            for (int i = 0; i < visitedNodes.Length; i++)
            {
                if (!visitedNodes[i])
                {
                    queue.Enqueue(i);
                    while (queue.Count > 0)
                    {
                        int current = queue.Dequeue();
                        if (!visitedNodes[current])
                        {
                            result.Add(nodes[current]);
                            visitedNodes[current] = true;
                        }
                        for (int col = 0; col < matrix.GetLength(0); col++)
                        {
                            if (matrix[current, col] > 0 && (!visitedNodes[col]))
                            {
                                queue.Enqueue(col);
                            }
                        }
                    }
                }
            }
            

            return result;
        }

        public void TopologicalSort()
        {
            var matrix = new int[,] {
                { 0 , 15, 6 , 20, 0, 0 },
                { 0 , 0 , 12, 6 , 0, 0},
                { 0 , 0, 0 , 15, 7, 0 },
                { 0 , 0 , 0, 0 , 3, 0},
                { 0 , 0 , 0 , 0 , 0, 0},
                { 1 , 0 , 0 , 1 , 0, 0},
            };

            
            var nodeCount = matrix.GetLength(0);
            var result = new Stack<string>();
            var visited = new bool[nodeCount];
            for (int index = 0; index < nodeCount; index++)
            {
                if (!visited[index])
                {
                    TopologicalSortUtil(index, visited, result, matrix);
                }
            }

            foreach (var item in result)
            {
                Console.Write($" {item} ");
            }
        }

        private void TopologicalSortUtil(int row, bool[] visited, Stack<string> result, int[,] matrix)
        {
            string nodes = "ABCDEF";
            visited[row] = true;
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                if (!visited[col] && matrix[row, col] != 0)
                {
                    TopologicalSortUtil(col, visited, result, matrix);
                }
            }
            result.Push(nodes[row].ToString());

        }

        private void PrintMst(int[] mstParent)
        {
            string chars = "ABCDEF";
            Console.WriteLine($"Print mst");
            int sum = 0;
            for (int i = 0; i < mstParent.Length; i++)
            {
                sum += AdjesencyMatrix[i, mstParent[i]];
                Console.WriteLine($"{chars[mstParent[i]]} - {chars[i]} => {AdjesencyMatrix[i, mstParent[i]]}");
            }

            Console.WriteLine($"Done! Total sum {sum}");
        }

        private int[] CreatePrismMST(int startIndex)
        {
            var vertexCount = AdjesencyMatrix.GetLength(0);
            int[] parent = new int[vertexCount];
            var result = new int[vertexCount];
            Array.Fill(result, int.MaxValue);
            var mstSet = new bool[vertexCount];
            result[startIndex] = 0;
            parent[startIndex] = startIndex;
            for (int i = 0; i < vertexCount -1; i++)
            {
                int minIndex = MinIndex(result, mstSet);
                mstSet[minIndex] = true;
                for (int c = 0; c < vertexCount; c++)
                {
                    if (AdjesencyMatrix[minIndex, c] >0 && mstSet[c] == false && result[c] > AdjesencyMatrix[minIndex, c])
                    {
                        parent[c] = minIndex;
                        result[c] = AdjesencyMatrix[minIndex, c];
                    }
                }
            }

            return parent;
        }

        private int MinIndex(int[] result, bool[] mstSet)
        {
            int minIndex = -1;
            for (int i = 0; i < result.Length; i++)
            {
                if (!mstSet[i] && result[i] != int.MaxValue)
                {
                    if (minIndex == -1 || result[minIndex] > result[i])
                    {
                        minIndex = i;
                    }
                }
            }
            return minIndex;
        }

        public int[] CreatePrismMSTPradeep(int startIndex)
        {
            int vertexCount = AdjesencyMatrix.GetLength(0);
            var edges = new int[vertexCount];
            var selectedNodes = new bool[vertexCount];
            var costs = new int[vertexCount];
            Array.Fill(costs, int.MaxValue);
            edges[startIndex] = startIndex;
            costs[startIndex] = 0;
            int nodeCounts = vertexCount;
            while (--nodeCounts >= 0)
            {
                var minIndex = MinIndex(costs, selectedNodes);
                selectedNodes[minIndex] = true;
                for (int col = 0; col < vertexCount; col++)
                {
                    if (AdjesencyMatrix[minIndex, col] != 0 && selectedNodes[col] == false && costs[col] > AdjesencyMatrix[minIndex, col])
                    {
                        edges[col] = minIndex;
                        costs[col] = AdjesencyMatrix[minIndex, col];
                    }
                }
            }
            return edges;
        }

        private static Cell FindMin(int[,] matrix, bool[] selected)
        {
            Cell result = null;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (!selected[i])
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (!selected[j] && matrix[i,j] != -1)
                        {
                            if (result == null || matrix[result.Row, result.Column] > matrix[i,j])
                            {
                                result = new Cell(i, j);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public int[,] Create2DArrayWithDefault(int len, int val = -1)
        {
            var matrix = new int[len, len];
            InitMatrix(val, matrix);
            return matrix;
        }

        private static void InitMatrix(int val, int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = val;
                }
            }

        }


        public KeyValuePair<int, int> GetMinimumNode(List<KeyValuePair<int, int>> edges)
        {
            return new KeyValuePair<int, int>();
        }

        private int[] DijkstrasAlgo(int index)
        {
            string nodes = "ABCDEF";
            HashSet<int> unvisited = new HashSet<int>() { 0, 1, 2, 3, 4 };
            Queue<KeyValuePair<int, int>> pq = new Queue<KeyValuePair<int, int>>();
            pq.Enqueue(new KeyValuePair<int, int>(index, 0));
            var distances = new int[AdjesencyMatrix.GetLength(0)];
            Array.Fill(distances, int.MaxValue);
            distances[index] = 0;
            while (pq.Count > 0)
            {
                var data = pq.Dequeue();
                unvisited.Remove(data.Key);
                Console.WriteLine($"Travensing node {nodes[data.Key]}");
                for (int i = 0; i < distances.Length; i++)
                {
                    int weight = AdjesencyMatrix[data.Key, i];
                    if (weight != 0 && unvisited.Contains(i) && distances[i] > (weight + data.Value))
                    {
                        distances[i] = weight + data.Value;
                        Console.WriteLine($"Choosing {nodes[data.Key]} to {nodes[i]} -> {distances[i]}");
                        pq.Enqueue(new KeyValuePair<int, int>(i, distances[i]));
                    }
                } 
            }

            return distances;
        }
        private int[] DijkstrasAlgoOld(int index)
        {
            string nodes = "ABCDEF";
            HashSet<int> unvisited = new HashSet<int>() { 0, 1, 2, 3, 4 };
            Queue<KeyValuePair<int, int>> pq = new Queue<KeyValuePair<int, int>>();
            pq.Enqueue(new KeyValuePair<int, int>(index, 0));
            var distances = new int[AdjesencyMatrix.GetLength(0)];
            Array.Fill(distances, int.MaxValue);
            distances[index] = 0;
            while (pq.Count > 0)
            {
                var data = pq.Dequeue();
                unvisited.Remove(data.Key);
                Console.WriteLine($"Travensing node {nodes[data.Key]}");
                for (int i = 0; i < distances.Length; i++)
                {
                    int weight = AdjesencyMatrix[data.Key, i];
                    if (weight != 0 && unvisited.Contains(i) && distances[i] > (weight + data.Value))
                    {
                        distances[i] = weight + data.Value;
                        Console.WriteLine($"Choosing {nodes[data.Key]} to {nodes[i]} -> {distances[i]}");
                        pq.Enqueue(new KeyValuePair<int, int>(i, distances[i]));
                    }
                }
            }

            return distances;
        }
    }
}
