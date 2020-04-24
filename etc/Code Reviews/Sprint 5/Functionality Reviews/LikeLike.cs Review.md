# Code Functionality Review

### Author: Eric Henderson

### Date: 04/24/20

### Sprint No.: Sprint 5

### File Name: ./LoZGame/Enemies/EnemyClasses/LikeLike.cs

### File Author Name: Sammy Lisa

### Time Taken to Review: 15 minutes

### Comments on Quality:
- Good separation of state concerns into a hierarchy of enemy functions (e.g. attack state and other wandering states are separated out).
- Each class that handles the LikeLike functionality is small and compact, allowing for high cohesion in each class.
- The code works quite well, as many edge cases, such as killing the enemy mid-attack, are handled effectively.

### Potential Change to improve functionality
- Consider adding support for the enemy that more accurately reflects its behavior ingame, namely the fact that it can strip Link of items during its attack sequence.
  As of right now, this functionality is absent but would be extremely feasible to include given the robustness of the enemy structure as a whole.
