# CSE 3902 - 9:10a Section - Team 3 - Readme

Developer version of Legend of Zelda NES emulator.  This build features the first six dungeons and incomplete builds of the seventh and eighth dungeons.  There is also an option to turn "cheat mode" on, which gives the player unlimited items and infinite health.  This can be activated by accessing the options menu in-game.

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

### Options Menu:

- Difficulty: The selection you make in the options menu will only apply to future dungeons in your current playthrough
    - Note: Difficulty modifies how much damage the enemies deal, how much damage the player may take, how quickly the enemies move, AI behavior, as well as new functionality for a small number of enemies dependent on difficulty
- Cheats: Will grant you the ability to travel via Mouse Controller, infinite health and infinite use of most items.
- Debug: Draws bounding boxes of all relevant objects on screen
- Music: Toggles the game's built-in background music.

## External Tools:
Git

GitHub

Adobe Photoshop

Adobe Illustrator

Gimp

Discord


## Known Bugs:
### Mouse Controller
    Bug:  Various game features, namely some door loading and movable block functionality may break when entering a room via a mouse click.

    Plan(s) to fix:  Compare the code that handles room transitions with how rooms are loaded in via mouse controller and ensure they behave the same (or make them in fact use the same code entirely).
