using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L164_inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero player1 = new Hero();
            Hero player2 = new Hero();
            Display(player1, player2);
        }

        static void Display(Hero player1, Hero player2)
        {
            foreach (Item item in player1.Inventory)
            {
                Console.Write(item.Name);
            }
        }
    }
}
