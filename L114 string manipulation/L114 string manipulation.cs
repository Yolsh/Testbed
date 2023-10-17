using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L114_string_manipulation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("input your first Name, your last name, the year you where born, your favourite colour, your street name and your shoe size.");
            Console.WriteLine(Console.ReadLine()[0].ToString().ToUpper() + Console.ReadLine()[1].ToString().ToUpper() + Console.ReadLine().Substring(2, 2) + Console.ReadLine().Substring(1, 2) + Console.ReadLine().Substring(1, 3) + Console.ReadLine()[0]);

            Console.ReadKey();
        }
    }
}
