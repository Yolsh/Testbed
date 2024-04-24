using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L164_inventory
{
    public class Food : Item, IConsumable
    {
        private int HealthBonus;

        public Food(string inName, int inHealthBonus)
        {
            HealthBonus = inHealthBonus;
            Name = inName;
        }

        public virtual void Consume(Hero player)
        {
            player.DoHealing(HealthBonus);
        }
    }
}
