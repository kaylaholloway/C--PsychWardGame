using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Room
    {
        private Dictionary<string, Door> exits;
        private string _tag;
        public string tag { get { return _tag; } set { _tag = value; } }

        public string shortName { get; set; }

        //Chance that a an enemy will appear in a room, each room can have a different chance and it is 
        //decided at runtime. 
        private int chanceEnemy;
        public int ChanceEnemy { get { return chanceEnemy; } }

        //Giving the room the currentEnemy to the room because the room should be able to spawn them, take
        //them away, and manipulate the enemy belonging to that room. 

        private IEnemy currentEnemy;
        public IEnemy CurrentEnemy { get { return currentEnemy; } set { currentEnemy = value; } }

        //Contains all the NPCs that a player can interact with in a room. They Key will be the name they 
        //given, creator of the game chooses this when compiling. The value will be the enemy themselves. 
        private Dictionary<string, INPC> roomNpcs; 
        
        public Dictionary<string,INPC> RoomNpcs { get { return roomNpcs; } }

        //This dictionary containing the lists of items in the rooms allows for more than one of the 
        //same type of item to be inside a room. 
        private Dictionary<string, LinkedList<I_Item>> roomItems;
        public Dictionary<string,LinkedList<I_Item>> RoomItems {  get { return roomItems; } }

        public Room() : this("No Tag", "short", 0, 0)
        {
            
        }

        public Room(string tag) : this(tag, "short", 0, 0)
        {
            exits = new Dictionary<string, Door>();
            this.tag = tag;
            roomNpcs = new Dictionary<string, INPC>();
            roomItems = new Dictionary<string, LinkedList<I_Item>>();
            
        }
        public Room(string tag, string shortName) : this(tag, shortName, 0, 0)
        {
            exits = new Dictionary<string, Door>();
            this.tag = tag;
            this.shortName = shortName;
            roomNpcs = new Dictionary<string, INPC>();
            roomItems = new Dictionary<string, LinkedList<I_Item>>();
        }
        public Room(String tag, string shortName, int chanceEnemy) : this(tag, shortName, chanceEnemy, 0)
        {
            exits = new Dictionary<String, Door>();
            this.tag = tag;
            this.shortName = shortName;
            this.chanceEnemy = chanceEnemy;
            roomNpcs = new Dictionary<string, INPC>();
            roomItems = new Dictionary<string, LinkedList<I_Item>>();
        }
        //In the case that the user tells us to place some NPC's in the room this can do some randomly and
        //we only need to give the number of them we want. A generic class will be created to give them
        //their own characterstics 
        public Room(String tag, string shortName, int chanceEnemy, int numNpcs)
        {
            exits = new Dictionary<String, Door>();
            this.tag = tag;
            this.shortName = shortName;
            this.chanceEnemy = chanceEnemy;

            for (int i = 0; i < numNpcs; i++)
            {
                
            }
        }

        //Sets the exit with the associated door, used for connecting rooms. 
        public void setExit(string exitName, Door door)
        {
            exits[exitName] = door;
        }

        //Gives player the door they associated with the exit they are trying to take. 
        public Door getExit(string exitName)
        {
            Door door = null;
            exits.TryGetValue(exitName, out door);
            return door;
        }

        //displays exits availabe to player 
        public string getExits()
        {
            string exitNames = " ";
            Dictionary<string, Door>.KeyCollection keys = exits.Keys;
            int count = 0;
            foreach (string exitName in keys)
            {
                count++;
                if (keys.Count == count) 
                { 
                    exitNames += " " + exitName; 
                }
                else { 
                    exitNames += " " + exitName + ", "; 
                }
            }

            return exitNames;
        }

        //Displays the exits, npcs, and items the user can interact with. 
        public string description()
        {
            return "You are " + this.tag + ".\n *** Exits: " + this.getExits() + 
                "\n --- NPCs: " + displayNPCs() + "\n +++ Items in room: " + displayItems();
        }

        //Method will calculate the chance of running into an enemy and add an enemy to
        //the room based on that. Players current level is given to the room so that when the room
        //spawns an enemy it's stats are updated according to that players level. 
        public void getAnEnemy(int level)
        {
            EnemyType temp = new EnemyType();
            int chance1 = new Random().Next(1, ChanceEnemy + 1);

            if (chance1 == 1)
            {
                int chance = new Random().Next(0, temp.AllEnemies.Count);
                CurrentEnemy = temp.AllEnemies[chance];
                CurrentEnemy.statstoPlayerLevel(level);
            }
            else
            {
                CurrentEnemy = null;
            }
        }

        //Methods for adding and removing npcs from the room 

        public void addNPC(INPC npc)
        {
            
            RoomNpcs[npc.Name] = npc; 
        }

        public void removeNPC(INPC npc)
        {
            RoomNpcs.Remove(npc.Name);
        }

        //Displays information about npcs in the room. 
        public string displayNPCs()
        {
            string list = "";
            Dictionary<string, INPC>.KeyCollection keys = roomNpcs.Keys;
            int count = 0; 
            foreach(string npc in keys)
            {
                count++;
                if (keys.Count == count)
                {
                    list += npc;
                }
                else
                {
                    list += npc + ", ";
                }
            }
            return list;
        }

        //Methods to give an item to the room and take it from the room. 
        public void giveItem(I_Item item)
        {
            LinkedList<I_Item> check = null;
            RoomItems.TryGetValue(item.Name, out check);
            if (check == null)
            {
                RoomItems[item.Name] = new LinkedList<I_Item>();
                RoomItems[item.Name].AddFirst(item);
            }
            else
            {
                RoomItems[item.Name].AddLast(item);
            }

        }

        public I_Item takeItem(string item)
        {
            LinkedList<I_Item> check = null;
            RoomItems.TryGetValue(item, out check);
            if (check != null && check.Count != 0)
            {
                I_Item temp = check.First.Value;
                RoomItems[item].RemoveFirst();
                if (RoomItems[item].Count == 0) {
                    RoomItems.Remove(item); 
                }
                return temp;
            }
            else
            {
                Console.WriteLine("Item does not exist in the room!");
                return null; 
            }
        }
        //Method displays the item name and how many of them are inside the room. 
        public string displayItems()
        {
            string list = "";
            Dictionary<string, LinkedList<I_Item>>.ValueCollection values = RoomItems.Values;
            int count = 0;
            foreach (LinkedList<I_Item> item in values)
            {
                count++;
                if (values.Count == count)
                {
                    list += item.First.Value.Name + ": " + item.Count;
                }
                else
                {
                    //Missing value in this room once it was taken from the room. 
                    list += item.First.Value.Name + ": " + item.Count + ", ";
                }
            }
            return list;
        }

    }
}
