# Code Functionality Review

### Author: Sammy Lisa

### Date: 04/13/20

### Sprint No.: Sprint 4

### File Name: ./LoZGame/util/Physics/PhysicsMain.cs

### File Author Name: Aaron Rehfeld

### Time Taken to Review: 10 minutes

### Comments on Quality:
- good use of partial classes, each dealing with specific functionality concerns as physics becomes more complex.
- relatively high cohesion, functions are well-defined and do something.
- constants are well-defined, no magic numbers.

### Potential Change to improve functionality
- Consider adding a deceleration function for certain circumstances (e.g. when Link is pushing a block).
	This should be pretty feasible, as it's just a form of acceleration.
