using System;
using System.Collections.Generic;
using System.Text;

//THIS COMMAND IS FOR SETTING THE WEAPON OF YOUR PLAYER
namespace StarterGame
{
    public class SetWeaponCommand : Command
    {
        public SetWeaponCommand()
        {
            this.name = "set";
        }

        public override bool execute(Player player)
        {
            string weaponName = ""; 
            if (this.Words.Count <= 0)
            {
                player.outputMessage("\nSet what weapon?");
                player.outputMessage(player.Backpack.displayWeapons());
                return false;
            }
            else
            {
                while (this.Words.Count > 0)
                {
                    if (this.Words.Count == 1)
                    {
                        weaponName += this.Words.Dequeue();
                    }
                    else
                    {
                        weaponName += this.Words.Dequeue() + " ";
                    }
                }
                LinkedList<I_Item> weapon;
                if (player.Weapon == null)
                {
                    player.setWeapon((IWeapon)player.removeFromBackpack(weaponName));
                    player.outputMessage("\nYour new weapon has been set!\n");
                }
                else if (player.Backpack.Inventory.TryGetValue(weaponName, out weapon))
                {
                    IWeapon takenWeapon = player.takeWeapon();
                    player.Backpack.giveItem(takenWeapon);
                    player.setWeapon((IWeapon)player.removeFromBackpack(weaponName));
                    player.outputMessage("\nYour new weapon has been set!"); 
                }
                else
                {
                    player.outputMessage("You don't have a " + weaponName); 
                }
            }
            player.outputMessage(player.Backpack.displayItems());
            return false; 
        }
    }
}
