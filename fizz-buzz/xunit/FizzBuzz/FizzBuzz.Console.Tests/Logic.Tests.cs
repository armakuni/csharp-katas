namespace FizzBuzz.Console.Tests
{
    public class LogicTests
    {
        private readonly Logic _logic;
        private readonly StringWriter _writer = new();

        public LogicTests() => _logic = new(_writer);

        [Theory]
        [InlineData(1, "1")]
        [InlineData(6, "Fizz")]
        [InlineData(10, "Buzz")]
        [InlineData(60, "FizzBuzz")]
        public void ItShouldEvaluateAsExpected(int input, string expected)
        {
            _logic.Evaluate(input);
            Assert.Equal(expected, _writer.ToString());
        }
    }
}