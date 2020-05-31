using System.Collections.Generic;

namespace ConsoleAppPractice
{
    class Stack
    {
        List<int> data = new List<int>();
        public void Push(int value)
        {
            data.Insert(0, value);
        }

        public void Pop()
        {
            if (data.Count > 0)
            {
                data.RemoveAt(0);

            }
        }

        public int GetMax()
        {
            if (data.Count == 0)
            {
                return -1;
            }

            int value = data[0];
            for (int i = 1; i < data.Count; i++)
            {
                if (value < data[i])
                {
                    value = data[i];
                }
            }

            return value;
        }
    }

}
