# Code Functionality Review

### Author: Jeremy Wensink

### Date: 04/13/20

### Sprint No.: Sprint 4

### File Name: ./LoZGame/Enemies/EnemyClasses/EnemyEsseitials.cs

### File Author Name: Aaron Rehfeldt

### Time Taken to Review: 10 minutes

### Comments on Quality:
- Easy to understand what methods do.
- Methods all have high cohesion, typically only do one thing.
- Methods all quite short.

### Potential Change to improve functionality
- Potentially separate into multi-leveled abstract classes, since not all enemies have children, and have a EnemyWithChildren abstract class that contains the contracts for relevant methods (UpdateChild/AddChild).
	-Fairly feasible, as it would only require the addition of one extra class and an additional level of inheritence for (at the moment only) one enemy.
