using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class RatTail : I_Item
    {
        private float weight;
        public float Weight { get { return weight; } }

        private readonly string name = "rat tail";
        public string Name { get { return name; } }

        private readonly string description = "Can be mixed with other ingredients to make something useful";
        public string Description { get { return description; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.BasicItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        public RatTail()
        {
            weight = 0.5f;
            uses = 1;
            value = 50; //Change based on monetary system
            itemTypes = new HashSet<ItemType>(types);
        }

        public void useItem(RatTail rt)
        {
            rt.uses--;
        }

        public void useItem(Player player)
        {
            player.outputMessage("\n This item is meant to be sold for it's value.");
        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nUses" + uses + "\nWeight: " + weight;
        }
    }
}
