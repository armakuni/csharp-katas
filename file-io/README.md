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

### Extension 1:
Using LINQ:

1. Update the code that sorts and counts to use LINQ instead.
2. Ensure your tests still pass so you know it works as expected!

Example:
```
List<string> names = new List<string>();
// Load the names into the list

List<string> sortedNames = names.OrderBy(name => name);
```

The above code uses LINQ's OrderBy method to sort the list aphabetically using a lambda expression. ```name => name``` specifies that we want to sort by the names themselves.

### Extension 2:
File types:
1. Update the code to read the other file types provided - .csv and .json
2. Ensure the code is well separated - create a Parser class for each file type which can be used to read it, and manages getting the data into a common format for the processing
3. Write the output back out in the same format

### Tips:
1. You can use libraries to help with the different formats - for example, CsvHelper for CSV, and JsonConvert for JSON
2. Consider the code strucure carefully. For example, you might want a CSVReader, JSONReader etc. class, as well as a CSVWriter, JSONWriter and so on.


### Extension 3:
Sorting
1. Write your own algorithmn to sort the names! You might want to try Bubble sort, or Insertion sort.