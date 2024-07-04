using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W142___Exceptions_2
{
    public class DivisionException : DivideByZeroException
    {
        public DivisionException(int A) : base($"you attempted to divide {A} by 0") { }
    }
}
