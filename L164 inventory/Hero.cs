using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L164_inventory
{
    public class Hero
    {
        private int health;
        public Item[] Inventory = new Item[5];
        
        public void DoHealing(int HealAmount)
        {
            health += HealAmount;
        }

        public void Attacked(int Damage)
        {
            health -= Damage;
        }
    }
}
