using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class Batteries : I_Item
    {
        private float weight;
        public float Weight { get; }

        private readonly string name = "batteries";
        public string Name { get { return name; } }

        private readonly string description = "A pair of batteries";
        public string Description { get { return description; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.BasicItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        public Batteries()
        {
            weight = 0.106f; //The weight of 2 AA batteries
            uses = 1;
            value = 200; //To be updated in accordance with $ system
            itemTypes = new HashSet<ItemType>(types);
        }

        public void useItem(Flashlight o, Batteries b)
        {
            if (o.BatteryHealth == 0)
            {
                o.BatteryHealth = 10;
                b.uses--;
            }
            else
            {
                Console.WriteLine("Flashlight already charged");
            }
        }

        public void useItem(Player player)
        { 
            throw new NotImplementedException(); 
        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nUses per charge: 10\n" + "\nWeight: " + weight;
        }
    }
}
