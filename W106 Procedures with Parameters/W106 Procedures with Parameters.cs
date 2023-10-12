using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W106_Procedures_with_Parameters
{
    internal class Program
    {
        static void MyAdd(int num1, int num2)
        {
            int result = num1 + num2;
            Console.WriteLine(result);
        }

        static void DisplaySymbols(int across, char UserSymbol, int down)
        {
            for (int i = 0; i < across; i++)
            {
                for (int j = 0; j < down; j++)
                {
                    Console.Write(UserSymbol);
                }
            }
        }

        static void DisplayMenu(string Scentence)
        {
            Console.WriteLine("1 - Display scentence");
            Console.WriteLine("2 - Display scentence in Cyan");
            Console.WriteLine("3 - Display scentence in Magenta");
            Console.WriteLine("4 - Display scentence in center of screen");
            string Choice = Console.ReadKey(true).KeyChar.ToString();

            switch (Choice)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                case "2":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;

                case "3":
                    Console.CursorLeft = (Console.WindowWidth - Scentence.Length) / 2;
                    break;
            }
            Console.WriteLine(Scentence);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("what Question?");
            int Prog_run = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (Prog_run)
            {
                case 1:
                    MyAdd(3, 5);
                    break;

                case 2:
                    DisplaySymbols(int.Parse(Console.ReadLine()), char.Parse(Console.ReadLine()));
                    break;

                case 3:
                    Console.WriteLine("Gimme Scentence");
                    DisplayMenu(Console.ReadLine());
                    break;

                case 4:

                    break;
            }

            Console.ReadKey();
        }
    }
}
