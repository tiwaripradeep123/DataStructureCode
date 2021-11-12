using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.Graph
{

    public class GraphAlgo
    {

        public static void Tests()
        {
            var g = new GraphAdj();
            g.AddEdge("0", "1", 4);
            g.AddEdge("0", "7", 4);
            g.AddEdge("1", "2", 8);
            g.AddEdge("1", "7", 11);
            g.AddEdge("2", "8", 2);
            g.AddEdge("2", "5", 4);
            g.AddEdge("2", "3", 7);
            g.AddEdge("3", "4", 9);
            g.AddEdge("3", "5", 14);
            g.AddEdge("4", "5", 10);
            g.AddEdge("5", "6", 2);
            g.AddEdge("6", "7", 1);
            g.AddEdge("6", "8", 6);
            g.AddEdge("7", "8", 7);

            var result = PerformPrismAlgo.PrismMSTAlgo(g.AdjList);
            var totalCost = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != i.ToString())
                {
                    foreach (var kv in g.AdjList[i.ToString()])
                    {
                        if (kv.Key == result[i])
                        {
                            totalCost += kv.Value;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("\n total cost " + totalCost + " final -> " + string.Join(", ", result));

            
            var resultDijstra = PerformDijstraAlgo.DijstraMSTAlgo(g.AdjList);
            
            Console.WriteLine("\n Dijstra final -> " + string.Join(", ", resultDijstra));
        }
    }

    public class GraphAdj
    {
        public int NodeCount
        {
            get
            {
                return AdjList.Count;
            }
        }

        public Dictionary<string, List<KeyValuePair<string, int>>> AdjList = null;
        
        public GraphAdj(): this(0, null)
        { 
            
        }

        public GraphAdj(int count, Dictionary<string, List<KeyValuePair<string, int>>> list)
        {
            AdjList = list == null ? new Dictionary<string, List<KeyValuePair<string, int>>>() : list;
        }

        public void AddEdge(string src, string dest, int weight, bool isDirected = false)
        {
            if (!AdjList.ContainsKey(src))
            {
                AdjList.Add(src, new List<KeyValuePair<string, int>>());
            }
            if (!AdjList.ContainsKey(dest))
            {
                AdjList.Add(dest, new List<KeyValuePair<string, int>>());
            }

            if (!AdjList[src].Any(x => x.Key == dest))
            {
                AdjList[src].Add(new KeyValuePair<string, int>(dest, weight));
            }

            if ((!isDirected) && !AdjList[dest].Any(x => x.Key == src))
            {
                AdjList[dest].Add(new KeyValuePair<string, int>(src, weight));
            }
        }
    }


    public class PerformDijstraAlgo
    {
        public static int[] DijstraMSTAlgo(Dictionary<string, List<KeyValuePair<string, int>>> graph)
        {
            var nodeCount = graph.Count;
            var costs = new int[nodeCount];
            Array.Fill(costs, int.MaxValue);
            costs[0] = 0;

            var parent = new string[nodeCount];
            Array.Fill(parent, "-");
            parent[0] = "0";
            var visited = new bool[nodeCount];
            int index = nodeCount;
            int minIndex = 0;
            while (minIndex >= 0)
            {
                visited[minIndex] = true;
                foreach (var item in graph[minIndex.ToString()])
                {
                    var keyIndex = int.Parse(item.Key);
                    if (costs[keyIndex] > (costs[minIndex] + item.Value))
                    {
                        costs[keyIndex] = (costs[minIndex] + item.Value);
                        parent[keyIndex] = minIndex.ToString();
                    }
                }
                minIndex = GetMinIndex(costs, visited);
                Console.WriteLine(string.Join(", ", parent));
            }

            return costs;
        }

        public static int GetMinIndex(int[] input, bool[] visited)
        {
            int index = -1;
            for (int i = 0; i < input.Length; i++)
            {
                if (!visited[i] && (index == -1 || input[i] < input[index]))
                {
                    index = i;
                }
            }

            return index;
        }
    }

    public class PerformPrismAlgo
    {
        public static string[] PrismMSTAlgo(Dictionary<string, List<KeyValuePair<string, int>>> graph)
        {
            var nodeCount = graph.Count;
            var cost = new int[nodeCount];
            Array.Fill(cost, int.MaxValue);
            cost[0] = 0;
            
            var parent = new string[nodeCount];
            Array.Fill(parent, "-");
            parent[0] = "0";
            var visited = new bool[nodeCount];
            int index = nodeCount;
            while (--index >= 0)
            {
                int minIndex = GetMinIndex(cost, visited);
                visited[minIndex] = true;
                foreach (var item in graph[minIndex.ToString()])
                {
                    var keyIndex = int.Parse(item.Key);
                    if (!visited[keyIndex])
                    {
                        if (cost[keyIndex] > item.Value)
                        {
                            cost[keyIndex] = item.Value;
                            parent[keyIndex] = minIndex.ToString();
                        }
                    }
                }

                Console.WriteLine(string.Join(", ", parent));
            }


            return parent;
        }

        public static int GetMinIndex(int[] input, bool[] visited)
        {
            int index = -1;
            for (int i = 0; i < input.Length; i++)
            {
                if (!visited[i] && (index == -1 || input[i] < input[index]))
                {
                        index = i;
                }
            }

            return index;
        }
    }
}
