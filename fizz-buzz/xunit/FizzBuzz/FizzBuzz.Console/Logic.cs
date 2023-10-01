namespace FizzBuzz.Console
{
    public class Logic
    {
        private readonly TextWriter _writer;

        public Logic(TextWriter writer) => _writer = writer;
        
        public void Evaluate(int number)
        {
            var isMultipleOfThree = number % 3 == 0;
            var isMultipleOfFive = number % 5 == 0;
            if(isMultipleOfThree)
                _writer.Write("Fizz");
            if (isMultipleOfFive)
                _writer.Write("Buzz");
            if (!(isMultipleOfThree || isMultipleOfFive))
                _writer.Write(number.ToString());
        }
    
    }
}
