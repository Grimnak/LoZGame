# Code Readability Review

### Author: Aaron Rehfeldt

### Date: 04/24/20

### Sprint No.: Sprint 5

### File Name: .\GameState\OptionsState.cs

### File Author Name: Garret Morse

### Time Taken to Review: 15 minutes

###  Comments on What is Readable
Variables are easy to read and understand.

Switch statement could have used enumeration of some sort to make it easier to read what exactly each case is checking for.
As developers we know the -1 - 3 represent the 4 difficulties available in the game and know what those are used for.
Could be changed to check for easy, normal, hard, nightmare

Some comments on the larger case statements would be useful as well. Nested switch statements are still the best for speed though.

