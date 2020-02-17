# Code Functionality Review

### Author: Garrett Morse

### Date: 02/16/2020

### Sprint No.: Sprint 2

### File Name: ./LoZGame/player/Link.cs

### File Author Name: Eric Henderson

### Time Taken to Review: 15 minutes

### Comments on Quality:
- tracking damage on Link can be refactored into a decorator class, it doesn't need to be hardcoded into the class itself
- functional parts of the code are decoupled well
- Handling traversable bounds for the player by hardcoding the screen into the class could be done better, even considering the fact that this is only staying around for Sprint 2. A separate helper class could be used, for example.

### Potential Change to improve functionality
- Create an abstract class to handle all of the instance fields and properties in this class, since there are many. This change will only take about 30 minutes to refactor given that the current state of the Link class is fully functional. The abstract class will help reduce the bloat created from all necessary handling of Link's states. This change could be reasonably performed because it does not introduce major new functionality but rather reformats how the code itself reads.
