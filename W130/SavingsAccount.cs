using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W130
{
    public class SavingsAccount : Account
    {
        private double interestRate;

        public SavingsAccount (Customer inOwner, double startBalance, double inInterestRate) : base (inOwner, startBalance)
        {
            interestRate = inInterestRate;
            owner = inOwner;
            balance = startBalance;
        }

        public void AddAnnualInterest()
        {
            if (!(interestRate <= 0))
            {
                Console.WriteLine($"{owner.GetName()} has gained £{balance * interestRate} as interest");
                balance = balance + balance * interestRate;
                return;
            }
            throw new AccountWithdrawalException(owner);
        }

    }
}
