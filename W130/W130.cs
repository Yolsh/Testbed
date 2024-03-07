using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W130
{
    internal class W130
    {
        static void Main(string[] args)
        {
            Customer myself = new Customer("Me", true);
            SavingsAccount mySavings = new SavingsAccount(myself, 1000, 0.015);

            Console.WriteLine("Balance: £" + mySavings.GetBalance());
            Console.ReadKey();

            mySavings.MakeDeposit(100);
            Console.WriteLine("Balance: £" + mySavings.GetBalance());
            Console.ReadKey();

            mySavings.AddAnnualInterest();
            Console.WriteLine("Balance: £" + mySavings.GetBalance());
            Console.ReadKey();

            mySavings.AddAnnualInterest();
            Console.WriteLine("Balance: £" + mySavings.GetBalance());
            Console.ReadKey();

        }
    }
}
