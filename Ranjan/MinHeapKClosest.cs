using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.Ranjan
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $" [{X}, {Y}] ";
        }
    }

    public class MinHeapKClosestTests
    {
        public static void Tests()
        {
            for (int cnt = 0; cnt < 5; cnt++)
            {
                var origin = new Point(cnt, cnt);
                var heap = new MinHeapKClosest<int>();
                var random = new Random();
                for (int i = 0; i < 100; i++)
                {
                    var data = random.Next(0, 200);
                    heap.Push(new KeyValuePair<int, int>(data, data));
                }


                Console.WriteLine($"Reference point [{origin.ToString()}]");
                int k = 90;
                while (k-- > 0 && heap.Count > 0)
                {
                    var current = heap.Pop();
                    bool isValid = heap.IsValid();
                    if (!isValid)
                    {
                        Console.WriteLine($"invalid heap");
                    }
                    Console.WriteLine($" {current.Key} -> {current.Value.ToString()}");
                }

                //Console.ReadLine();
            }



            for (int cnt = 0; cnt < 5; cnt++)
            {
                var origin = new Point(cnt, cnt);
                var heap = new MinHeapKClosest<Point>();
                var random = new Random();
                for (int i = 0; i < 20; i++)
                {
                    var point = new Point(random.Next(-10, 10), random.Next(-10, 10));
                    var key = Math.Abs(point.X - origin.X) + Math.Abs(point.Y - origin.Y);
                    heap.Push(new KeyValuePair<int, Point>(key, point));
                }

               
                Console.WriteLine($"Reference point [{origin.ToString()}]");
                int k = 19;
                while (k-- > 0 && heap.Count > 0)
                {
                    var current = heap.Pop();
                    bool isValid = heap.IsValid();
                    if (!isValid)
                    {
                        Console.WriteLine($"invalid heap");
                    }
                    Console.WriteLine($" {current.Key} -> {current.Value.ToString()}");
                }

                Console.ReadLine();
            }
        }
    }

    public class MinHeapKClosest<T>
    {
        public List<KeyValuePair<int, T>> Data { get; set; } = new List<KeyValuePair<int, T>>();

        public void Push(KeyValuePair<int, T> data)
        {
            int index = this.Data.Count;
            this.Data.Add(data);
            HeapifyUp(index);
        }

        public int Count { 
            get 
            { 
                return Data.Count; 
            } 
        }

        public KeyValuePair<int, T> Peek()
        {
            return Data[0];
        }

        public KeyValuePair<int, T> Pop()
        {
            var data = Data[0];
            Data[0] = Data[Data.Count - 1];
            Data.RemoveAt(Data.Count - 1);
            var before = Data.Select(x => x.Key).ToArray();
            HeapifyDown(0);
            var after = Data.Select(x => x.Key).ToArray();
            if (!IsValid())
            {
                Console.WriteLine("Failed to heapify down properly");
            }
            return data;
        }

        private void HeapifyUp(int index)
        {
            if (index >= 1)
            {
                int parent = Parent(index);
                var left = Left(parent);
                var right = Right(parent);
                var minIndex = right != -1 && Data[right].Key < Data[left].Key ? right : left;
                if (Data[parent].Key > Data[minIndex].Key)
                {
                    Swap(parent, minIndex);
                    HeapifyDown(minIndex);
                }

                HeapifyUp(left - 1);
            }
        }

        private void HeapifyDown(int parent)
        {
            var left = Left(parent);
            var right = Right(parent);
            if (left != -1)
            {
                int minIndex = right != -1 && Data[right].Key < Data[left].Key ? right : left;
                if (Data[parent].Key > Data[minIndex].Key)
                {
                    Swap(minIndex, parent);
                    HeapifyDown(minIndex);
                }
            }
        }

        private void Swap(int index1, int index2)
        {
            var temp = Data[index1];
            Data[index1] = Data[index2];
            Data[index2] = temp;
        }

        public int Parent(int index)
        {
            return (index - 1) / 2;
        }

        public int Left(int index)
        {
            var left = 2 * index + 1;
            return left < Data.Count ? left : -1; ;
        }

        public int Right(int index)
        {
            var right = 2 * index + 2;
            return right < Data.Count ? right : -1; ;
        }

        internal bool IsValid()
        {
            int index = Count;
            while (index-- > 0 )
            {
                var parent = Parent(index);
                var pk = Data[parent].Key;
                var ck = Data[index].Key;
                if (pk > ck)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
