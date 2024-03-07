using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W127
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle MyCircle = new Circle();
            Console.WriteLine("Enter a Radius");
            MyCircle.setRadius(int.Parse(Console.ReadLine()));
            Console.WriteLine($"The Radius = {MyCircle.getRadius()}");
            Console.WriteLine($"The Area = {MyCircle.getArea()}");
            Console.WriteLine($"The Circumference = {MyCircle.getCircumference()}");
            Console.ReadKey();
        }
    }
}
