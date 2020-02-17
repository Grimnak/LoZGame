# Code Functionality Review

### Author: Jeremy Wensink

### Date: 02/16/2020

### Sprint No.: 2

### File Name: ./LoZGame/sprites/LinkSpriteClasses/LinkAttackDownSprite.cs

### File Author Name: Garrett Morse

### Time Taken to Review: 20 mins

### Comments on Quality:
- Very little hard coding, makes use of lots of formulas.
- Very decoupled, only depends on location passed from link's state, doesn't need player at all.
- Quite cohesive, draws link attacking down, with a given item (sword, wand, etc.).

### Potential Change to improve functionality
- Lots of casting, especially in formulas. Could add floats before casting (instead of casting everything to ints and then adding). Quite feasible.
- To make even more cohesive, could split weapon sprite into a separate class, and have attack down create a new weapon sprite. Although feasible, the two classes would be highly coupled and could result in a large amount of classes.
