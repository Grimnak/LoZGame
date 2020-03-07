# Code Functionality Review

### Author: Eric Henderson

### Date: 3/6/2020

### Sprint No.: 3

### File Name: ./LoZGame/Rooms/BlockClasses/Door.cs

### File Author Name: Garrett Morse

### Time Taken to Review: 15 minutes

### Comments on Quality:
- The class allows you to change door states, one per action method, which is consistent with project design.
- Ideally, remove hardcoding of window size variables in case the game eventually supports fullscreen.
- Class uses simple but effective structure, allowing for maximum flexibility (although see advice below).

### Potential Change to improve functionality
- Consider moving more of the logic from the door state classes to the actual Door class.  It's not ideal to have to set the collision bounds within the door state classes.  This is a very plausible fix given that most other objects that need state classes operate in the same manner.
