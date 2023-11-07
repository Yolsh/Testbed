using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W106_Lists
{
    internal class Program
    {
        static Random rnd = new Random();

        static void Print_list<T>(List<T> list)
        {
            Console.Write("[");
            for (int i = 0; i < list.Count(); i++)
            {
                Console.Write((i == list.Count() - 1) ? list[i].ToString() : list[i].ToString() + ", ");
            }
            Console.Write("]");
        }

        static T[] listArray<T>(List<T> List)
        {
            T[] array = new T[List.Count];

            for (int i = 0; i < List.Count(); i++)
            {
                array[i] = List[i];
            }
            return array;
        }

        static bool exist<T>(List<T> List, T obj)
        {
            bool exist = false;
            for(int i = 0; i < List.Count(); i++)
            {
                if (obj.ToString() == List[i].ToString())
                {
                    exist = true;
                }
            }
            return exist;
        } 

        static void Main(string[] args)
        {
            Console.WriteLine("what program to run?");
            int prog_run;
            do
            {
                prog_run = int.Parse(Console.ReadLine());
                switch (prog_run)
                {
                    case 1:
                        List<int> myList = new List<int>();

                        for (int i = 0; i < 5; i++)
                        {
                            myList.Add(rnd.Next());
                        }
                        Print_list(myList);
                        break;
                    case 3:
                        List<string> names = new List<string>();
                        for (int i = 1; i < 6; i++)
                        {
                            Console.WriteLine("input name " + i + " :");
                            string name = Console.ReadLine();
                            if (!exist(names, name))
                            {
                                names.Add(name);
                            }
                            else
                            {
                                Console.WriteLine("they are already in the list");
                            }
                        }
                        Print_list(names);
                        break;

                    case 4:
                        Console.Write("write the words with a space inbetween : ");
                        string ingredients = Console.ReadLine();

                        break;
                }
            } while (prog_run != 1 && prog_run != 4 && prog_run != 3);
            Console.ReadKey();
        }
    }
}
