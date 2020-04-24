# Code Readability Review

### Author: Sammy Lisa

### Date: 04/24/20

### Sprint No.: Sprint 5

### File Name: ./LoZGame/Enemies/EnemyClasses/BlueDarknut.cs

### File Author Name: Eric Henderson

### Time Taken to Review: 15 minutes

###  Comments on What is Readable
- Much of the general enemy functionality is now separated into a general enemy essentials class, making it easy to read the specific functionality of the blue darknut by looking at its class.
- Enemy data is separated into well organized files with straightforward names.
- Code is focused on readability rather than being extremely compact; this is especially true for the OnCollisionResponse() and Blocked() methods.
