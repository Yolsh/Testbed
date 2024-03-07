using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W129
{
    public class Account
    {
        private int balance;
        private int overDraftLimit;
        private Customer customer;

        public Account(Customer inCustomer)
        {
            balance = 0;
            customer = inCustomer; 
            if (customer.isPremium())
            {
                overDraftLimit = 1500;
            }
            else
            {
                overDraftLimit = 0;
            }
        }

        public Account(int startBalance, Customer inCustomer)
        {
            balance = startBalance;
            customer = inCustomer;
            if (customer.isPremium())
            {
                overDraftLimit = 1500;
            }
            else
            {
                overDraftLimit = 0;
            }
        }

        public void makeDeposit(int amount)
        {
            balance += amount;
        }

        public int getBalance()
        {
            return balance;
        }

        public void makeWithdrawal(int amount)
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
