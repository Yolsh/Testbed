using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W103_For_Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("what program would you like to run?");
            int Prog_run = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (Prog_run)
            {
                case 0:
                    Console.WriteLine("what would you like to write?");
                    string input = Console.ReadLine();

                    Console.WriteLine("how many time?");
                    int Num = int.Parse(Console.ReadLine());

                    for (int i = 0; i < Num; i++)
                    {
                        Console.WriteLine(input);
                    }
                    break;

                case 1:
                    for (double i = 0; i < 5.5; i += (double)1 / 2)
                    {
                        Console.Write(i * i + (i == 10 ? "." : ","));
                    }
                    break;

                case 2:
                    for (int i = 1; i < 11; i++)
                    {
                        Console.Write(i * i + (i == 10 ? "." : ","));
                    }

                    break;

                case 3:
                    for (int i = 1; i < 11; i++)
                    {
                        Console.Write(Math.Pow(2, i) + (i == 10 ? "." : ","));
                    }

                    break;

                case 4:
                    for (int i = 1; i < 11; i++)
                    {
                        Console.Write(Math.Pow(16, i) + (i == 10 ? "." : ","));
                    }

                    break;

                case 5:
                    for

                    break;


                default:
                    Console.WriteLine("no such program");
                    break;
            }

            Console.ReadKey();
        }
    }
}
