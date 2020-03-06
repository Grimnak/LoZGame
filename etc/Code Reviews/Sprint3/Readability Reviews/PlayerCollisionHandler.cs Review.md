# Code Functionality Review

### Author: Sammy Lisa

### Date: 3/6/2020

### Sprint No.: 3

### File Name: ./LoZGame/Collisions/PlayerCollisionHandler.cs

### File Author Name: Eric Henderson

### Time Taken to Review: 15 minutes

### Comments on Quality:
- good use of reusable methods with the DeterminePushBack() and DeterminePushDirection(). They are intuitive and clean.
- very few instances of hardcoding (although they are still there).
- appropriate use of the physics location, velocity, and acceleration fields.

### Potential Change to improve functionality
- consider getting rid of the collisionSide parameter in some methods, as well as the unused door collision handler method as they aren't needed. 
	- this is very feasible, but I understand that these params and the method are there for consistency.