using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W110_Functions
{
    internal class Program
    {
        static double BinaryConvert(char[] binary)
        {
            double num = 0;
            if (binary[0] == '1') { num = -128; }
            for (int i = 1; i < binary.Length; i++)
            {
                if (binary[i] == '1')
                {
                    num += Math.Pow(2, (-i+7));
                }
            }
            return num;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("binary number: ");
            char[] binary = Console.ReadLine().ToCharArray();
            Console.WriteLine(BinaryConvert(binary));
            Console.ReadKey();
        }
    }
}
