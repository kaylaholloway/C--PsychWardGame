using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class FirstAidKit : I_Item
    {
        //This is a healing item, heals half the players health

        private float weight;
        public float Weight { get; }

        private readonly string name = "first aid kit";
        public string Name { get { return name; } }

        private readonly string description = "Heals you, if you know what you're doing";
        public string Description { get { return description; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.BasicItem, ItemType.HealthItem, ItemType.BattleItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        public FirstAidKit()
        {
            weight = 1;
            uses = 1;
            value = 350;
            itemTypes = new HashSet<ItemType>(types);

        }

        public void useItem(Player player)
        {
            throw new NotImplementedException();
        }

        public void useItem(Player player, FirstAidKit AidKit)
        {
            //p.heal() or p.Health = p.MaxHealth
            //Do we want to have the useItem methods to perform the item stuff?
            //i.e. the weapons "useItem" will deal damage to enemies and such?
            //or will that be in a separate class?
            //Is the player class gonna have all the player qualities or who's doing that
            AidKit.uses--;
        }

        override
        public string ToString()
        {
            return name + "\n" + description + "\nHealth healed: Half\n" + "\nWeight: " + weight;
        }
    }
}
