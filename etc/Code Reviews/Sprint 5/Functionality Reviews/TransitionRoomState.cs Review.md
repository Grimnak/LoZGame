# Code Functionality Review

### Author: Garrett Morse

### Date: 04/24/20

### Sprint No.: Sprint 5

### File Name: ./LoZGame/GameState/TransitionRoomState.cs

### File Author Name: Aaron Rehfeldt

### Time Taken to Review: 10 minutes

### Comments on Quality:
- Variables are well named. I can infer the implementation for this class just from reading the instance fields.
- Switch case on direction is unnecessary. You can use the direction enum to set variables such as transitionDistance, nextRoomLocation and nextRoomOffset all in one line each.
- There are unnecessary loops present in the Update() method. You could refactor this so that you're merging lists of doors together into one list before iterating through the list. Then, look to pull specific types out using the *as* keyword.

### Potential Change to improve functionality
- Move highly coupled code out of the file into partial classes to be used within TransitionRoomState.cs as helper methods. That way, it is much easier to focus on code strictly cohesive to the idea of a room transition. After moving code out, we can focus on creating a class that dictates how a room transition should be performed. Currently, the code that performs the room transition is situated within TransitionRoomState. Additionally, this code is parallel to the already existing MouseConttroller CommandMove*.cs code. This is very dangerous and has already caused some nasty bugs for us. We need to merge functionality of the CommandMove*.cs files and this room transition file before we demo our final project. With all of the bulk of the project out of the way, I see this refactor taking a short amount of time. 
