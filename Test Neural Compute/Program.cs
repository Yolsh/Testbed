using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Test_Neural_Compute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BMPConv ImgObj = new BMPConv("T-Rex.bmp");
            Net NeuralNet = new Net(1, 10);
            ImgObj.ImgToBArr();
        }
    }
}
