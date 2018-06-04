using System;
using System.Collections.Generic;

namespace ZuulCS {

	public class Inventory{
		private Item item;
		private List <string> inventory;

		public Inventory(){
			inventory = new List <string>();
			inventory.Add("Knife");

			foreach (string Item in inventory) {
				Console.WriteLine(item);
			}
		}

	}

}
