using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface IWeapon : I_Item
    {
        int Attack { get; set; }
        int getStrength(Player player);
        new void useItem(Player player);
        void useWeapon(Player player);

    }
}
