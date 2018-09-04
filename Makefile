all: run

Zuul:
	@mcs Zuul.cs Game.cs Parser.cs Room.cs Command.cs CommandLibrary.cs Player.cs Inventory.cs Item.cs VaultSuit.cs Key.cs badItem.cs

clean:
	@rm -f Zuul.exe

run: Zuul
	@mono Zuul.exe
