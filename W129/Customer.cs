using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W129
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

        public string getName()
        {
            return name;
        }

        public bool isPremium()
        {
            return premium;
        }
    }
}
