using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class FinalBoss : IEnemy
    {
        private readonly string name = "Final Boss";
        public override string Name { get { return name; } }

        private int attack;
        public override int Attack { get { return attack; } set { attack = value; } }
        private int health;
        public override int Health { get { return health; } set { health = value; } }

        private int hitProbability;
        public override int HitProbability { get { return hitProbability; } }

        private int playerExp;
        public override int PlayerExp { get { return playerExp; } set { playerExp = value; } }

        private int numItems;
        public override int NumItems { get { return numItems; } }

        public override Dictionary<int, I_Item> Drops => throw new NotImplementedException();

        public FinalBoss()
        {
            attack = 30;
            health = 1000;
            hitProbability = 3;
            playerExp = 2500;
        }
        public override string attackDescription()
        {
            return "The luny mummy man flails his arms at you in craziness!"; 
        }

        public override string battleGreeting()
        {
            return "The final battle begins";
        }

        public override int killValue()
        {
            return 1000;
        }

        public override I_Item getDrops(int num)
        {
            throw new NotImplementedException();
        }

    }
}
