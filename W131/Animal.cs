using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W131
{
    public class Animal
    {
        public virtual void Talk()
        {
            Console.WriteLine("*Generic animal noise*");
        }

        public void Sit()
        {
            Console.WriteLine("*Sits on the floor*");
        }
    }
}
