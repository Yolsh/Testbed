using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W128
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cuboid MyBox = new Cuboid(10, 10, 10);
            Console.WriteLine($"Length = {MyBox.getLength()}");
            Console.WriteLine($"Height = {MyBox.getHeight()}");
            Console.WriteLine($"Width = {MyBox.getWidth()}");
            Console.WriteLine($"Surface Area = {MyBox.calculateSurfaceArea()}");
            Console.WriteLine($"Volume = {MyBox.calculateVolume()}");
            Console.ReadKey();
        }
    }
}
