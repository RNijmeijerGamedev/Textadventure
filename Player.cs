 using System;

namespace ZuulCS {

	public class Player{

		public Room currentRoom;
		public int Health = 50;
        private Inventory inventory;
        internal Inventory Inventory {get => inventory;}


		//public PlayerHealth(){
		///	Health = 100;
		//}
        public Player(){
            inventory = new Inventory(4);
        }

		public int Damage(int amount){
			Health = Health - amount;
			return Health;

		}

		public int Heal(int amount) {
			this.Health+=amount;
			return Health;
		}

		public bool isAlive() {
			return true;
		}

	}


}
