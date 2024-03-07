using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W130
{
    public class Customer
    {
        private string name;
        private bool premium;

        public Customer(string inName, bool inPremium)
        {
            name = inName;
            premium = inPremium;
        }

        public string GetName()
        {
            return name;
        }

        public bool IsPremium()
        {
            return premium;
        }
    }
}
