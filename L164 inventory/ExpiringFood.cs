using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L164_inventory
{
    public class ExpiringFood : Food, IBreakable
    {
        private int Expires;

        public ExpiringFood(string inName, int inHealthBonus, int inExpires) : base(inName, inHealthBonus)
        {
            Expires = inExpires;
        }

        public void Break()
        {
            Expires--;
        }

        public bool IsBroken()
        {
            if (Expires <= 0) return true;
            return false;
        }
    }
}
