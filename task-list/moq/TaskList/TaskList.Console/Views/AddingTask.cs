namespace TaskList.Console.Views
{
    internal class AddingTask
    {
        private readonly TextWriter _output;

        public AddingTask(TextWriter output) =>
            _output = output;

        public void Render() =>
            _output.WriteLine("Enter a task name (or blank to cancel): ");
    }
}
