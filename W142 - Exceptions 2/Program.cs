using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W142___Exceptions_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new SaveFileException("Hello", "MyFile.txt");
            }
            catch (SaveFileException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            bool cont = true;
            do
            {
                Console.WriteLine("give 2 Numbers");
                int A = int.Parse(Console.ReadLine());
                int B = int.Parse(Console.ReadLine());
                try
                {
                    Division(A, B);
                }
                catch (DivisionException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Press any key to end the Program");
                    while (!Console.KeyAvailable)
                    {
                        Console.Write(".");
                        System.Threading.Thread.Sleep(1000);
                    }
                    cont = false;
                }
            } while (cont);
        }

        static double Division(int A, int B)
        {
            if (B == 0) throw new DivisionException(A);
            return A / B;
        }
    }
}
