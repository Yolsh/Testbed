using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W135___Adjacency_Lists
{
    public class MyBartonException : Exception
    {
        public MyBartonException() : base(){ }
        public MyBartonException(string message) : base(message) { }
    }
}
