# Code Functionality Review

### Author: Garrett Morse

### Date: 04/13/20

### Sprint No.: Sprint 4

### File Name: ./LoZGame/Managers/Dungeon/DungeonMethods.cs

### File Author Name: Multiple Contributors

### Time Taken to Review: 10 minutes

### Comments on Quality:
- Magic numbers and switch case in the Reset() method. The constants need to be moved to another file and dungeonNumber should not be a condition for an if-else block, but rather a condition checked at assignment of the X and Y values that then pull from the constants file.
- We need to simplify the MoveUp(), MoveLeft(), etc functions for navigating the 2D array representations of our maps and dungeons. Even if it's just for sake of readability, we should have an overarching public function that does all the math for us so long as we pass currentX and currentY values, and other parameters when needed.
- LoadNewRoom() suffers from the same issue I have with the Move*() functions in that navigating the 2D arrays does not look good. It's a big break of the DRY principle that would help reduce the size of many files.
### Potential Change to improve functionality
- Let's create a public class that performs operations on all necessary 2D arrays and returns different values depending on the given parameters. One class with multiple overloaded 2D array mutating methods will significantly cut down on repeated code and file bloat. This change should be relatively easy to implement because it is not a breaking change and affected areas needing to be changed are easy to detect since it involves 2D arrays.
