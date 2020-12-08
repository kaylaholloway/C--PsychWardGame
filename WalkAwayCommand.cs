using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class WalkAwayCommand : Command
    {

        public WalkAwayCommand()
        {
            this.name = "walk away"; 
            
        }


        public override bool execute(Player player)
        {
            
            NotificationCenter.Instance.postNotification(new Notification("PopCommands",this));
            NotificationCenter.Instance.postNotification(new Notification("LeaveMerchant", this));
            player.outputMessage("\n" + player.currentRoom.description());
            return false; 
        }
    }
}
