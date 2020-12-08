using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class SecurityGuard : IEnemy
    {
        private readonly string name = "Security Guard";
        public override string Name { get { return name; } }

        private int attack = 3;
        public override int Attack { get { return attack; } set { attack = value; } }
        private int health = 12;
        public override int Health { get { return health; } set { health = value; } }

        private int hitProbability = 2;
        public override int HitProbability { get { return hitProbability; } }

        private int playerExp = 4;
        public override int PlayerExp { get { return playerExp; } set { playerExp = value; } }
        private int numItems;
        public override int NumItems { get { return numItems; } }
        /*private I_Item drops = new LockPick();
        public override I_Item getDrops()
        {
            return new LockPick();
        }*/
        private I_Item[] list = { new LockPick(), new SutureKit(), new BandAid() };
        private Dictionary<int, I_Item> drops;
        public override Dictionary<int, I_Item> Drops { get { return drops; } }
        public override I_Item getDrops(int num)
        {
            return Drops[num];
        }
        public override int killValue()
        {
            return 200;
        }
        public SecurityGuard()
        {

        }
        public override string battleGreeting()
        {
            return "The psycho security guard is running at you with his batton!";
        }

        //Description of the Rat attacking the player to display. We can write more these in this method
        //and make it so that random ones display each time. 
        public override string attackDescription()
        {
            return "\nThe Security Guard swings at you!";
        }
    }
}
