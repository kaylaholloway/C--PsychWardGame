using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Player
    {
        private Room _currentRoom = null;
        public Room currentRoom { get { return _currentRoom; } set { _currentRoom = value; } }

        //players current strength
        private int attack; 
        public int Attack { get { return attack;} set { attack = value; } }

        //Is the players current health. 
        private int health; 
        public int Health { get { return health; } set { health = value; } }

        //Is the players maximum health
        private int maxHealth; 
        public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }

        //Player level up system, starts at level 1 
        private int level; 
        public int Level { get { return level; } set { level = value; } }

        //Experience will be total experience for player and is used for level up. 
        private int experience; 
        public int Experience { get { return experience; } set { experience = value; } }

        //ExpLimit is the amount of experience the player needs to reach the next level. 
        private int expNeeded; 
        public int ExpNeeded { get { return expNeeded; } set { expNeeded = value; } }

        private int coins; 
        public int Coins { get { return coins; } set { coins = value; } }
        
        //Current Task is simply that, the task the player is currently trying to complete given by the merchant.
        private ITask currentTask; 
        public ITask CurrentTask { get { return currentTask; } }

        //The player will be capable of holding one weapon at a time. The players weapon attack will 
        //stack onto the players attack damage and each battle will degrade the weapons use by one. 
        private IWeapon weapon; 
        public IWeapon Weapon { get { return weapon; } set { weapon = value; } }

        //Allows the player to keep a limited inventory with them. 
        private Backpack backpack; 
        public Backpack Backpack { get { return backpack; } set { backpack = value; } }

        //Chance of landing hit on the enemy 
        private int hitProbability;
        public int HitProbability { get { return hitProbability; } }

        public Player(Room room)//, GameOutput output)
        {
            _currentRoom = room;
            currentTask = null;
            attack = 6;
            level = 1;
            maxHealth = 100;
            health = MaxHealth;
            experience = 0;
            expNeeded = 15;
            coins = 0;
            weapon = new Axe();
            //weapon = null; 
            backpack = null; 
            hitProbability = 2;
            NotificationCenter.Instance.addObserver("TaskSet", TaskSet);
            NotificationCenter.Instance.addObserver("BattleOver", BattleOver);
            NotificationCenter.Instance.addObserver("RanFromEnemy", RanFromEnemy);
        }

        //Method when player is walking to another room. 
        public void waltTo(string direction)
        {
            Door door = this._currentRoom.getExit(direction);
            if (door != null)
            {
                if (door.Open)
                {
                    this._currentRoom = door.room(this.currentRoom);
                    // Player posts a notification PlayerEnteredRoom
                    this.outputMessage("\n" + this._currentRoom.description());
                    NotificationCenter.Instance.postNotification(new Notification("PlayerEnteredRoom", this));
                    NotificationCenter.Instance.postNotification(new Notification("BattleSequence", this));
                }
                else
                {
                    this.outputMessage("\n the door to " + direction + " is closed.");
                }
            }
            else
            {
                this.outputMessage("\nThere is no door on " + direction);
                this.outputMessage("\n" + this._currentRoom.description());
            }
        }

        //Notification that battle is over, reads current room description. 
        public void BattleOver(Notification notification)
        {
            this.Experience += this.currentRoom.CurrentEnemy.PlayerExp;
            this.LevelUp();
            this.outputMessage("You gained " + this.currentRoom.CurrentEnemy.PlayerExp + " experience"
                + "\n\t" + this.expToNextLvl() + " exp to next level!");
            this.outputMessage("\n****************************************************");
            //currentRoom.giveItem(currentRoom.CurrentEnemy.getDrops());
            NotificationCenter.Instance.postNotification(new Notification("EnemyGiveItems", this.currentRoom));
        }

        //Notification that the player ran from battle 
        public void RanFromEnemy(Notification notification)
        {
            this.outputMessage("\n" + currentRoom.description()); 

        }

        public void speak(String word)
        {
            outputMessage(word);
            NotificationCenter.Instance.postNotification(new Notification("Player has spoken", this));
        }

        public void useWeapon()
        {
            int discount = new Random().Next(1, (Attack / 2) + 1);
            currentRoom.CurrentEnemy.Health -= (this.totalAttack()-discount);
            if (Weapon != null)
            {
                Weapon.useWeapon(this);
            }
        }

        public int totalAttack()
        {
            if (weapon == null)
            {
                return this.Attack;
            }
            return Weapon.getStrength(this);
        }
        
        //A notification to the player that a task has been set. The task is then set to active. 
        public void TaskSet(Notification notification)
        {
            this.CurrentTask.TaskState = TaskState.Active;
            Console.WriteLine("\nA task has been set! (You can view the task description with the \"task\" command");
        }

        public void setCurrentTask(ITask task)
        {   
                this.currentTask = task; 
        }

        public void outputMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void currentStats()
        {
            outputMessage("Player \nHealth: " + this.Health +  (Weapon == null ? "\nNo Weapon" : "\nWeapon: " + Weapon.Name) +
                "\nAttack: " + this.totalAttack());
        }

        //picks up an item to be placed in backpack as it fits in the bag. 
        public void pickUpItem(string itemName)
        {
            I_Item item = currentRoom.takeItem(itemName);
            if (item != null)
            { 
                if ((Backpack.weightInBag() + item.Weight) >= Backpack.Capacity)
                {
                    Console.WriteLine("Backpack is full.");
                    currentRoom.giveItem(item);
                }
                else if (item.ItemTypes.Contains(ItemType.BattleItem) && Weapon == null)       
                {
                    Weapon = (IWeapon)item;
                    Console.WriteLine("\nYour weapon has been set to the " + itemName + "!\n");
                }
                
                
                    //key task 
                    //LinkedList<I_Item> check = null;
                    //if (Backpack.Inventory.TryGetValue(item.Name, out check))
                 else  if(Backpack.Inventory.ContainsKey("Key"))
                        
                        {
                            Console.WriteLine("\nSorry, you can pick up one key at a time.");
                            currentRoom.giveItem(item);
                        }
                 else
                        { 
                            
                            Backpack.giveItem(item);
                            Console.WriteLine("\nYou picked up a " + itemName + "!\n");
                            
                        }
                    
                }
            }
            
            
        

        public I_Item removeFromBackpack(string item)
        {
            return Backpack.takeItem(item);
        }

        //All the changes to stats for player when they level up. 
        public void LevelUp()
        {
            while (reachNextLevel())
            {
                Level++;
                Attack = (int)(attack * 1.35f);
                MaxHealth = MaxHealth + 5;
                Health = MaxHealth;
                ExpNeeded = ExpNeeded + (int)(ExpNeeded * 1.5f);
                
                outputMessage("\nYou grew to level " + (Level));
            }
            
        }

        //Returns whether a player has reached the next level or not. 
        public bool reachNextLevel()
        {
            if (Experience >= ExpNeeded)
            {
                return true;
            }
            return false;
        }

        //Experience needed to get to next Level
        public int expToNextLvl()
        {
            return ExpNeeded - Experience;
        }

        public void setWeapon(IWeapon weapon)
        {
            Weapon = weapon; 
        }

        public IWeapon takeWeapon()
        {
            IWeapon current = this.Weapon;
            this.Weapon = null;
            return current;
        }
    }

}
