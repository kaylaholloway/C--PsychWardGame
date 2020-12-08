using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{
    public class GoCommand : Command
    {

        public GoCommand() : base()
        {
            this.name = "go";
        }

        /*override
        public bool execute(Player player)
        {
            if (this.hasSecondWord() && this.hasThirdWord() && this.hasFourthWord())
            {
                player.waltTo(this.secondWord + " " + this.ThirdWord + " " + this.FourthWord);
            }
            else if (this.hasSecondWord() && this.hasThirdWord())
            {
                player.waltTo(this.secondWord + " " + this.ThirdWord);
            }
            else if (this.hasSecondWord())
            {
                player.waltTo(this.secondWord);
            }
            else
            {
                player.outputMessage("\nGo Where?");
            }
            return false;
        }*/

        //this alternative execute makes it so that we don't need to keep adding if statements when 
        //our locations have more and more words
        
        public override bool execute(Player player)
        {
            string location = "";
            if (this.Words.Count == 0)
            {
                player.outputMessage("\nGoWhere?");
                return false;
            }
            while (this.Words.Count > 0)
            {
                if (this.Words.Count == 1)
                {
                    location += this.Words.Dequeue();
                }
                else
                {
                    location += this.Words.Dequeue() + " ";
                }
            }
            location = location.Trim();
            player.waltTo(location);
            return false;
        } 
    }
}
