using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Hammer : IWeapon
    {
        private readonly string name = "hammer";
     
        public string Name { get { return name; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.BattleItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }
        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }

        public readonly string description = "An awesome hammer to bash people's brains in with";
        public String Description { get { return description + "\nAttack: " + Attack; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }
        private int attack; 
        public int Attack { get { return attack; } set { attack = value; } }
        public Hammer()
        {
            Weight = .85f;
            Value = 350;
            itemTypes = new HashSet<ItemType>(types);
            Uses = 10;
            Attack = 8;
        }
        public int getStrength(Player player)
        {
            return player.Attack + Attack;
        }

        public void useItem(Player player)
        {
            player.outputMessage("Cannot use " + Name + " right now.\n");
        }

        public void useWeapon(Player player)
        {
            Uses--;
            if (Uses <= 0)
            {
                player.Weapon = null;
            }
        }

        override
        public string ToString()
        {
            return name + "\nAttack: " + attack + "\nWeight: " + weight + "lbs\n" + "Uses: " + uses + "\n";
        }
    }
}
