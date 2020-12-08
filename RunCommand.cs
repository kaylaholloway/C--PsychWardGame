using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class RunCommand : Command
    {
        public RunCommand()
        {
            this.name = "run";
        }

        public string runStatement()
        {
            int choice = new Random().Next(1, 4);
            if (choice == 1) { return "Player chooses to run away like a coward!"; }
            else if (choice == 2) { return "Player escapes a terrible fate!"; }
            else { return "Player has no options left. Peace Oooouuuuttt!"; }
        }
        //The run command returns false so the player can exit the battle sequence
        public override bool execute(Player player)
        {
            player.outputMessage("\n" + runStatement());
            NotificationCenter.Instance.postNotification(new Notification("RanFromEnemy", this));
            NotificationCenter.Instance.postNotification(new Notification("PopCommands", this));
            return false;
        } 
    }
}
