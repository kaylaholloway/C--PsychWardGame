using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class BackCommand : Command
    {

        public BackCommand()
        {
            this.name = "back";
        }
        public override bool execute(Player player)
        {
            NotificationCenter.Instance.postNotification(new Notification("PopCommands"));
            player.outputMessage(player.currentRoom.description());
            return false;
        }
    }
}
