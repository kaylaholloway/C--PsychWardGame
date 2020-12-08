using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class BandAid : I_Item
    {
        //This is a healing item, it heals the player by 10 health
        private float weight;
        public float Weight { get { return weight; } }

        private readonly string name = "band aid";
        public string Name { get { return name; } }

        private readonly string description = "Awww do you have a boo-boo?";
        public string Description { get { return description; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int Sellvalue;
        public int SellValue { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.BasicItem, ItemType.BattleItem, ItemType.HealthItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }
        public BandAid()
        {
            weight = 0.1f;
            Uses = 1;
            Value = 100;
            SellValue = 50;
            itemTypes = new HashSet<ItemType>(types);
        }

        public void useItem(Player player)
        {
            player.Health = player.Health + 10;
            this.uses--;
        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nHealth: +10\n" + "\nWeight: " + weight;
        }
    }
}
