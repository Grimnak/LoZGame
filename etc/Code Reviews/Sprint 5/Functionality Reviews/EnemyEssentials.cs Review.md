# Code Functionality Review

### Author: Ryan Scott

### Date: 04/21/20

### Sprint No.: Sprint 5

### File Name: ./LoZGame/Enemies/EnemyClasses/EnemyEssentials

### File Author Name: Multiple Contributors

### Time Taken to Review: 20 minutes

### Comments on Quality:
- Good idea to make an overarching class for enemy functionality. Does a great job of limiting every individual enemy.
- Virtual methods is a great way to allow for the necessary individuality that these enemies require.
- Damage handling is done well to minimize the amount of conditional statements. However, sound effects require a lot of conditional checks that may make the functionality slightly inefficient.

### Potential Change to improve functionality
- Consider breaking up the takeDamage and handleDamage into enemy specific methods in their individual classes. Both methods, while performing the correct and necessary functionality, may be able to be made a bit cleaner if used in enemy specific classes.
 This change is feasible but may not be the optimal solution. However, the idea does warrant some thought as to which implementation is better.
_Mention feasibility of said change as well_
