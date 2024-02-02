using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A121
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which program to run?");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Q1();
                    break;
                case "2":
                    Q2();
                    break;
            }
        }

        static void Q1()
        {
            string[,] arr = new string[4,4];
            Random rand = new Random();
            int pointerA = rand.Next(4);
            int pointerB = rand.Next(4);
            arr[pointerA, pointerB] = "X";

            Console.WriteLine("where is the X? [x, y]");
            int guessX = int.Parse(Console.ReadLine());
            int guessY = int.Parse(Console.ReadLine());
            if (guessX == pointerA && guessY == pointerB)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("L"); 
            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write((arr[i,j] == default) ? "| |" : $"|{arr[i, j]}|");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void Q2()
        {
            int[,] DisplayArray = new int[4, 4];
        }
    }
}
