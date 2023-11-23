using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace W110_Functions
{
    internal class Program
    {
        static double BinaryConvertDec(string binary)
        {
            int point = binary.IndexOf('.');
            double dec = 0;
            for(int i = point; i < binary.Length; i++)
            {
                if (binary[i] == '1')
                {
                    dec += Math.Pow(2, -1 * (i - point));
                }
            }
            Console.WriteLine(dec);
            return dec;
        }

        static double BinaryConvert(char[] binary, string binaryS)
        {
            double num = 0;
            if (binary.Contains('.'))
            {
                int wholeNum = binary.Length - binaryS.Reverse().ToString().IndexOf('.');
                if (binary[0] == '1') { num = -1 * Math.Pow(2, wholeNum); }
                Console.WriteLine(num);
                for (int i = 1; i < binaryS.IndexOf('.'); i++)
                {
                    if (binary[i] == '1')
                    {
                        num += Math.Pow(2, (-i + (wholeNum - 1)));
                    }
                }
                Console.WriteLine(num);
                num += BinaryConvertDec(binaryS);
            }
            else
            {
                if (binary[0] == '1') { num = -1 * Math.Pow(2, binary.Length - 1); }
                for (int i = 1; i < binary.Length; i++)
                {
                    if (binary[i] == '1')
                    {
                        num += Math.Pow(2, (-i + (binary.Length - 1)));
                    }
                }
            }
            return num;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("binary number: ");
            string input = Console.ReadLine();
            char[] binary = input.ToCharArray();
            Console.WriteLine(BinaryConvert(binary, input));
            Console.ReadKey();
        }
    }
}
