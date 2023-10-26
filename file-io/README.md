### Objective:
Create a C# program that reads and processes data from an input text file and writes the results to an output text file.

### Description:
You are given an input text file containing a list of names, one name per line. Your task is to create a C# program that reads the input file, processes the data, and writes the results to an output text file.

The processing involves counting the number of characters in each name and sorting the names alphabetically.

### Task:
1. Create a program that reads data from the input text file
2. For each name, caculate the characters in the name
3. Sort the names alphabetically
4. Write the results to a new file. For example:

Input:
```
Alice
Dave
Bob
Eve
```

Output:
```
Alice (5)
Bob (3)
Dave (4)
Eve (3)
```

### Tips:
The ```File``` class can be used to read and write from files
Use a ```StreamReader``` to read, and a ```StreamWriter``` to write!
It's always important to handle exceptions when reading and writing to files. Make sure you include this!