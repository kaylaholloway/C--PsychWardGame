using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class UseCommand : Command
    {
        public UseCommand()
        {
            this.name = "use";
        }

        public override bool execute(Player player)
        {
            //In this method will write how a player will use an item they have in their bag. 
            if (this.Words.Count > 0)
            {
                string item = "";
                while (this.Words.Count > 0)
                {
                    if (this.Words.Count == 1)
                    {
                        item += this.Words.Dequeue();
                    }
                    else
                    {
                        item += this.Words.Dequeue() + " ";
                    }
                }
                I_Item itemToUse = player.Backpack.takeItem(item);
                if (itemToUse == null)
                {
                    player.outputMessage("\nYou don't have a " + item + " to use");

                }
                else
                {
                    itemToUse.useItem(player);
                    player.outputMessage(player.Backpack.displayItems());

                }
                return false;
            }
            player.outputMessage("\nUse What\n");
            player.outputMessage(player.Backpack.displayItems());
            return false;
        }
    }
}
