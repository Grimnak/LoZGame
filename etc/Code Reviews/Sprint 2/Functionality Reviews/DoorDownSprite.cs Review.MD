# Code Functionality Review

### Author: Aaron Rehfeldt

### Date: 2/17/2019

### Sprint No.: Sprint 2

### File Name: .\LoZGame\Sprites\BlockSpriteClasses\DoorDownSprite.cs

### File Author Name: Sammy Lisa

### Time Taken to Review: 20 minutes

### Comments on Quality:
- Use of sprite sheet data structure makes everything formulaic and easy to update or fix for future versions
- Update method could be simplified with internal methods to update frames, 
	less hardcoded values could make it a bit easier to understand what is happening
- The Draw method is very easy to read but should rely more on the Update method for determining source and destination rectangles

### Potential Change to improve functionality
- All classes including mine need to have a scaleable factor for the future project and extend 
Isprite for drawing and updating location/frames. Its feasible but will be a significant 
amount of refactored work on everyones part. Will definitely be worthwhile in the longrun
for maintenance and reusability for adding new items/enemies if we choose to in sprint 6.
