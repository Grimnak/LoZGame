# CSE 3902 - 9:10a Section - Team 3 - Readme

Developer version of Legend of Zelda NES emulator.  This is a functioning version of the first dungeon, featuring room transitions, combat, items, and collision detection and handling.

## Authors:
Eric Henderson.939

Sammy Lisa.5

Garrett Morse.172

Aaron Rehfeldt.2

Ryan Scott.2081

Jeremy Wensink.27


## Controls:
W, A, S, D, Arrow Keys - Controls the Player

Z, N - Attack buttons for Player

Q - Exits the game

R - Resets the game to its default state

1 - Places a Bomb

2, 5 - Fires an Arrow/Silver Arrow

3, 6 - Throws a Boomerang/Magic Boomerang

4, 7 - Uses the Blue Candle/Red Candle


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
    
### Slingshotting Wall Masters:
    Bug:  If player is currently getting knocked back and collides with a Wall Master, the player will fly off the screen in the direction of the knockback.
    
    Plan(s) to fix:  Disable ability for Wall Masters to pick the player up while the player is damaged.


## Suppressed Warnings:
The only suppressed warnings involved linter recommendations to modify spacing or order of variables, as well as some naming conventions.
