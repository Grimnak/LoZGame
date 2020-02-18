# Code Readability Review

### Author: Aaron Rehfeldt

### Date: 2/17/2020

### Sprint No.: Sprint 2

### File Name: ./path/to/file.cs

### File Author Name: Ryan Scott

### Time Taken to Review: 20 minutes

###  Comments on What is Readable
- 	Current location is fairly arbitrary and could be hardcoded
- 	Update logic and naming make it very easy to understand what everything is doing and when
- 	CheckBorder command helps simplify update method and will make things easier in the future
	for collision detection, once again has hardcoded values where constants could be used to
	improve readability
