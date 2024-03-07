using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W130
{
    public class AccountWithdrawalException : Exception
    {
        private string OwnerName;
        public AccountWithdrawalException(Customer owner)
        {
            OwnerName = GetOwnerName(owner);
            Console.WriteLine($"you are overdrawn {OwnerName}");
        }
        
        private string GetOwnerName(Customer owner)
        {
            return owner.GetName();
        }
    }
}
