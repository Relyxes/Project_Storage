using System;

namespace Project_ListStorage_Class
{
    public class Item
    {
        Item(){}

        public Item(string name)
        {
            Name = name;
        }
        
        public string Name { get; set; } = "emptyname";
        public int Counts { get; private set; } = 1;
        public void ChangeCount()
        {
            Counts++;
        }
            
    }
}