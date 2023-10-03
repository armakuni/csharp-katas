using TaskList.Console.Model;
using TaskList.Console.Views;

namespace TaskList.Console.Controller
{
    public class Controller
    {
        private readonly Terminator _terminator;
        private readonly IModel _model;
        private readonly IViewSelector _viewSelector;

        public Controller(Terminator terminator, IViewSelector viewSelector, IModel model)
        {
            _terminator = terminator;
            _model = model;
            _viewSelector = viewSelector;
        }

        public void HandleUserInput(TextReader input)
        {
            var data = input.ReadLine()?.ToLowerInvariant();
            if (data == "q")
                Quit();
            else if (data == "a")
                AddATask(input);
            else
            {
                // handle task ids etc.
            }
        }

        private void AddATask(TextReader input)
        {
            // add a task
            _viewSelector.AddingTask();
            var maybeName = input.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(maybeName))
            {
                _model.NewTaskSpecified(maybeName);
            }
            _viewSelector.AtMainMenu();
        }

        private void Quit()
        {
            // quit
            _terminator.Exit();
        }
    }
}
