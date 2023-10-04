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
                AttemptTaskEdit(data, input);

        }

        private void AttemptTaskEdit(string? data, TextReader input)
        {
            var isParseable = int.TryParse(data, out var taskId);
            var success = isParseable && _model.RequestEditingTask(taskId);
            if (!success)
                _errorView.ErrorOccurred($"{data} is not a valid task id for editing");
            else
            {
                _viewSelector.EditingTaskMode();
                var option = input.ReadLine()?.Trim().ToLowerInvariant();
                if(option == "c")
                {
                    _viewSelector.ChangingTaskNameMode();
                    var newName = input.ReadLine()?.Trim();
                    if (!string.IsNullOrWhiteSpace(newName))
                        _model.TaskNameUpdate(new(taskId, newName));
                }
                else if (option == "o")
                    _model.RequestTaskCompletion(taskId);
                _viewSelector.MainMenuMode();
            }
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
