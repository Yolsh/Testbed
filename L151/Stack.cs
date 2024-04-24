using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L151
{
    public class MyStack<T>
    {
        private T[] stack;
        private int currentSize;
        public MyStack(int size) 
        {
            stack = new T[size];
            currentSize = 0;
        }

        public T Peek()
        {
            return stack[0];
        }

        public T Pop()
        {
            T removed = stack[0];
            for (int i = 0; i < currentSize; i++) stack[i] = stack[i + 1];
            currentSize--;
            return removed;
        }

        public void Push(T item) 
        {
            currentSize++;
            T prev = stack[0];
            T next;
            for (int i = 0; i < currentSize; i++) 
            {
                next = stack[i + 1];
                stack[i + 1] = prev;
                prev = next;
            }
            stack[0] = item;
        }

        public bool IsEmpty()
        {
            for (int i = 0; i < currentSize; i++)
            {
                if (stack[i] != null)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsFull()
        {
            for (int i = 0; i < currentSize; i++)
            {
                if (stack[i] == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
