using System;

namespace ZuulCS
{
	public class Game
	{
		private Parser parser;
		private Player player;

		public Game ()
		{

			parser = new Parser();
			player = new Player();
			createRooms();
		}

		private void createRooms()
		{
			Room outside, theatre, pub, lab, office, attic;

			// create the rooms
			outside = new Room("outside the main entrance of the university");
			theatre = new Room("in a lecture theatre");
			pub = new Room("in the campus pub");
			lab = new Room("in a computing lab");
			office = new Room("in the computing admin office");
			attic = new Room("you are now in the attic");

			// initialise room exits
			outside.setExit("east", theatre);
			outside.setExit("south", lab);
			outside.setExit("west", pub);


			theatre.setExit("west", outside);

			pub.setExit("east", outside);

			lab.setExit("north", outside);
			lab.setExit("east", office);

			office.setExit("west", lab);
			office.setExit("up", attic);

			attic.setExit("down", office);

			player.currentRoom = outside;  // start game outside

			// Items
			VaultSuit Suit = new VaultSuit();
			Stimpack Stim = new Stimpack();

			//inventorys

			player.Inventory.addItem(Suit);
			//lab.Inventory.addItem(Suit);
			player.Inventory.addItem(Stim);
		}


		/**
	     *  Main play routine.  Loops until end of play.
	     */
		public void play()
		{
			printWelcome();

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the game is over.
			bool finished = false;
			while (! finished) {
				Command command = parser.getCommand();
				finished = processCommand(command);
			}
			Console.WriteLine("Thank you for playing.");
		}

		/**
	     * Print out the opening message for the player.
	     */
		private void printWelcome()
		{
			Console.WriteLine();
			Console.WriteLine("Welcome to Zuul!");
			Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
			Console.WriteLine("Type 'help' if you need help.");
			Console.WriteLine();
			Console.WriteLine(player.currentRoom.getLongDescription());
		}

		/**
	     * Given a command, process (that is: execute) the command.
	     * If this command ends the game, true is returned, otherwise false is
	     * returned.
	     */
		private bool processCommand(Command command)
		{
			bool wantToQuit = false;

			if(command.isUnknown()) {
				Console.WriteLine("I don't know what you mean...");
				return false;
			}

			string commandWord = command.getCommandWord();
			switch (commandWord) {
				case "help":
					printHelp();
					break;
				case "go":
					goRoom(command);
					break;
				case "quit":
					wantToQuit = true;
					break;
				case "look":
					Console.WriteLine(player.currentRoom.getLongDescription());
					break;

				case "health":
					Console.WriteLine(player.Health);
					break;
				case "inventory":
					if(command.hasSecondWord()){
						displayInvRoom(player.currentRoom);
					} else displayInv();
					break;

			}

			return wantToQuit;
		}

		// implementations of user commands:

		/**
	     * Print out some help information.
	     * Here we print some stupid, cryptic message and a list of the
	     * command words.
	     */
		private void printHelp()
		{
			Console.WriteLine("You are lost. You are alone.");
			Console.WriteLine("You wander around at the university.");
			Console.WriteLine();
			Console.WriteLine("Your command words are:");
			parser.showCommands();
		}

		/**
	     * Try to go to one direction. If there is an exit, enter the new
	     * room, otherwise print an error message.
	     */
		private void goRoom(Command command)
		{
			if(!command.hasSecondWord()) {
				// if there is no second word, we don't know where to go...
				Console.WriteLine("Go where?");
				return;
			}

			string direction = command.getSecondWord();

			// Try to leave current room.
			Room nextRoom = player.currentRoom.getExit(direction);

			if (nextRoom == null) {
				Console.WriteLine("There is no door to "+direction+"!");
			} else {
				player.currentRoom = nextRoom;
				player.Damage(10);
				player.isAlive();
				Console.WriteLine(player.currentRoom.getLongDescription());
			}
		}

		private void displayInv() {
			if(player.Inventory.Items.Count > 0){
				for (int i = 0; i < player.Inventory.Items.Count; i++) {
					Console.WriteLine(player.Inventory.Items[i].Name);
				}
			}
		}

		private void displayInvRoom(Room room) {
			if(room.Inventory.Items.Count > 0){
				for (int i = 0; i < room.Inventory.Items.Count; i++) {
					Console.WriteLine(room.Inventory.Items[i].Name);
				}
			}
		}

	}
}
