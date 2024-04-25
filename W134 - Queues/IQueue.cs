using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W134___Queues
{
    public interface IQueue<T>
    {
        bool EnQueue(T item);
        T DeQueue();
        bool IsFull();
        bool IsEmpty();
    }
}
