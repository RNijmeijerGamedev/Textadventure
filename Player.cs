 using System;

namespace ZuulCS {
	
	public class Player{
		
		public Room currentRoom;
		public Int32 Health = 50;
	
		
		//public PlayerHealth(){
		///	Health = 100;
		//}
		
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
