# CSE 3902 - 9:10a Section - Team 3 - READMe

## Authors:
Eric Henderson

Sammy Lisa

Garrett Morse

Aaron Rehfeldt

Ryan Scott

Jeremy Wensink


## Description:
Developer version of Legend of Zelda NES emulator. Draws the player, enemies, items, blocks, and projectiles that will be used in the final game without collision detection.


## Controls:
W, A, S, D - Controls the Player

U, I - Cycles Items being drawn

O, P - Cycles Enemy being drawn

K, L - Cycles Blocks being drawn

Z, N - Attack buttons for Player

Q - Exits the game

R - Resets the game to its default state

1 - Places a Bomb

2, 5 - Fires an Arrow/Silver Arrow

3, 6 - Throws a Boomerang/Magic Boomerang

4, 7 - Uses the Blue Candle/Red Candle

8 - Draws Animation for picking up a Triforce



## External Tools:
GitHub
Photoshop
Gimp
Discord
Google Drive
Paint

## Known Bugs:
### Movement Stuck:
    Bug:  After throwing a boomerang - If boomerang key is released, movement key is pressed, boomerang key is re-pressed and movement key is released before the boomerang returns, the player will continue to move in the movement direction until the boomerang key is released

    Plan(s) to fix:  Implement dynamic key priorities

### Bomb Explosion Drawing:
    Bug:  When the bomb explodes, there is ‘fuzz’ at the top and bottom of the explosion sprites due to a rendering error.
    
    Plan(s) to fix:  Refactor explosion sprites to have a small transparent gap in the png files
