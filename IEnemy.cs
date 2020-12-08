using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public abstract class IEnemy
    {
        //The enemies name 
        public abstract string Name { get; }
        
        //Attack power of the enemy 
        public abstract int Attack { get; set; }

        //Total health of the enemy 
        public abstract int Health { get; set; }

        //Chance of getting hit by enemy attack
        public abstract int HitProbability { get; }

        //Experience that will be given to the player
        public abstract int PlayerExp { get; set; }

        public abstract int NumItems { get; }

        //Gives a prompt when the player encounters the enemy
        public abstract string battleGreeting();

        //Displays what happens when the enemy attacks
        public abstract string attackDescription();

        public abstract I_Item getDrops(int num);

        public abstract Dictionary<int, I_Item> Drops { get; }
        //public abstract void getDrops(); 

        public abstract int killValue();

        //Displays the enemies battle stats
        public void currentStats()
        {
            Console.WriteLine("\n" + this.Name + "\nHealth: " + this.Health + "\nAttack: " +
                this.Attack + "\n");
        }

        //For all enemies, method updates the enemies stats relative to the players level to increase
        //difficulty of game as player gets stronger. 
        public void statstoPlayerLevel(int level)
        {
            this.Attack = (int)(level * 1.3) * Attack;
            this.Health = (int)(level * 1.3) * Health;
            this.PlayerExp = (int)(level * 1.3) * PlayerExp;
        }

        //This is the attack action by the rat. It will display the attack description and take away health
        //from the player if the random number is 1.
        public void attackPlayer(Player player)
        {
            int chance = new Random().Next(1, HitProbability + 1);
            if (chance == 1 && this.Health > 0)
            {
                Console.WriteLine("\n" + attackDescription() + "\n");
                player.Health -= new Random().Next((Attack/2), Attack + 1);
            }
            else { Console.WriteLine("\n" + Name + " missed the attack\n"); }
        }
    }
}
