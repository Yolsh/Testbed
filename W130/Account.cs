using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W130
{
    public class Account
    {
        protected double balance;
        private double overDraftLimit;
        protected Customer owner;

        public Account(Customer inOwner, double startBalance)
        {
            balance = startBalance;
            owner = inOwner;

            if (owner.IsPremium()) overDraftLimit = 1500;
            else overDraftLimit = 0;
        }

        public void MakeDeposit(double amount)
        {
            balance += amount;
        }

        public double GetBalance()
        {
            return balance;
        }

        public void MakeWithdrawal(double amount)
        {
            if (balance + overDraftLimit >= amount)
            {
                balance -= amount;
            }
            else
            {
                throw new ArgumentException("Insufficient funds.");
            }
        }
    }
}
