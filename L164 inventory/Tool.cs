using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L164_inventory
{
    public class Tool : Item, IBreakable
    {
        private int Durability;

        public Tool(int inDurability, string inName)
        {
            Name = inName;
            Durability = inDurability;
        }

        public void Break()
        {
            Durability--;
        }

        public bool IsBroken()
        {
            if (Durability <= 0) return true;
            return false;
        }
    }
}
