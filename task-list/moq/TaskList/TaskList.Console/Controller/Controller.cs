using TaskList.Console.Model;
using TaskList.Console.Views;

namespace TaskList.Console.Controller
{
    public class Controller
    {
        private readonly Terminator _terminator;
        private readonly IModel _model;
        private readonly IViewSelector _viewSelector;
        private readonly IErrorView _errorView;

        public Controller(Terminator terminator, IViewSelector viewSelector, IErrorView errorView, IModel model)
        {
            _terminator = terminator;
            _model = model;
            _viewSelector = viewSelector;
            _errorView = errorView;
        }

        public void HandleUserInput(TextReader input)
        {
            var data = input.ReadLine()?.ToLowerInvariant();
            if (data == "q")
                Quit();
            else if (data == "a")
                AddATask(input);
            else if (data != null)
                AttemptTaskEdit(data);

        }

        private void AttemptTaskEdit(string? data)
        {
            var isParseable = int.TryParse(data, out var parsedTaskId);
            var success = isParseable && _model.RequestEditingTask(int.Parse(data));
            if (success)
                _viewSelector.EditingTaskMode();
            else
                _errorView.ErrorOccurred($"{data} is not a valid task id for editing");

        }

        private void AddATask(TextReader input)
        {
            _viewSelector.AddingTaskMode();
            var maybeName = input.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(maybeName))
            {
                _model.NewTaskSpecified(maybeName);
            }
            _viewSelector.MainMenuMode();
        }

        private void Quit() => _terminator.Exit();
    }
}
