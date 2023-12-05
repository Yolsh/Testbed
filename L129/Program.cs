using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L129
{
    internal class Program
    {
        static void Add(ref int answer, int num1, int num2)
        {
            answer = num1 + num2;
        }

        static bool Divide (ref int answer, int num1, int num2)
        { 
            if (num1 == 0 || num2 == 0) { return false; }
            answer = num1 / num2;
            return true;
        }

        static void Main(string[] args)
        {
            int answer = 0;
            Add(ref answer, 3, 9);
            Divide(ref answer, 9, 0);
            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
