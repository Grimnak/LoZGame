# Code Readability Review

### Author: Ryan Scott

### Date: 04/21/2020

### Sprint No.: Sprint 5

### File Name: \LoZGame\Enemies\EnemyStates\EnemyEssentialStates\EnemyStateEssentials.cs

### File Author Name: Multiple Authors

### Time Taken to Review: 15 minutes

###  Comments on What is Readable
- spawnBlackList is a bit confusing. It would be a good idea to add a comment refering to what this list is used for.
- Good use of enums in the update switch statement to keep the code clean and rid of magic strings or numbers.
- DefaultUpdate is simple, clean, and readable. Overall great use of a partial class to keep both this simple, and all the individual enemy state classes much more simple and readable as a well.
