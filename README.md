# The Legend of Zelda in Monogame

This build features all nine dungeons present in The Legend of Zelda (1986) with slightly modified gameplay and item placements.

## Authors:
Eric Henderson (henderson.939@osu.edu)

Sammy Lisa (lisa.5@osu.edu)

Garrett Morse (morse.172@osu.edu)

Aaron Rehfeldt (rehfeldt.2@osu.edu)

Ryan Scott (scott.2081@osu.edu)

Jeremy Wensink (wensink.27@osu.edu)


## Controls:
### Player Controls:
W, A, S, D, Arrow Keys - Controls Player Movement

Z - Attack with Equipped Sword

N - Use Equipped Item

I - Open & Close Inventory

O - Open and Close Options Menu

P - Pause and Unpause the Game

Q - Exits the Game

R - Resets the Game

Mouse - Moves Rooms in the Direction you Click (only present if Cheat Mode is enabled)

### Inventory Controls:
W, A, S, D, Arrow Keys - Controls Item Selection

### Menu Controls:
W, S, Up Arrow Key, Down Arrow Key - Controls Options/Profiles Menu Selections

Enter - Begin the Game, Toggle an Option, or Continue Gameplay after Death

### Options Menu:

- Difficulty: The selection you make in the options menu will only apply to future dungeons in your current playthrough
    - Note: Difficulty modifies how much damage the enemies deal, how much damage the player may take, how quickly the enemies move, AI behavior, as well as new functionality for a small number of enemies dependent on difficulty.
- Cheats: Will grant you the ability to travel via Mouse Controller, infinite health and infinite use of most items.
- Debug: Draws bounding boxes of all relevant objects on screen.
- Music:  Toggles the in-game background music.

## Required Tools:

None

## Known Bugs:
### Mouse Controller
    Bug:  Various game features, namely some door loading and movable block functionality may break when entering a room via a mouse click.

    Plan(s) to fix:  Compare the code that handles room transitions with how rooms are loaded in via mouse controller and ensure they behave the same (or make them in fact use the same code entirely).
