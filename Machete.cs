using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Machete: IWeapon
    {
        private readonly String name = "machete";
        public String Name { get { return name; } }
        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.BattleItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }
        private float weight;
        public float Weight { get { return weight; } set { weight = value; } }

        private readonly string description = "A rusty machete to slice up foes!";
        public string Description { get { return description + "\nAttack: " + Attack; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }
        private int attack; 
        public int Attack { get { return attack; } set { attack = value; } }


        public Machete()
        {
            Weight = 2.5f;
            Value = 600;
            itemTypes = new HashSet<ItemType>(types);
            Uses = 10;
            Attack = 12;
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
