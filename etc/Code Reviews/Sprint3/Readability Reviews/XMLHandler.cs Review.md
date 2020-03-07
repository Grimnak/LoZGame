# Code Readability Review

### Author: Jeremy Wensink

### Date: 03/06/2020

### Sprint No.: Sprint 3

### File Name: ./LoZGame/Util/XMLHandler.cs

### File Author Name: Garrett Morse

### Time Taken to Review: 10 mins

###  Comments on What is Readable
- Some variable names could be a little more clear as to what they are (trow vs rrow).
- Other variables are excellently named, doors are clearly doors that are being read in, items are items, etc. 
- Only one large method that does everything, looks somewhat cluttered, potentially could move door (and other entity) adding to separate method(s).
- Very streamlined and in order code, only focuses on parsing one type of object at a time.
