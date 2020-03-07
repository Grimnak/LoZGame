# Code Readability Review

### Author: Garrett Morse

### Date: 3/6/20

### Sprint No.: Sprint 3

### File Name: ./LoZGame/Util/RandomStateGenerator.cs

### File Author Name: Ryan Scott

### Time Taken to Review: 10 minutes

###  Comments on What is Readable
- Brief comments for the instance fields would be helpful in understanding why they exist in the first place.
- In the constructor, a short comment explaining what LoZGame.Instance.Random represents would be helpful. The fields min and max should be prepended with 'this.' to maintain consistency both in terms of format and functionality.
- In Update(), A brief comment explaining what .Next() returns would be helpful. Particularly, the significance of any specific integer value. Based on the fact that the condition for the switch statement is named "random...", we can infer that a random integer from 0 to 9 is generated, thus dictating a state transition for any particular enemy. A comment explaining that virtually every single enemy is using this code would be helpful for an outside reader to understand why this class is in the Util folder.
