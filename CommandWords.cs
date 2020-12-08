using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class CommandWords
    {

        //Dictionary of commands is where they are stored so that they still have a key for an accessor. 
        Dictionary<string, Command> commands;

        private static Command[] commandArray = {new GoCommand(), new InteractCommand(), new TaskCommand(),
            new PickUpCommand(), new BackpackCommand()};

        //These two arrays will be used in the stack implementation of the Commands, when a player enters a 
        //scenario in which the commands must be changed, the corresponding array of commands can be pushed
        //to the stack changing the available options. 
        public static Command[] merchantCommands = { new BuyCommand(), new SellCommand(),new WalkAwayCommand(),
             new BackpackCommand() };
        public static Command[] battleCommands = { new FightCommand(), new BackpackCommand(), new RunCommand()};
        //Add command for viewing item description. 
        public static Command[] backpackCommands = { new UseCommand(), new SetWeaponCommand(), new BackCommand() };
        public CommandWords() : this(commandArray)
        {
        }

        public CommandWords(Command[] commandList)
        {
            commands = new Dictionary<string, Command>();
            foreach (Command command in commandList)
            {
                commands[command.name] = command;
            }
            Command help = new HelpCommand(this);
            commands[help.name] = help;
            Command quit = new QuitCommand();
            commands[quit.name] = new QuitCommand(); 
            
        }

        public Command get(string word)
        {
            Command command = null;
            commands.TryGetValue(word, out command);
            return command;
        }
        

        public string description()
        {
            string commandNames = "";
            Dictionary<string, Command>.KeyCollection keys = commands.Keys;
            int count = 0; 
            foreach (string commandName in keys)
            {
                count++;
                if (keys.Count == count)
                {
                    commandNames += commandName;
                }
                else
                {
                    commandNames += commandName + ", ";
                }
            }
            return commandNames;
        }

    }
}
