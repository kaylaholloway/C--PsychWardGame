using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class Rope : I_Item
    {
        private float weight;
        public float Weight { get { return weight; } }

        private readonly string name = "Rope";
        public string Name { get { return name; } }

        private readonly string description = "Does what a rope does, because it's a rope.";
        public string Description { get { return description; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.KeyItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        public Rope()
        {
            weight = 4;
            uses = 1; //One time use
            value = 400;
            itemTypes = new HashSet<ItemType>(types);
        }

        public void useItem(Player player) { 
            throw new NotImplementedException(); 
        }

        public void useItem(Rope r)
        {
            //Should provide a one way link
            r.uses--;
        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nUses" + uses + "\nWeight: " + weight;
        }
    }
}
