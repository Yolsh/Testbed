using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W108
{
    internal class W108
    {
        static void oopsie(string[] list)
        {
            for (int i = list.Length; i > 0; i--)
            {
                Console.WriteLine(list[i]);
            } 
        }

        static void Main(string[] args)
        {
            Console.WriteLine("which program?");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    int[] num = new int[8];

                    for (int i = 0; i < num.Length; i++)
                    {
                        num[i] = 0;
                        Console.WriteLine(num[i]);
                    }
                    break;

                case 2:
                    string[] names = { "Joe", "James", "Jonathan", "James", "Joel" };

                    for (int i = 0; i < names.Length*2; i++)
                    {
                        (1 < 5) ? Console.WriteLine(names[i]) : oopsie(names);
                    }

                    break;
            }

            Console.ReadKey();
        }
    }
}
