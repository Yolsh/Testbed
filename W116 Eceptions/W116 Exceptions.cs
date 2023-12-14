using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W116_Eceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        static int[] getSides()
        {
            int[] sides = new int[2];
            do
            {
                Console.WriteLine("the two side values?");
                try
                {
                    sides[0] = parseSide(Console.ReadLine());
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine();
                }
            } while (sides.Length < 2);
        }

        static int parseSide(string side)
        {
            if (int.Parse(side) > sizeof(int))
            {
                throw new ArgumentOutOfRangeException();
            }
            int output = 0;
            output = int.Parse(side);
            return output;
        }
    }
}
