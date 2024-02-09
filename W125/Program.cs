using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W125
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();


            string choice;
            do
            {
                menu();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("how much would you like to deposit?");
                        account.makeDeposit(int.Parse(Console.ReadLine()));
                        break;
                    case "2":
                        Console.WriteLine("how much would you like to withdraw?");
                        Console.WriteLine((account.makeWithdrawal(int.Parse(Console.ReadLine()))) ? "The Withdrawl was successful" : "insufficient funds");
                        break;
                    case "3":
                        Console.WriteLine(account.balance);
                        break;
                    case "4":
                        Console.WriteLine("What Would you Like to Change to?");
                        if (Console.ReadLine() == "Standard") account.overDraftLimit = 200;
                        else if (Console.ReadLine() == "Premium") account.overDraftLimit = 1000;
                        break;
                }
            }
            while (choice != "9");
        }
        public static void menu()
        {
            Console.WriteLine("Welcome to the Gringotts Bank");
            Console.WriteLine();
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrawal");
            Console.WriteLine("3. See Balance");
            Console.WriteLine("4. Account Type");
            Console.WriteLine();
            Console.WriteLine("9. Exit");
            Console.WriteLine();
        }
    }
}
