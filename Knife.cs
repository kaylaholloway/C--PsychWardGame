using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Knife : IWeapon
    {
        private readonly string name = "knife";
        public string Name { get { return name; } }
        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.BattleItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }
        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }

        private readonly string description = "A knife perfect for carving out zombie eyes!";
        public string Description { get { return description + "\nAttack: " + Attack; } }
 
        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }
        private int attack; 
        public int Attack { get { return attack; } set { attack = value; } }


        public Knife()
        {
            Weight = .25f;
            itemTypes = new HashSet<ItemType>(types);
            Value = 250; 
            Uses = 10;
            Attack = 5;
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
