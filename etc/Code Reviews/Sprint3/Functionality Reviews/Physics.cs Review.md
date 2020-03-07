_3902 Functionality Format. Please fill out according to all italicized text. Remove all italicized text, unnecessary line breaks, and non-relevant sections before publishing Code Review_

# Code Functionality Review

### Author: Aaron Rehfeldt

### Date: 03/06/2020

### Sprint No.: Sprint #3

### File Name: \LoZGame\LoZGame\util\Physics.cs

### File Author Name: Eric

### Time Taken to Review: 15 minutes

### Comments on Quality:
- Really smart addition to the game, high cohesion as it handles only movements of things on the screen
- low coupling, it is independent of other classes, handles physics in the game and has made it much easier to mess with
- Although still a wip from conversion in sprint 2, as we move things from the old method of manually updating locations to using the new Physics Class, 
	the maintainability of these classes and there motion has become much easier, now we need to change a single value here and there to fix strange behavior
	we can quickly identify what is causing the issue in regards to movements
	much easier to assign movement vectors based on a direction

### Potential Change to improve functionality
- Could incorporate an Update method which every class can call that automatically applies the Acclerate and Move command so as to decouple dependencies even more
- inclusion of an optional acceleration dampening vector which multiplies accelerataion by said vector on every update cycle
- Could be used to define bounding box in the future, bounds are dependent on location and size
	adding bounds to physics would mean everything that has to do with where an enemy is on screen and how it interacts in the environment can be made consistent accross all classes
