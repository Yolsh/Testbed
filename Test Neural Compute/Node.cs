using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Neural_Compute
{
    public class Node
    {
        public double weight;
        public double bias;
        public string ActivFunc;
        public Node(Random rand) 
        {
            weight = rand.NextDouble();
            bias = rand.NextDouble();
        }


    }
}
