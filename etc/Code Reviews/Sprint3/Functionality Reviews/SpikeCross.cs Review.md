# Code Functionality Review

### Author: Garrett Morse

### Date: 3/6/20

### Sprint No.: Sprint 3

### File Name: ./LoZGame/Enemies/EnemyClasses/SpikeCross.cs

### File Author Name: Ryan Scott

### Time Taken to Review: 15 minutes

### Comments on Quality:
- Instance Fields are private, good. We don't really need a private field for LoZGame since we can access LoZGame.Instance at any time.
- The constructor is pretty beefy. Some comments explaining the functionality would be helpful. It could also be shrunken down if some of the various fields used in the constructor were previously stored. Attacking and Retreating booleans and other fields set in constructor should have 'this.' where applicable appended to maintain consistency and reduce potential for bugs.
- AttackFactor appears to be a scalable variable that affects the velocity of SpikeCross. The way that it is set right now in checkForLink() is okay, but magic numbers can lead to some pain later if they end up creating dependency issues.
- Other code is pretty standard compared to the rest of our codebase. Collision handling, updating, etc all look to be in order.

### Potential Change to improve functionality
- There's potential for something fun to be done with the SpikeCross enemy. If we could place projectiles to "bait" the SpikeCross enemies into attacking, then that functionality would require a small refactor of the class. Additionally, this class will have to be revisited depending on how we handle camera panning in regards to room transitions. Right now, a SpikeCross is really annoying for the player to deal with since there's no time to react to a room transitioning. For us to reasonably implement the "bait" functionality, we'd have to be nearing the end of Sprint 5, as this is more of a "polish" type of feature more so than required functionality like Door state transitions, for example.
_Mention feasibility of said change as well_
