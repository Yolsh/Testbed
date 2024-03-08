using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W131
{
    public class Human : Animal
    {
        private string name;

        public Human(string inName)
        {
            name = inName;
        }

        public override void Talk()
        {
            Console.WriteLine($"Hello my name is {name}");
        }
    }
}
