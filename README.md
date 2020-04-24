# CSE 3902 - 9:10a Section - Team 3 - Readme

Developer version of Legend of Zelda NES emulator.  This build features a polished version of the first five dungeons and an incomplete build of the sixth dungeon.  There is also an option to turn "cheat mode" on, which gives the player unlimited items and infinite health.  This can be activated in the main LoZGame.cs file on line 12 by setting the value to "true" or by accessing the options menu ingame by pressing the letter key "O".

Additional Sprint 5 features include 3 more polished dungeons, difficulty levels (levels largely untested except for normal), game-accurate unique enemy drop tables, the ability to continue a playthrough without restarting entirely, and a credits and options menu.

## Authors:
Eric Henderson.939

Sammy Lisa.5

Garrett Morse.172

Aaron Rehfeldt.2

Ryan Scott.2081

Jeremy Wensink.27


## Controls:
### Player Controls:
W, A, S, D, Arrow Keys - Controls Player Movement

Z - Attack with Equipped Sword

N - Use Equipped Item

I - Open & Close Inventory

O - Open and Close Options Menu

P - Pause and Unpause the Game

Q - Exits the Game

R - Resets the Game to the Title Screen State

Mouse - Moves Rooms in the Direction you Click (only present if Cheat Mode is enabled)

### Inventory Controls:
W, A, S, D, Arrow Keys - Controls Item Selection

### Menu Controls:
W, S, Up Arrow Key, Down Arrow Key - Controls Options Menu Selection

Enter - Begin the Game, Toggle an Option, or Continue Gameplay after Death

## External Tools:
Git

GitHub

Adobe Photoshop

Gimp

Discord

Google Drive

MS Paint


## Known Bugs/Missing Features:
### Basement Item Drops:
    Bug:  Bats can drop items in the basement walls that are unobtainable.

    Plan(s) to fix:  Add boomerang capabilities to grab items and potentially make items spawn in-bounds.
    
### Dungeon Five Boss:
    Bug:  Digdogger (Dungeon 5's boss) is missing.
    
    Plan(s) to fix:  Implement the boss.

### Dungeon Six:
    Bug: Dungeon 6 is unfinished but exists.
	
    Plan(s) to fix:  Finish the dungeon and add the new enemies.
    
### Mouse Controller
    Bug:  Various game features, namely some door loading and movable block functionality may break when entering a room via a mouse click.
    
    Plan(s) to fix:  Compare the code that handles room transitions with how rooms are loaded in via mouse controller and ensure they behave the same (or make them in fact use the same code entirely).
    
### Fire Snake (Moldorm)'s Segments can Become Displaced from Head:
    Bug:  The Fire Snake's final segments can become displaced with respect to the head when the player enters and leaves the room where they reside.
    
    Plan(s) to fix: Investigate how the head and body segments are updating, as the likely issue is one is getting extra time to update while the room is unloading.
    
## Suppressed Warnings:
There are no suppressed warnings.
