using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L116_Debugging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0; double num2 = 1;
            double result = 0.0;
            string exp, op, choice;
            bool again = false;

            while (again)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the calculator program");
                Console.WriteLine("Enter a maths expression (e.g. 5+6)");

                exp = Console.ReadLine();

                num1 = int.Parse(exp.Substring(0, 1));
                num2 = double.Parse(exp.Substring(2, 1));
                op = exp.Substring(2, 3);

                switch (exp)
                {
                    case "+":
                        result = num2 + num1;
                        break;
                    case "-":
                        result = num2 - num1;
                        break;
                    case "/":
                        result = num1 / num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                }

                Console.WriteLine(exp + "=" + result);

                Console.WriteLine("Would you like to go again? [Y/N]");
                choice = Console.ReadKey().Key.ToString();
                

                if (choice.ToUpper() != "Y")
                {
                    again = true;
                }
                else
                {
                    again = false;
                }
            }

            Console.WriteLine("Goodbye. Press any key to terminate the program");
            Console.ReadKey();
        }

    }
}
