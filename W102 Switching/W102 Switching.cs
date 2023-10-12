using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W102_Switching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What code should I run?");
            string Prog_run = Console.ReadLine();
            Console.Clear();

            switch (Prog_run)
            {
                Console.WriteLine("enter a number between 0 and 5");
            int Num1 = int.Parse(Console.ReadLine());

            switch (Num1)
            {
                case 0:
                    Console.WriteLine("zero");
                    break;
                case 1:
                    Console.WriteLine("one");
                    break;
                case 2:
                    Console.WriteLine("two");
                    break;
                case 3:
                    Console.WriteLine("three");
                    break;
                case 4:
                    Console.WriteLine("four");
                    break;
                case 5:
                    Console.WriteLine("five");
                    break;
                default:
                    Console.WriteLine("an invalid number was entered");
                    break;
            } //need to fix the outer switch menu system for programs.

            Console.WriteLine("");
        }
    }
}
