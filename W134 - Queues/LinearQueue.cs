using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W134___Queues
{
    public class LinearQueue<T> : IQueue<T>
    {
        private T[] Qarr;
        private int front;
        private int rear;

        public LinearQueue(int maxSize) 
        {
            Qarr = new T[maxSize];
            front = 0;
            rear = -1;
        }

        public T DeQueue()
        {
            front++;
            return Qarr[front-1];
        }

        public bool EnQueue(T item)
        {
            rear++;
            if (!IsFull())
            {
                Qarr[rear] = item;
                return true;
            }
            return false;
        }

        public bool IsEmpty()
        {
            if (rear == front-1)
            {
                return true;
            }
            return false;
        }

        public bool IsFull()
        {
            if (rear + front == Qarr.Length)
            {
                return true;
            }
            return false;
        }
    }
}
