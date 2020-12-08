using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Parser
    {
        //private CommandWords commands;
        private Stack<CommandWords> allCommands;

        public Parser() : this(new CommandWords())
        {
            //NotificationCenter.Instance.addObserver("PushBattleCommands", PushBattleCommands);
            //NotificationCenter.Instance.addObserver("BattleSequence", battleSequence);
        }

        public Parser(CommandWords newCommands)
        {
            //commands = newCommands;
            allCommands = new Stack<CommandWords>();
            allCommands.Push(newCommands);
            NotificationCenter.Instance.addObserver("PushBattleCommands", PushBattleCommands);
            NotificationCenter.Instance.addObserver("PushMerchantCommands", PushMerchantCommands);
            NotificationCenter.Instance.addObserver("PushBackpackCommands", PushBackpackCommands);
            NotificationCenter.Instance.addObserver("PopCommands", PopCommands);
        }

        /*
         * This function is a alternative parser that allows the users commands to be as many words as 
         * they want without the need to keep writing new variables for additional words
        */
        public Command parseCommand(string commandString)
        {
            Command command = null;
            string[] check = commandString.Split(" ");
            Queue<string> allWords = new Queue<string>(commandString.Split(" "));

            if (allWords.Count > 0)
            {
                string commandName = "";
                command = giveCommand(allWords); 
                if (command != null)
                {
                    command.Words = new Queue<string>(allWords);
                }
                else
                {
                    Console.WriteLine(">>>Did not find the command " + commandName);
                }
            }
            else
            {
                Console.WriteLine(">>>Did not find the command ");
            }
            return command; 
        }

        public Command giveCommand(Queue<string> words)
        {
            Command command = null;
            string commandName = "";
            Queue<string> newWords = words;
            while(newWords.Count > 0 && command == null)
            {
                commandName += newWords.Dequeue();
                command = allCommands.Peek().get(commandName);
                if (command == null)
                {
                    commandName += " "; 
                }
            }
            return command; 
        }
         

        public string description()
        {
            return allCommands.Peek().description();
        }

        //Add the group of battle commands as the available commands 
        public void PushBattleCommands(Notification notification)
        {
            allCommands.Push(new CommandWords(CommandWords.battleCommands));            
        }

        //Remove battle commands as the available commands
        public void PopCommands(Notification notification)
        {
            allCommands.Pop();
        }

        public void PushMerchantCommands(Notification notification)
        {
            allCommands.Push(new CommandWords(CommandWords.merchantCommands));
        }

        public void PushBackpackCommands(Notification notification)
        {
            allCommands.Push(new CommandWords(CommandWords.backpackCommands));
        }

    }
}
