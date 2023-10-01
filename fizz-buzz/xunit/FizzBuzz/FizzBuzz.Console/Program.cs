using FizzBuzz.Console;

var logic = new Logic(Console.Out);
for (var i = 1; i < 101; i++)
{
    logic.Evaluate(i);
    Console.WriteLine();
}