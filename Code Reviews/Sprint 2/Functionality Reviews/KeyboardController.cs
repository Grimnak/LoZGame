# Code Functionality Review

### Author: Eric Henderson.939

### Date: 02/16/2020

### Sprint No.: Sprint 2

### File Name: LoZGame/controller/KeyboardController.cs

### File Author Name: Jeremy Wensink.27

### Time Taken to Review: 30 minutes

### Comments on Quality:
- Excellent management of varying keys in using a dictionary data structure to succinctly iterate through every pressed key.
- The current design of creating separate decision-making structures for each "type" of commands might be a little basic but does the job well.
- It might be better to try and create dynamic key priorities instead of creating this static priorityComparer.

### Potential Change to improve functionality
- Instead of using a static priority setup where each command has a predetermined priority, perhaps create a stack in which the most recently pressed key has the highest priority.  This makes movement feel much more fluid and seems pretty intuitive and adaptable.
- This suggested change shouldn't be a giant hassle to implement, but it will require some restructuring (so it isn't a plug-and-forget issue).
