# Code Functionality Review

### Author: Sammy Lisa

### Date: 2/17/2020

### Sprint No.: Sprint 2

### File Name: .\LoZGame\Enemies\EnemyClasses\Dodongo.cs

### File Author Name: Ryan Scott

### Time Taken to Review: 20 minutes

### Comments on Quality:
- Good separation of concerns within the class
- Good random movement generator
- The Draw method is very easy to read but should rely more on the Update method for determining source and destination rectangles

### Potential Change to improve functionality
- In the CheckBorder() method, use the given game screen properties to determine width rather than hard-coded values.
- Problem is that there is only 1 interface that all enemies implement. It will take some work,
but it's feasible and will make the code more maintainable as the codebase grows.