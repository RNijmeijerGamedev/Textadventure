using System;
using System.Collections.Generic;

namespace ZuulCS {

	public class Item{
        protected Int32 Damage;
        protected Int32 Heal;
        protected Int32 Weight;
		protected string name;
		protected string discription;


		internal string Name {get => name;}
		internal string Discription {get => discription;}


        public Item(){
			name = "item";
			discription = "generic item";
        }

		}

	}
