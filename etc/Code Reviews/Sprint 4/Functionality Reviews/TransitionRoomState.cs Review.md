_3902 Functionality Format. Please fill out according to all italicized text. Remove all italicized text, unnecessary line breaks, and non-relevant sections before publishing Code Review_

# Code Functionality Review

### Author: Ryan Scott

### Date: 04/10/2020

### Sprint No.: Sprint 4

### File Name: \LoZGame\GameState\TransitionRoomState.cs

### File Author Name: Multiple Authors

### Time Taken to Review: 25 minutes

### Comments on Quality:
- Use of stringsfor direction is not the best practice
- Switch statement is a good way to determine which transition is needed and dealing with it accordingly
- CreateCorrectSprite is a good way to increase cohesion and keep the constructor cleaner

### Potential Change to improve functionality
- Change the direction and switch statement to use an enum containing up,down,left,right rather than using a string. This should be very feasible using Physics.Direction enum we already have.
