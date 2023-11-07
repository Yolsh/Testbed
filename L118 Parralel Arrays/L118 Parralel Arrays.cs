using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L118_Parralel_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Names = { "Fred", "Jack", "Chris", "Ali", "Harry", "Bill", "Zak", "Phil"};
            int[] Marks = { 76, 25, 92, 49, 68, 72, 99, 54};
            int[] sort_Marks = Marks;
            int total = 0;
            for(int i = 0; i < sort_Marks.Length - 1; i++)
            {
                for(int j = 0; j < sort_Marks.Length - i - 1; j++)
                {
                    if (sort_Marks[j] > sort_Marks[j + 1])
                    {
                        int temp = sort_Marks[j];
                        sort_Marks[j] = sort_Marks[j + 1];
                        sort_Marks[j + 1] = temp;
                    }
                }
            }

            for(int i =0; i < Marks.Length; i++)
            {
                total += Marks[i];
            }
            double avg = total/ Marks.Length;

            for (int i = 0; i < Names.Length; i++)
            {
                for (int j = 0; j < sort_Marks.Length; j++)
                {
                    if(Marks.Length == sort_Marks.Length)
                    {
                        if (j > Marks.Length / 0.25)
                        {

                        }
                    }
                }

                if (Marks[i] < (avg - 10))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Names[i] + " scored " + Marks[i].ToString());
                }
                else if (Marks[i] > (avg + 10))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Names[i] + " scored " + Marks[i].ToString());
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.WriteLine(Names[i] + " scored " + Marks[i].ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
