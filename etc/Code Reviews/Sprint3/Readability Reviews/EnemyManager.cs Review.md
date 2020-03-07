# Code Readability Review

### Author: Aaron Rehfeldt

### Date: 03/06/2020

### Sprint No.: Sprint 3

### File Name: C:\Users\16reh\Desktop\LoZGame\LoZGame\Managers\EnemyManager.cs

### File Author Name: Jeremy

### Time Taken to Review: 15 minutes

###  Comments on What is Readable
- Keeps functions seperate and they all server their own purpose
- Helper Functions for the Update method make it very easy to read through and understand how the manager updates and maintains its current list of enemies
- The simplicity and flexibility of this class became the basis for every other manager It incorporated the best parts of the old projectile managers and cut out the excess
- Forced previous implementations of entities (projectiles, enemies, items, etc) to take only a location. While it was a heavy refactor, the readability of the entire game
and lower coupling between the managers and entities was worth it. It became much easier to implement more types of entities and managers, making the task more of a copy and paste of 
enemies rather than a new class with a new approach. Vastly improved maintenance and readability through the whole game as a result
