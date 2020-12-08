using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface I_Item
    {
        //weight is going to be used for items in the bookbag, weapons can have a weight of 0. 
        //It will be written in such a way that you can only hold two. 
        float Weight { get; }
        
        //The name should be initialized in the constructor of the items and should be readonly. The name of 
        //items should not change. 
        string Name { get;}

        //A simple item description. This can be displayed when the user picks it upneeds to know when it 
        //may be used. **For instance we won't outright say rope will be used at the window to the alley
        //but the player needs to know it will have a use down the road. 
        string Description { get; }

        //Will hold a reference to all the item types that a particular item qualifies as. 
        HashSet<ItemType> ItemTypes { get; }

        /*KeyItem will keep the player from selling the item, if they try to we can give an indication that
        //it is a key item and serves a purpose. 
        bool KeyItem { get; }
        */

        //How many times the item can be used. 
        int Uses { get; }

        //How much the item is worth. 
        int Value { get; }

        //A command will link to this when a player needs to use an item. A general command can allow a user
        //to use an item at any time so long as it is necessary and makes sense. 
        void useItem(Player player); 
    }
}
