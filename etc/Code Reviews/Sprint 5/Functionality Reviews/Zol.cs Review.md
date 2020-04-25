# Code Functionality Review

### Author: Jeremy Wensink

### Date: 04/24/20

### Sprint No.: Sprint 5

### File Name: ./LoZGame/Enemies/EnemyClasses/Zol.cs

### File Author Name: Eric Henderson

### Time Taken to Review: 10 minutes

### Comments on Quality:
- Variables are appropriately named.
- Class not overly long.
- Very cohesive, simply creates a new Zol enemy.

### Potential Change to improve functionality
- Potentially refactor enemies to have a structure class that creates all of their necessary information, (like physics, health, etc) to further reduce what all needs created specifically in the enemy class.
Should be fairly easy to do, simply extract all code from the constructor that is shared among enemies and make it into a struct, then initiate that new struct.
