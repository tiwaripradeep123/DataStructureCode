using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Graph
{
    public class CheapestFlightWithKStops
    {
        public static void Tests()
        {
            /*
              4
                [[0,1,1],[0,2,5],[1,2,1],[2,3,1]]
                0
                3
                1
             */
            var graph = new CheapestFlightWithKStops();
            var input = new int[][]  { new int[] { 0, 1, 1 }, new int[]{ 0, 2, 5 }, new int[] { 1, 2, 1 }, new int[] { 2, 3, 1 } } ;
           var result =  graph.FindCheapestPrice(8,input, 0, 3, 1 );
            Console.WriteLine($"Cost {result} ");
        }
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            var flightsg = new FlightGraph(flights, n);
            return flightsg.FindCheapestPrice(src, dst, k);
        }

        public class Node
        {
            public int Cost;
            public int NodeIndex;
            

            public Node(int nodeIndex, int cost)
            {
                Cost = cost;
                NodeIndex = nodeIndex;
            }
        }

        public class NodeWithStop : Node
        {
            public int Stops;

            public NodeWithStop(int nodeIndex, int cost, int stops) : base(nodeIndex, cost)
            {
                Stops = stops;
            }
        }
        public class FlightGraph
        {
            int Count = -1;
            public Dictionary<int, List<Node>> Nodes = new Dictionary<int, List<Node>>();

            public FlightGraph(int[][] flights, int count)
            {
                Count = count;
                for (int i = 0; i < flights.GetLength(0); i++)
                {
                    var data = flights[i];
                    if (!Nodes.ContainsKey(data[0]))
                    {
                        Nodes.Add(data[0], new List<Node>());
                    }

                    Nodes[data[0]].Add(new Node(data[1], data[2]));
                }
            }


            public int FindCheapestPrice(int source, int dest, int stops)
            {
                return FindCheapestPriceRecursive(source, dest, 0, stops);
            }

            public int FindCheapestPriceRecursive(int source, int dest, int routeCost, int stops)
            {
                if (source == dest)
                {
                    return routeCost;
                }
                if (stops < 0)
                {
                    return -1;
                }
                int cost = -1;
                if (Nodes.ContainsKey(source))
                {
                    foreach (var departure in Nodes[source])
                    {
                        var newCost = FindCheapestPriceRecursive(departure.NodeIndex, dest, routeCost + departure.Cost, stops - 1);
                        if (newCost != -1)
                        {
                            cost = cost == -1 ? newCost : Math.Min(cost, newCost);
                        }
                    }
                }
                return cost;
            }

            public int FindCheapestPriceDigkstra(int source, int dest, int stops)
            {
                var costs = new int[Count];
                Array.Fill(costs, int.MaxValue);
                costs[source] = 0;
                
                return costs[dest] == int.MaxValue ? -1 : costs[dest];
            }
        }
    }


}
