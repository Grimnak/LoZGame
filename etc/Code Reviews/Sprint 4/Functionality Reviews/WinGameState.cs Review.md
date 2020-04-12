# Code Functionality Review

### Author: Eric Henderson

### Date: 4/12/2020

### Sprint No.: 4

### File Name: ./LoZGame/GameState/WinGameState.cs

### File Author Name: Jeremy Wensink

### Time Taken to Review: 15 minutes

### Comments on Quality:
- Great reusability and expandability, clearly built to support the addition of many more dungeons.
- Properly functions, resetting all appropriate game objects as would make sense.
- Consider tying the length of the state to the length of the win song directly instead of just hardcoding 440, which happens to be about the same length.

### Potential Change to improve functionality
- Consider creating a game state abstract class to remove many of the empty methods from the class itself.  This is an extremely feasible change.
