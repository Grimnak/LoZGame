_3902 Functionality Format. Please fill out according to all italicized text. Remove all italicized text, unnecessary line breaks, and non-relevant sections before publishing Code Review_

# Code Functionality Review

### Author: Aaron Rehfeldt

### Date: 04/13/20

### Sprint No.: Sprint 4

### File Name: .LoZGame\Rooms\BlockStates\MovableTileStates\UnsolvedState.cs

### File Author Name: Sammy Lisa

### Time Taken to Review: 10 minutes

### Comments on Quality:
- State only worries about its own personal tracked block, which makes it less dependent on other changes in the game and easier to maintain
- Update method divides tasks into smaller functions which makes it easier to read and easier to narrow down bugs in each method for maintainability
- the 3 smaller methods could split up some work, and some private bools could lower the cpu needed to run the update method

### Potential Change to improve functionality
- solve door and stairs should not recalculate the solved conditions continuously and individually, but rather simply check if a boolean has been set
- could only check for the puzzle being solved after each movement, lowering computational cost while the block is not being moved
- no need to pass door as a puzzle door state and no need to check for the state, there are enumerations of doors and the necessary methods needed to no longer need casting.

All these would be fairly easy modifications to improve the efficiency and reliability of the code.