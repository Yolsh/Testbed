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

            Console.WriteLine("=== Now testing Q7 ===");
            string[] plates = new string[] { "YB22 HFD", "NN05 WTR", "MT69 JPH", "KV17 LGT", "EY54 RTR", "MX60 FVE", "HF19 JCV", "NJ55 JYM", "AP66 NKC", "JO15 YRL", "JO15 YRL", "JO15 YRL" };
            for (int i = 0; i < plates.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (first.AddNewCar(plates[i])) Console.WriteLine($"Added {plates[i]}.");
                    else Console.WriteLine($"Couldn’t Add {plates[i]}.");
                }
                else
                {
                    if (second.AddNewCar(plates[i])) Console.WriteLine($"Added {plates[i]}.");
                    else Console.WriteLine($"Couldn’t Add {plates[i]}.");
                }
            }
            Console.WriteLine();

            Console.WriteLine("=== Now testing Q9 ===");
            boss.AddEmployee(first);
            boss.AddEmployee(second);
            boss.GiveRaises(10);
            Console.WriteLine($"Salary for {first.GetFullName()}: £{first.GetMonthlyPay()}.");
            Console.WriteLine($"Salary for {second.GetFullName()}: £{second.GetMonthlyPay()}.");
            Console.WriteLine($"Salary for {boss.GetFullName()}: £{boss.GetMonthlyPay()}.");
            Console.WriteLine();

            Console.WriteLine("=== Now testing Q10 ===");
            Manager bigBoss = new Manager("Dovin Bann");
            bigBoss.GiveRaise(100);
            bigBoss.AddEmployee(boss);
            if (bigBoss.AddEmployee(boss)) Console.WriteLine("Added boss a second time.");
            else Console.WriteLine("Failed to add boss a second time.");
            Console.WriteLine();

            Console.WriteLine("=== Now testing Q11 ===");
            bigBoss.GiveRaises(10);
            Console.WriteLine($"Salary for {first.GetFullName()}: £{first.GetMonthlyPay()}.");
            Console.WriteLine($"Salary for {second.GetFullName()}: £{second.GetMonthlyPay()}.");
            Console.WriteLine($"Salary for {boss.GetFullName()}: £{boss.GetMonthlyPay()}.");
            Console.WriteLine($"Salary for {bigBoss.GetFullName()}: £{bigBoss.GetMonthlyPay()}.");


            Console.ReadKey();
        }
    }
}
