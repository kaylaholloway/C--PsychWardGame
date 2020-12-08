using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StarterGame
{
    public class Backpack : I_Item
    {

        private float weight;

        public float Weight { get { return weight; } }

        private readonly string name = "Backpack";

        public string Name { get { return name; } }

        private readonly string description; 
           
        public string Description { get { return description; }}

        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        private int uses;
        public int Uses { get { return uses; } set { uses = value; } }

        private HashSet<ItemType> itemTypes;
        private ItemType[] types = { ItemType.KeyItem };
        public HashSet<ItemType> ItemTypes { get { return itemTypes; } }

        private int capacity;
        public int Capacity { get { return capacity; } }

        private Dictionary<string, LinkedList<I_Item>> inventory;
        public Dictionary<string, LinkedList<I_Item>> Inventory { get { return inventory; } }

        public Backpack()
        {
            weight = 0; //Weight should be 0
            uses = 1; //Doesn't matter
            value = 0; //Unsellable anyways
            capacity = 30;
            description = "Pretty useful for holding items. \n\tCapacity: " + Capacity + "lbs";
            itemTypes = new HashSet<ItemType>(types);
            inventory = new Dictionary<string, LinkedList<I_Item>>();
        }
        public void giveItem(I_Item item)
        {
            LinkedList<I_Item> check = null;
            Inventory.TryGetValue(item.Name, out check);
            if (check == null)
            {
                Inventory[item.Name] = new LinkedList<I_Item>();
                Inventory[item.Name].AddFirst(item);
            }
            else
            {
                Inventory[item.Name].AddLast(item);
            }
            
        }

        public I_Item takeItem(string item)
        {
            LinkedList<I_Item> check = null;
            Inventory.TryGetValue(item, out check);
            if (check != null && check.Count != 0)
            {
                I_Item temp = check.First.Value;
                Inventory[item].Remove(temp);
                if (Inventory[item].Count == 0)
                {
                    Inventory.Remove(item);
                }
                return temp;
            }
            else
            {
                Console.WriteLine("Item does not exist in your backpack!");
                return null;
            }
        }


        public float weightInBag()
        {
            float temp = 0;
            Dictionary<string, LinkedList<I_Item>>.ValueCollection values = inventory.Values;
            foreach(LinkedList<I_Item> items in values)
            {
                foreach(I_Item item in items)
                {
                    temp += item.Weight;
                }
            }
            return temp; 
        }

        public string displayItems()
        {
            string list = "";
            Dictionary<string, LinkedList<I_Item>>.ValueCollection values = Inventory.Values;
            list += "\nWeight in Bag: " + weightInBag() + "lbs\n\t";
            foreach (LinkedList<I_Item> item in values)
            {
                list += item.First.Value.Name + ": " + item.Count + "\n\t";
            }
            return list;
        }

        public string displayWeapons()
        {
            string list = "";
            Dictionary<string, LinkedList<I_Item>>.ValueCollection values = Inventory.Values;
            list += "Weapons: \n\t"; 
            foreach (LinkedList<I_Item> item in values)
            {
                if (item.First.Value.ItemTypes.Contains(ItemType.Weapon))
                {
                    list += item.First.Value.Name + "\n"; 
                }
            }
            return list;
        }

        public void useItem(Player player)
        {
            Console.WriteLine("Can't really do all that.");
        }
    }
}
