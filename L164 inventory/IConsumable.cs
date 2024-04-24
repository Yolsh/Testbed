using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L164_inventory
{
    public interface IConsumable
    {
        void Consume(Hero player);
    }
}
