using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L164_inventory
{
    public class Weapon : Item, IBreakable, IDoDamage
    {
        private int Durability;
        private int Damage;

        public Weapon(int inDamage, int inDurability, string inName)
        {
            Name = inName;
            Durability = inDurability;
            Damage = inDamage;
        }

        public void Break()
        {
            Durability--;
        }

        public void DoDamage(Hero player)
        {
            player.Attacked(Damage);
        }

        public bool IsBroken()
        {
            if (Damage <= 0) return true;
            return false;
        }
    }
}
