# CSE 3902 - 9:10a Section - Team 3 - Readme

Developer version of Legend of Zelda NES emulator.  This build features a polished version of the first two dungeons and an incomplete build of the third dungeon.  There is also an option to turn "cheat mode" on, which gives the player unlimited items and infinite health.  This can be activated in the main LoZGame.cs file on line 12 by setting the value to "true".

## Authors:
Eric Henderson.939

Sammy Lisa.5

Garrett Morse.172

Aaron Rehfeldt.2

Ryan Scott.2081

Jeremy Wensink.27


## Controls:
### Player Controls:
Z - Attack Button for Player

N - Use Equipped Item for Player

I - Open & Close Player Inventory

Enter - Begin the Game

Q - Exits the Game

R - Resets the Game to its Default State

Mouse - Moves Rooms in the Direction you Click

### Inventory Controls:
W, A, S, D, Arrow Keys - Controls Item Selection

Enter - Equips Item in Inventory

## External Tools:
Git

GitHub

Adobe Photoshop

Gimp

Discord

Google Drive

MS Paint


## Known Bugs:
### Basement Item Drops:
    Bug:  Bats can drop items in the basement walls that are unobtainable.

    Plan(s) to fix:  Add boomerang capabilities to grab items and potentially make items spawn in-bounds.

### Dungeon Three:
    Bugs: Dungeon 3 is unfinished but exists.
	
    Plan(s) to fix: finish the dungeon

### Stalfos AI: 
	Bugs: Stalfos have the slight possibility of getting stuck on blocks and cancelling their hitbox. Bug occured once and was unable to be recreated

	Plan(s) to fix: Try to recreate the bug through testing to learn more about the issue.
	
### Player Sword Slowly Moving Down:
    Bug: Over time, the player's sword will become lower in relation to the player.
    
    Plans(s) to fix: Investigate sword location in relation to the player's bounding box and how they are correlated.
    
### Fire Snake (Moldorm)'s Head can Become Desynced from Body:
    Bug:  The Fire Snake's head can become desynced with the body when the player enters and leaves the room where they reside.
    
    Plan(s) to fix: Investigate how the head are body segments are updating, as the likely issue is one is getting extra time to update while the room is unloading.
    
## Suppressed Warnings:
There are no suppressed warnings.
