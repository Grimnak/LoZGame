# Code Readability Review

### Author: Garrett Morse

### Date: 02/16/20

### Sprint No.: Sprint 2

### File Name: ./LoZGame/Player/DieState.cs

### File Author Name: Eric Henderson

### Time Taken to Review: 5 minutes

###  Comments on What is Readable
- Class, Constructor and Instance Fields are appropriately named to be able to instantly glean the functionality being encoded within the constructor.
- Having all potential actions Link can perform in this class is likely unnecessary and may be a foundation for refactoring this code and similar state-based code in the future.
- A comment explaining what createCorrectSprite() does through-and-through would be helpful in describing why in the body of this method, a specific factory method is invoked with the given player.CurrentColor parameter.
