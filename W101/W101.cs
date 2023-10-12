using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W101
{
    internal class W101
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give me a number");
            int Num_1 = int.Parse(Console.ReadLine());

            if (Num_1 >= 1 && Num_1 <= 100)
            {
                Console.WriteLine("Number is between 1 and 100");
            }
            else if (Num_1 < 1)
            {
                Console.WriteLine("your number is too small");
            }
            else
            {
                Console.WriteLine("Your number is to big");
            }

            Console.ReadKey();
        }
    }
}
