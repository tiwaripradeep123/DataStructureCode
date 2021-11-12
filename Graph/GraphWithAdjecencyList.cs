using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.Graph
{

    public class GraphWithAdjecencyListTest
    {
        public static void Tests()
        {
            var edges1 = new List<KeyValuePair<string, string>>();
            edges1.Add(new KeyValuePair<string, string>("a", "b"));
            edges1.Add(new KeyValuePair<string, string>("a", "c"));
            edges1.Add(new KeyValuePair<string, string>("b", "d"));
            edges1.Add(new KeyValuePair<string, string>("e", "f"));
            edges1.Add(new KeyValuePair<string, string>("f", "c"));
            edges1.Add(new KeyValuePair<string, string>("k", "m"));
            edges1.Add(new KeyValuePair<string, string>("k", "n"));
            edges1.Add(new KeyValuePair<string, string>("L", "W"));


            var graph = new GraphWithAdjecencyList();
            graph.CreateAdjencyList(edges1);
            graph.Print();
            graph.PrintMatrix();
            Console.WriteLine($"Path between a - f {graph.IsPath("a", "f", new HashSet<string>())}");
            Console.WriteLine($"Path between a - k {graph.IsPath("a", "k", new HashSet<string>())}");

            Console.WriteLine($"Total islands {graph.CountIslands()}");
            Console.WriteLine($"Islands [{string.Join(",", graph.IslandsSize())}]");
        }
    }
    public class GraphWithAdjecencyList
    {
        public Dictionary<string, List<string>> AdjList { get; private set; } = new Dictionary<string, List<string>>();
        
        public void CreateAdjencyList(List<KeyValuePair<string, string>> edges)
        {
            foreach (var item in edges)
            {
                if (!AdjList.ContainsKey(item.Key))
                {
                    AdjList.Add(item.Key, new List<string>());
                }
                if (!AdjList.ContainsKey(item.Value))
                {
                    AdjList.Add(item.Value, new List<string>());
                }

                AdjList[item.Key].Add(item.Value);
                AdjList[item.Value].Add(item.Key);
            }
        }

        public void Print()
        {
            Console.WriteLine();
            var itr = AdjList.GetEnumerator();
            while (itr.MoveNext())
            {
                Console.Write($"[{itr.Current.Key}] -> ");
                foreach (var item in itr.Current.Value)
                {
                    Console.Write($" {item} , ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void PrintMatrix()
        {
            List<string> list = GetNodesList();
            var matrix = new int[list.Count, list.Count];

            var itr = AdjList.GetEnumerator();
            while (itr.MoveNext())
            {
                var row = list.IndexOf(itr.Current.Key);
                foreach (var item in itr.Current.Value)
                {
                    var col = list.IndexOf(item);
                    matrix[row, col] = 1;
                }

            }
            Console.WriteLine();
            Console.WriteLine($"{string.Join(" , ", list.ToArray())}");
            for (int row = 0; row < list.Count; row++)
            {
                for (int col = 0; col < list.Count; col++)
                {
                    Console.Write($" {matrix[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private List<string> GetNodesList()
        {
            return AdjList.Keys.ToArray().ToList();
        }

        public bool IsPath(string src, string dest, HashSet<string> visited)
        {
            
            if (src == dest)
            {
                return true;
            }
            if (visited.Contains(src))
            {
                return false;
            }
            visited.Add(src);
            foreach (var item in AdjList[src])
            {
                if (IsPath(item, dest, visited))
                {
                    return true;
                }
            }

            return false;
        }

        public int CountIslands()
        {
            var nodes = GetNodesList();
            var visited = new HashSet<string>();
            int count = 0;
            foreach (var node in nodes )
            {
                if (!visited.Contains(node))
                {
                    count++;
                    ExploreAllConnectedNodes(node, visited);
                }
            }

            return count;
        }

        public List<int> IslandsSize()
        {
            var nodes = GetNodesList();
            var visited = new HashSet<string>();
            List<int> sizes = new List<int>();
            foreach (var node in nodes)
            {
                if (!visited.Contains(node))
                {
                    sizes.Add(CountonnectedNodes(node, visited));
                }
            }

            return sizes;
        }

        private int CountonnectedNodes(string node, HashSet<string> visited)
        {
            var queue = new Queue<string>();
            queue.Enqueue(node);
            int count = 0;
            while (queue.Count > 0)
            {
                count++;
                var current = queue.Dequeue();
                visited.Add(current);
                foreach (var item in AdjList[current])
                {
                    if (!visited.Contains(item))
                    {
                        queue.Enqueue(item);
                    }
                }
            }

            return count;
        }

        private void ExploreAllConnectedNodes(string node, HashSet<string> visited)
        {
            if (visited.Contains(node))
            {
                return;
            }
            visited.Add(node);
            foreach (var item in AdjList[node])
            {
                ExploreAllConnectedNodes(item, visited);
            }
        }
    }
}
