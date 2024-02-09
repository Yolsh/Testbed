using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W125
{
    public class Account
    {
        public int balance;
        public int overDraftLimit;

        public void makeDeposit(int amount)
        {
            balance += amount;
        }
        public bool makeWithdrawal(int amount)
        {
            if (balance >= amount) balance -= amount;
            else return false;
            return true;
        }
    }
}
