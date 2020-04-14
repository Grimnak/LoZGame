_3902 Functionality Format. Please fill out according to all italicized text. Remove all italicized text, unnecessary line breaks, and non-relevant sections before publishing Code Review_

# Code Functionality Review

### Author: Aaron Rehfeldtd

### Date: 04/13/20

### Sprint No.: Sprint 4

### File Name: ./LoZGame/Util/Inventory/InventoryComponents.cs

### File Author Name: Multiple Contributors

### Time Taken to Review: 15 minutes

### Comments on Quality:
- The choice to make the code a singleton so it can be easily accessed and changed in multiple game states was smart. Since there is only one Inventory in the game.
- Having the drawing split up into multiple methods so we can easily see what everything is doing and fix the methods that arent behaving correctly is really effective
- The class is a little long and could probably be split up into a main file which handles declaration and a file which handles the drawing methods.
- There are lots of calls to LoZGame.Instance.Player. Originally this seemed like a good idea so the inventory didnt need to know the player specifically.
	but having a variable which points to the player in the main declaration would be useful. Especially if we decided to have multiple players at some point.

### Potential Change to improve functionality
- Need to declare offset constants in someway. Or find a better way to define theh offsets for the items.
	Currently the offsets are defined by a vector declared privately, but this is ugly as the numbers were entirely guessed until we found a number that fits.
	Does really work well if we dynamically wanted to add more inventory components in the future. perhaps a container class which used different rectangles. Or we could have developed our own similar
	Inventory UI which would be easier to draw dynamically rather than forcing our inventory components to fit into the games ui.
