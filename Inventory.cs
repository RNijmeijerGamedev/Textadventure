using System;
using System.Collections.Generic;

namespace ZuulCS {

	public class Inventory{
		private List <Item> items;

		internal List<Item> Items { get => items; }
		public Inventory(){
			items = new List <Item>();

		}

		public bool addItem(Item item){

			items.Add(item);
			return true;

		}

	}

}
