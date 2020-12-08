using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class InteractCommand : Command
    {

        public InteractCommand()
        {
            this.name = "interact";
        }
        public override bool execute(Player player)
        {
            string notify = "PlayerSpeak_";
            string name = "";
            if (this.Words.Count == 0)
            {
                player.outputMessage("\nSpeak to who?");
                return false; 
            }
            else
            {
                while (this.Words.Count != 0)
                {
                    name += this.Words.Peek();
                    notify += this.Words.Dequeue();
                }
                //fix so that interact only works with npc's in the room. 
                name = name.Trim();
                if (name == "merchant")
                {
                    NotificationCenter.Instance.postNotification(new Notification("SpokeToMerchant", player));
                    NotificationCenter.Instance.postNotification(new Notification(notify, player));
                    player.outputMessage("\nType \"walk away\" to end the interaction");
                }
                else
                {
                    //NotificationCenter.Instance.postNotification(new Notification("SpokeToMerchant", player));
                    NotificationCenter.Instance.postNotification(new Notification(notify, player));
                    player.outputMessage("\nType \"walk away\" to end the interaction");
                }
            }
            return false; 
        }
    }
}
