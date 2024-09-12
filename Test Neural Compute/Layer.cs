using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Neural_Compute
{
    public class Layer
    {
        Node[] layer;
        public Layer(int size, Random rand)
        {
            layer = new Node[size];
            for (int i = 0; i < size; i++)
            {
                layer[i] = new Node(rand);
            }
        }
    }
}
