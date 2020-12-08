using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public abstract class Command
    {
        private string _name;
        public string name { get { return _name; } set { _name = value; } }
        private string _secondWord;
        public string secondWord { get { return _secondWord; } set { _secondWord = value; } }
        private string thirdWord; 
        public string ThirdWord { get { return thirdWord; } set { thirdWord = value; } }
        private string fourthWord; 
        public string FourthWord { get { return fourthWord; } set { fourthWord = value; } }

        //Added a list for the words in the command for unlimited words in players command statement
        private Queue<string> words;
        public Queue<string> Words { get { return words; } set { words = value; } }


   

        public Command()
        {
            this.name = "";
            this.secondWord = null;
            this.thirdWord = null;
            this.fourthWord = null;
            this.words = null;
           
        }

        public bool hasSecondWord()
        {
            return this.secondWord != null;
        }

        public bool hasThirdWord()
        {
            return this.thirdWord != null;
        }

        public bool hasFourthWord()
        {
            return this.fourthWord != null;
        }
    
        public abstract bool execute(Player player);
    }
}
