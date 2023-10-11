This file is dev log, for me and Almighty Audrey (Ignore Log.cs, I forgot to update it)

The majority of game in Program.cs is up to Player.CurrentChamber, unless Player.CurrentChamber is the destination, the game is not ended.

I write the events and event order in Chamber (another name for room) class, within the Interact() method; 
ChamberEvent() method handles all the NPCs and the items that can interact with player. 
My Chamber class can contain both an NPC and an item, player can interact with item after they interact with NPC.
I use recursion to examin all the chambers, 

I implement GameManager.cs to facilitate some frequently used functions, such as getting player inputs or fighting with hostile NPC. 

I set Player.cs as a static class, because there's only one player in this game, it's easier to manage all methods and parameters.

HostileNPC and FriendlyNPC are inherited from NPC, with some practice of polymorphism 
