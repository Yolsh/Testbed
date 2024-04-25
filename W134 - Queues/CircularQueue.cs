using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W134___Queues
{
    public class CircularQueue<T> : IQueue<T>
    {
        private int MaxSize;
        private T[] Qarr;
        private int front;
        private int rear;
        private int Count;

        public CircularQueue(int inMaxSize) 
        {
            MaxSize = inMaxSize;
            Qarr = new T[MaxSize];
            front = 0;
            rear = -1;
            Count = 0;
        }

        public T DeQueue()
        {
            T ans = Qarr[front];
            front++;
            if (front == MaxSize) front = 0;
            Count--;
            return ans;
        }

        public bool EnQueue(T item)
        {
            if (!IsFull())
            {
                rear++;
                if (rear == MaxSize) rear = 0;
                Qarr[rear] = item;
                Count++;
                return true;
            }
            return false;
        }

        public bool IsEmpty()
        {
            if (Count == 0)
            {
                return true;
            }
            return false;
        }

        public bool IsFull()
        {
            if (Count == MaxSize)
            {
                return true;
            }
            return false;
        }
    }
}
