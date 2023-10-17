using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L111_Subroutines
{
    internal class Program
    {
        static void PersonQ()
        {
            string name;
            string colour;

            void GetName()
            {
                Console.WriteLine("What is your name?");
                name = Console.ReadLine();
            }

            void GetColour()
            {
                Console.WriteLine("What is your favourite colour?");
                colour = Console.ReadLine();
            }

            void GetAge()
            {
                bool test = true;
                Console.WriteLine("How old are you?");
                int age = int.Parse(Console.ReadLine());
                do
                {
                    GetColour();
                    switch (colour)
                    {
                        case "Red":
                            Console.ForegroundColor = ConsoleColor.Red;
                            test = true;
                            break;

                        case "Green":
                            Console.ForegroundColor = ConsoleColor.Green;
                            test = true;
                            break;

                        case "Blue":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            test = true;
                            break;

                        default:
                            Console.WriteLine("That is an invalid colour. Try again.");
                            test = false;
                            break;
                    }
                } while (test != true);
                Console.WriteLine("Hi " + name + " you are " + age + " years old.");
            }

            void Main(string[] args)
            {
                GetName();
                GetAge();
                Console.ReadKey();
            }
        }

        static void Statistics()
        {
            int Num1;
            int Num2;
            int Num3;
            int Num4;

            void total()
            {
                int totals = Num1 + Num2 + Num3 + Num4;
                Console.WriteLine("the total of those is " + totals);
            }

            void Average()
            {
                Console.WriteLine("What average would you like?");
                string Type = Console.ReadLine();

                switch (Type)
                {
                    case "Mean":
                        int Mean = (Num1 + Num2 + Num3 + Num4) / 4;
                        Console.WriteLine("the Average of those is " + Mean);
                        break;

                    case "Median":
                        //Console.WriteLine("the Average of those is " + Median);
                        break;
                }
            }

            void Main(string[] args)
            {
                Console.WriteLine("Number?");
                Num1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Number?");
                Num2 = int.Parse(Console.ReadLine());

                Console.WriteLine("Number?");
                Num3 = int.Parse(Console.ReadLine());

                Console.WriteLine("Number?");
                Num4 = int.Parse(Console.ReadLine());

                total();
                Average();
            }
        }

        static void Menu()
        {
            void RedText()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Done");
            }

            void Times_Table()
            {
                for (int i = 0; i < 11; i++)
                {
                    Console.WriteLine(i * 2);
                }
            }

            void Fact()
            {
                Console.WriteLine("2 + 2 = 4");
            }


            Console.WriteLine("1 - Red Text");
            Console.WriteLine("2 - Times_Table");
            Console.WriteLine("3 - Fact");
            Console.WriteLine("4 - Quit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RedText();
                    break;

                case 2:
                    Times_Table();
                    break;

                case 3:
                    Fact();
                    break;
                case 4:
                    break;
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Which program?");
            int Prog_run = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (Prog_run)
            {
                case 0:
                    PersonQ();
                    break;

                case 1:
                    Statistics();
                    break;
                case 2:
                    Menu();
                    break;
            }
        }
    }
}
