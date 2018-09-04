using System;
using System.Collections.Generic;
namespace ZuulCS
{
    public class Item
    {
        public string name;
        public string description;



        public string Name
        {
            get { return name; }
        }

        public string getDescription
        {
            get { return description; }
        }

        public virtual void onPickup(){

        }

        public void use(){

        }
    }
}
