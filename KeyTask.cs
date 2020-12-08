using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class KeyTask: ITask
    {
        private string name;
        public string Name { get { return name; } }

        private TaskState taskState;
        public TaskState TaskState { get { return taskState; } set { taskState = value; } }
        
        private bool hasCorrectKey;
        public bool HasCorrectKey { get; set; }

        private string description;
        public string Description { get { return description; } }


        public KeyTask()
        {
            name = "Key Task";
            taskState = TaskState.Inactive;
            
            //this.taskRoom = room;
            description = "For this quest you will need locate the room that contains 3 keys " +
            "\nbut only 1 out of the 3 keys will open the door to the Main Courtyard. " +
           
            "\n\t Clue: It feels like rain but no clouds in sight!";

            //possible clues: some take me in the morning, some take me in th evening; but one thing
            //you should know when I'm taken I never go .. idkkkk
            //you should know when I'm taken you're never stankinn 


            //NotificationCenter.Instance.addObserver("KilledEnemies", KilledEnemiess);
            NotificationCenter.Instance.addObserver("HasCorrectKey", HasCorectKey);
        }
      
        public void HasCorectKey(Notification notification)
        {
            Player player = (Player)notification.Object;
            hasCorrectKey = true;
          
           
            player.outputMessage("You picked up a key!! Time to see if this is the one\n that will get you into the Main Courtyard.");
            TaskComplete();
            NotificationCenter.Instance.removeObserver("HasCorrectKey", HasCorectKey);

        }

        public void TaskComplete()
        {
            if (hasCorrectKey)
            {
                TaskState = TaskState.Complete;
                Console.WriteLine("\nYou completed the Key task!! Visit the merchant to get "
                    + "another task!\n");
                NotificationCenter.Instance.postNotification(new Notification("FinishedKeyTask", this));
            }
        }
        /*public void PickedUpItem(Notification notification)
        {
            Player player = (Player)notification.Object;
            pickedUpItem = true;
            player.outputMessage("You successfully picked up your first item!!\n");
            TaskComplete();
            NotificationCenter.Instance.removeObserver("PickedUpItem", PickedUpItem);
        }*/
        

    }
}
