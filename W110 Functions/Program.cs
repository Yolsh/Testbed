using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W110_Functions
{
    internal class Program
    {
        static int addTwo(int num1, int num2) => num1 + num2;
        static double BinaryConvert(char[] binary)
        {
            double num = 0;
            if (binary[7] == '1') { num = -128; }
            for (int i = 1; i < binary.Length; i++)
            {
                if (binary[i] == '1')
                {
                    num += Math.Pow(2, (-i+6));
                }
            }
            return num;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("binary number: ");
            char[] binary = Console.ReadLine().ToCharArray();
            Console.WriteLine(BinaryConvert(binary));
        }
    }
}
