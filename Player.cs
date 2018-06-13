 using System;

namespace ZuulCS {

	public class Player{

		public Room currentRoom;
		public Int32 Health = 50;
        private Inventory inventory;
        internal Inventory Inventory {get => inventory;}


		//public PlayerHealth(){
		///	Health = 100;
		//}
        public Player(){
            inventory = new Inventory();
        }

		public double Damage(Int32 amount){
			this.Health-=amount;
			return Health;

		}

		public double Heal(Int32 amount) {
			this.Health+=amount;
			return Health;
		}

		public bool isAlive() {
			return true;
		}

	}


}
