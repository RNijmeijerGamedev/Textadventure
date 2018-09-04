using System;
using System.Collections.Generic;

namespace ZuulCS{


    public class BadItem : Item {

        public Player player;
         public BadItem(string name, string description){
             this.name = name;
             this.description = description;

        }

        public override void onPickup(){
            //Player.Damage(20);
            Console.WriteLine("You feel like you are getting weaker");
        }
    }

}
