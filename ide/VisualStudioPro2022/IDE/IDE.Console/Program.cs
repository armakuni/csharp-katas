// comment any of these out to stop the part running:
//#define PART1 
//#define PART2
#define PART3



#if PART1

/*
 * 
 * 1. Use the IDE to step through execution
 * 
 * Stepping through the functions provided in the correct order 
 * will reveal a hidden message one word at a time. 
 * 
 * Write the word here:
 * 
 */

using IDE.Console.Stuff;

var jjuliooi = new Jju1iooi();
jjuliooi.Isngke();

#endif



#if PART2

/*
 * 
 * 2. Breakpoints and Conditional breakpoints, modifying values and call stack
 * 
 * The code below computes for values of x, y and z.
 * 
 * i.   Add a breakpoint by clicking in the margin. Run using F5 (or "Start debugging"). Notice that it stops for every iteration of the loops
 *          - when the program breaks, find the Locals window and inspect the values for x, y and z (or mouseover the variables in the code)
 *              - note that you can modify the value of e.g. z in the "Locals" tab
 *              - note that you can evaluate statements in the "Immediate Window" tab (e.g. z * 2)
 *              - note that you can set the next line to skip a line, or even to skip a whole inner loop
 * ii.  Use a conditional breakpoint to determine the values of x, y and z which result in an result of 331929188. 
 *          - right click the break point in the margin and then settings.
 *              - set a Condition to stop the debugger when result == 331929188.
 *              - you can stop the program now - it's SLOW when you are using a conditional breakpoint.
 * 
 */

var count = 0;
var result = 0;
for(int x = 0; x < 100; x++)
{
    for (int y = 0; y < 100; y+=3)
    {
        for(int z = 10000; z > 1000; z-=50)
        {
            result += (x * y) - (x + y) * z * (x + z);
            count++;
        }
    }
}
Console.WriteLine($"{count} iterations");

#endif




#if PART3

/*
 * 
 * 3. Performance investigations
 * i. Set a breakpoint (F9) and run the code below. Find the "Diagnostic Tools" window and estimate how much memory your program uses by looking at the graph.
 * 
 */



using System.Runtime;

var nodes = new List<Node>();
Node lastNode = new(null);
nodes.Add(lastNode);

for(var i = 0; i < 1_000_000; i++)
{
    var nextNode = new Node(lastNode);
    nodes.Add(nextNode);
    lastNode = nextNode;
}

// baseline
Console.WriteLine("Take a BASELINE snapshot and press enter");
Console.ReadLine();

// get rid of the reference
Console.WriteLine("Cleaning up objects");
nodes.ForEach(node => node.Dispose());
nodes.Clear();
nodes = null;
Console.WriteLine("Take a CLEANED OBJECTS snapshot and press enter");
Console.ReadLine();

// clean up memory
Console.WriteLine("Cleaning up memory");
GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive, true, true);
Console.WriteLine("Take a CLEANED MEMORY snapshot and press enter");
Console.ReadLine();

// done
Console.WriteLine("Press enter to quit");
Console.ReadLine();

class Node : IDisposable
{
    public Node(Node? previous)
    {
        Previous = previous;
    }

    public Node? Previous { get; private set; }

    public void Dispose()
    {
        Previous = null;
    }
}

#endif