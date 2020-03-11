# Code Readability Review

### Author: Garrett Morse

### Date: 3/6/20

### Sprint No.: Sprint 3

### File Name: ./LoZGame/Enemies/EnemyStates/SpikeCrossStates/VerticalSpikeCrossState.cs

### File Author Name: Ryan Scott

### Time Taken to Review: 15 minutes

###  Comments on What is Readable
- This class implements the IEnemyState interface, making it easy to understand what the general goal of the class is
- A comment on why spikeCross Y velocity is being multiplied by 1 would be helpful. Since we don't necessarily know what spikeCross.AttackFactor is from the outside looking in, a brief comment explaining this line of code could go a long way. The rest of the constructor explains itself, though.
- State transitions are easy to glean from the code ( there only seems to be one for this class anyway)
- Update() is straightforward. SpikeCross moves, checks if it's reached its critical point, and updates the sprite.
- retreatCheck() could really use some brief comments particularly around code involving .Physics properties. It isn't necessarily intuitive what all Physics has access to, either. Again, having some kind of comment explaining what AttackFactor does in this state class would be useful here. Other properties like Attacking are straightforward. A brief comment explaining why (example) we check if spikeCross current Y is equal to its initial Y would be useful.
