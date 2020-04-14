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
Z - Attack with Equipped Sword

N - Use Equipped Item

I - Open & Close Inventory

Q - Exits the Game

R - Resets the Game to the Title Screen State

Mouse - Moves Rooms in the Direction you Click

### Inventory Controls:
W, A, S, D, Arrow Keys - Controls Item Selection

Enter - Equips Selected Item in Inventory

### Menu Controls:
Enter - Begin the Game

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
    Bug: Dungeon 3 is unfinished but exists.
	
    Plan(s) to fix: Finish the dungeon and add the new enemies.
    
### Player Sword Slowly Moving Down:
    Bug: Over time, the player's sword will become lower in relation to the player.
    
    Plans(s) to fix: Investigate sword location in relation to the player's bounding box and how they are correlated.
    
## Suppressed Warnings:
There are no suppressed warnings.
