using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ConsoleApp
{
    public class Queue<T>
    {
        List<T> dataList = new List<T>();
        public void Push(T data)
        {
            dataList.Add(data);
        }

        public T Pop()
        {
            if (dataList.Count > 0)
            {
                var data = dataList[0];
                dataList.RemoveAt(0);
                return data;
            }

            return default(T);
        }

        public T Peek()
        {
            if (dataList.Count > 0)
            {
                return dataList[0];
            }

            return default(T);
        }
    }
}
