using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class GenericNpc : INPC
    {
        private string name; 
        public string Name { get { return name; } set { name = value; } }
        private string description;
        public string Description { get { return description; } set { description = value; } }

        /*public static Dictionary<int, string> npcList = new Dictionary<int, string>()
        {
            { 1, "Robert" } , {2,"Marissa"}, {3,"Mary"}, {4, "Kendall" }, {5, "Andrew" }, {6, "Kairi" },
            {7, "Carie" }, {8, "Dro" }, {9, "Miguel" }, {10, "Minerva" }, {11,"Jackie" }, {12, "Amanda" },
            {13, "Charles" }, {14, "Wendy" }, {15, "Reggie" }
        }; */

        public GenericNpc() : this("No name", "A dull player with no life")
        {
        
        }
        public GenericNpc(string name) : this(name, "A dull player with no life")
        {
            this.name = name;
        }

        public GenericNpc(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}
