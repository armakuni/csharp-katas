namespace TaskList.Console.Controller
{
    public class Controller
    {
        private readonly Terminator _terminator;

        public Controller(Terminator terminator) => _terminator = terminator;

        public void HandleUserInput(TextReader input)
        {
            var data = input.ReadLine()?.ToLowerInvariant();
            if (data == "q")
            {
                _terminator.Exit();
            }
            else if (data == "a")
            {
                // add a task
            }
            else
            {
                // handle task ids etc.
            }
        }
    }
}
