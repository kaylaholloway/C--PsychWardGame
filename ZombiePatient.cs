using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class ZombiePatient :IEnemy
    {
        //VIEW IENEMY INTERFACE FOR DESCRIPTIONS OF VARIABLES AND PROPERTIES

        private readonly string name = "Zombie Patient";
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
        //private I_Item drops = new ZombieFlesh();

        private I_Item[] list = { new RatTail(), new FirstAidKit(), new BandAid() };
        private Dictionary<int, I_Item> drops;
        public override Dictionary<int, I_Item> Drops { get { return drops; } }
        public override I_Item getDrops(int num)
        {
            return Drops[num];
        }

        public override int killValue()
        {
            return 150;
        }

        public ZombiePatient()
        {
            attack = 4;
            health = 14;
            hitProbability = 1;
            playerExp = 5;
            numItems = 2;
            drops = new Dictionary<int, I_Item>();
            for (int i = 0; i < list.Length; i++)
            {
                drops[i] = list[i];
            }
        }

        //Statement of enemy when greeting player
        public override string battleGreeting()
        {
            return "A mummified zombie patient blindsides you out of no where!";
        }

        //Description of the enemy attacking the player
        public override string attackDescription()
        {
            return "\nThe Zombie leaps forward and bites you!";
        }

    }
}
