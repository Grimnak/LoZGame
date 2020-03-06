_3902 Functionality Format. Please fill out according to all italicized text. Remove all italicized text, unnecessary line breaks, and non-relevant sections before publishing Code Review_

# Code Functionality Review

### Author: Ryan Scott

### Date: 03/04/2020

### Sprint No.: Sprint 3

### File Name: ./LoZGame/Managers/HealthManager.cs

### File Author Name: Sammy Lisa

### Time Taken to Review: 20 minutes

### Comments on Quality:
- Entire file is extremely cohesive and very limited in what it does
- Very scalable, allowing for one manager for both enemies and player health and damage system
- Very decoupled, makes the manager work very well independent of where its being used

### Potential Change to improve functionality
- Consider adding reset health function that puts health to max immediately. 
Not a big change, would be simple to implement, and could possibly be useful in resetting the game or other instances.
