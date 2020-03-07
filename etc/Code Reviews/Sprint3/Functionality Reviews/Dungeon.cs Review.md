# Code Functionality Review

### Author: Jeremy Wensink

### Date: 03/06/2020

### Sprint No.: Sprint 3

### File Name: ./LoZGame/Managers/dungeon.cs

### File Author Name: Garrett Morse

### Time Taken to Review: 10 mins

### Comments on Quality:
- Easy to understand method names, MoveUp clearly moves the dungeon room to the next one above it.
- 2D list of room objects makes navigating the dungeon quite simple, merely increment or decrement the appropriate x or y value.
- Great utilization of other managers, allows easy dynamic swapping of current objects being drawn on screen.

### Potential Change to improve functionality
- Dungeon as of right now directly changes players location with a vector only defined within it, that vector should probably be declared elsewhere and only accessed for assignment in the move methods.
Should be fairly feasable, as these vectors could be moved to the palyer itself, and an access to that player could then be made to reassign to the new vector.
- Hard coding for special cases (basement) needs to be changed in a way to allow for other special cases in the future. This hard coding makes the if statements a little offputting.
Changing this may be a bit more difficult, as it is somewhat hard to determine a way to handle these rare rooms with not much else in common.
