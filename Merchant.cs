using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class Merchant : INPC
    {

        private readonly string name = "merchant"; 
        public string Name { get { return name; } }
        private readonly string description = "Nice person who wants to trade with you!";
        public string Description { get { return description; } }

        //The tasks can be assigned to rooms by the GameWorld, but the Merchant has control of them
        //only she can take away from the taskList, or access them to mark them as completed to move through 
        //the game. 

        private Queue<ITask> taskList;
        public Queue<ITask> TaskList { get { return taskList; } }

        private ITask[] tasks = { new HowToPlay(), new KeyTask() }; 

        //This inventory is everything the merchant has available for purchase. 
        private Dictionary<string, I_Item> inventory;
        public Dictionary<string, I_Item> Inventory { get { return inventory; } set { inventory = value; } }

        private static I_Item[] MerchantItems = { new Axe(), new BandAid(), new Bat(),
            new Batteries(), new FirstAidKit(), new Hammer(), new Knife(), new LockPick(),
            new Machete(), new SutureKit()};

        //The room that the merchant is currently in. 
        private Room merchantRoom;
        public Room MerchantRoom { get { return this.merchantRoom; } }
        public Merchant(Room room)
        {
            this.merchantRoom = room;
            this.taskList = new Queue<ITask>(tasks);
            NotificationCenter.Instance.addObserver("PlayerSpeak_merchant", PlayerSpeak_merchant);
            NotificationCenter.Instance.addObserver("LeaveMerchant", LeaveMerchant);

            inventory = new Dictionary<string, I_Item>();
            foreach (I_Item item in MerchantItems) { inventory[item.Name] = item; }
        }

        //add tasks to the merchants list
        public void addTask(ITask task)
        {
            this.taskList.Enqueue(task);
        } 

        //When the player enters the merchant room, the commands allowed in the merchant room are set. 
        private void PlayerSpeak_merchant(Notification notification)
        {
            Player player = (Player)notification.Object;
            NotificationCenter.Instance.postNotification(new Notification("PushMerchantCommands", this));
            giveBackpack(player);
            givePlayerTask(player);
            Console.WriteLine("\nWould you like to: \n\tsell goods" + "\n\tbuy goods");
        }
        
        //Displays when interaction with merchent ends. 
        public void LeaveMerchant(Notification notification)
        {
            Console.WriteLine("\n\nThank's for your business. Come again soon!\n\n");
            
        }

        //Gives the new player a backpack. 
        public void giveBackpack(Player player)
        {
            if (player.Backpack == null)
            {
                Console.WriteLine("\nOh a new traveler. You're going to have trouble carrying things around in " +
                "your arms. Take this, it will help!");
                player.Backpack = new Backpack();
                player.Backpack.giveItem(new SutureKit());
                Console.WriteLine(player.Backpack.Description);
            }
        }

        public void givePlayerTask(Player player)
        {
            if (player.CurrentTask == null || player.CurrentTask.TaskState == TaskState.Complete)
            {
                if (TaskList.Count > 0)
                {
                    player.setCurrentTask(TaskList.Dequeue());
                    NotificationCenter.Instance.postNotification(new Notification("TaskSet", this));
                }
                else
                {
                    Console.WriteLine("\nYou have completed all current tasks available!");
                }
            }
        }


    }
}
