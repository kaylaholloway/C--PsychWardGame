using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Game
    {
        Player player;
        Parser parser;
        bool playing;
        public Game()
        {
            //GameWorld gameWorld = new GameWorld();
            playing = false;
            parser = new Parser(new CommandWords());
            player = new Player(GameWorld.Instance.Entrance);
        }


        /**
     *  Main play routine.  Loops until end of play.
     */
        public void play()
        {

            // Enter the main command loop.  Here we repeatedly read commands and
            // execute them until the game is over.

            //This bool has been made a value to the game so that it can be updated if the player dies.
            bool finished = false;
            while (!finished)
            {
                Console.Write("\n>");
                Command command = parser.parseCommand(Console.ReadLine());
                if (command == null)
                {
                    Console.WriteLine("I don't understand...");
                }
                else
                {
                    finished = command.execute(player);
                }
            }
        }


        public void start()
        {
            playing = true;
            player.outputMessage(welcome());
        }

        public void end()
        {
            playing = false;
            player.outputMessage(goodbye());
        }

        public string welcome()
        {
            return "Welcome to the PsychWard!\n\n The PsychWard is a crazy abandoned hospital filled with mysteries.\n\nType 'help' if you need help." + player.currentRoom.description();
        }

        public string goodbye()
        {
            return "\nThank you for playing, Goodbye. \n";
        }


    }
}
