using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface ITask
    {
        //This will be the creation of a task, it needs a description, an indicator of it's completion so that
        //it can be removed, it needs to be set to a room. When the player enters the correct room the task
        //can be active and the user will be able to participate or forced into participation. 
        string Name { get; }
        //bool Active { get; set; }
        //bool Complete { get; set; }
        //Room TaskRoom { get; }
        TaskState TaskState { get; set; }
        string Description { get; }

    }
}
