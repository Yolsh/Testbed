using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W134___Queues
{
    public class LinearShuffleQueue<T> : IQueue<T>
    {
        private T[] Qarr;
        private int rear;

        public LinearShuffleQueue(int Size) 
        {
            Qarr = new T[Size];
            rear = -1;
        }

        public T DeQueue()
        {
            T ans = Qarr[0];
            for (int i = 1; i < Qarr.Length; i++)
            {
                Qarr[i-1] = Qarr[i];
            }
            rear--;
            return ans;
        }

        public bool EnQueue(T item)
        {
            rear++;
            if (!IsFull())
            {
                return false;
            }
            Qarr[rear] = item;
            return true;
        }

        public bool IsEmpty()
        {
            if (rear == -1)
            {
                return true;
            }
            return false;
        }

        public bool IsFull()
        {
            if (rear == Qarr.Length)
            {
                return true;
            }
            return false;
        }
    }
}
