using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W130_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Now testing up to Q6");
            Driver first = new Driver("Shallan Davar");
            Driver second = new Driver("Dalinar Kholin");
            Manager boss = new Manager("Adolin Kholin");
            first.GiveRaise(2.5);
            boss.GiveRaise(5);
            Console.WriteLine($"Salary for {first.GetFullName()}: £{first.GetMonthlyPay()}.");
            Console.WriteLine($"Salary for {second.GetFullName()}: £{second.GetMonthlyPay()}.");
            Console.WriteLine($"Salary for {boss.GetFullName()}: £{boss.GetMonthlyPay()}.");
            Console.WriteLine();

        }
    }
}
