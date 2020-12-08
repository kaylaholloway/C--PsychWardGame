using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class LockPick : I_Item
    {
        private float weight;
        public float Weight { get; }

        private readonly string name = "lockpick";
        public string Name { get { return name; } }

        private readonly string description = "Picks locks, but know some doors can't be picked";
        public string Description { get { return description; } }

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.KeyItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        public LockPick()
        {
            weight = 0.1f;
            uses = 1;
            value = 100;
            itemTypes = new HashSet<ItemType>(types);
        }

        public void useItem(Player player)
        {
            throw new NotImplementedException();
        }

        public void useItem(Door d, LockPick l)
        {
            //if (d doesn't require key to be unlocked)
            //{
            //    d.Unlock(LockPick l);
            //}
            //else if (door requires key)
            //{
            //    Console.WriteLine("Door requires key");
            //}
            //else
            //{ 
            //  Console.WriteLine("Door already unlocked"); //Would be removed if action can only be
            //} //performed on doors that are locked
            l.uses--;
        }

        public override string ToString()
        {
            return name + "\n" + description + "\nUses per pick" + uses + "\nWeight: " + weight;
        }
    }
}
