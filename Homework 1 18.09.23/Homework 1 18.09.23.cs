using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_18._09._23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("num1 = ");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("num2 = ");
            int num2 = int.Parse(Console.ReadLine());

            int ans_add = num1 + num2;
            int ans_mult = num1 * num2;
            int ans_fin = (ans_add + ans_mult);

            Console.WriteLine("the sum of those numbers is " + ans_fin);

            Console.ReadKey();

            //Console.WriteLine("width?");
            //int width = int.Parse(Console.ReadLine());

            //Console.WriteLine("height?");
            //int height = int.Parse(Console.ReadLine());

            //Console.WriteLine("cost of slab?");
            //string slab = Console.ReadLine().Replace("£", "");

            //double ans = (double) width * (double) height * double.Parse(slab);

            //Console.WriteLine("total cost: " + ans.ToString("C", CultureInfo.CurrentCulture));

            //Console.ReadKey();
        }
    }
}
