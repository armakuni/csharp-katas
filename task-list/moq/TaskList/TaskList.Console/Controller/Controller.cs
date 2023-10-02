namespace TaskList.Console.Controller
{
    public class Controller
    {
        private readonly Terminator _terminator;

        public Controller(Terminator terminator) => _terminator = terminator;

        public void HandleUserInput(TextReader input)
        {
            input.ReadLine();
            _terminator.Exit();
        }
    }
}
