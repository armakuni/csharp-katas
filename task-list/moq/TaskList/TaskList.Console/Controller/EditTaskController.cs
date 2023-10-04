using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Console.Model;
using TaskList.Console.Views;

namespace TaskList.Console.Controller
{
    internal class EditTaskController
    {
        private readonly IModel _model;
        private readonly IErrorView _errorView;
        private readonly IViewSelector _viewSelector;

        public EditTaskController(IModel model, IErrorView errorView, IViewSelector viewSelector) {
            _model = model;
            _errorView = errorView;
            _viewSelector = viewSelector;
        }

        public void EditATask(string? data, TextReader input)
        {
            var isParseable = int.TryParse(data, out var taskId);
            var success = isParseable && _model.EditingTask(taskId);
            if (success)
            {
                EditATask(taskId, input);
            }
            else
                _errorView.ErrorOccurred($"{data} is not a valid task id for editing");
            _viewSelector.MainMenuMode();
        }

        private void EditATask(int taskId, TextReader input)
        {
            _viewSelector.EditingTaskMode();
            var option = input.ReadLine()?.Trim().ToLowerInvariant();
            if (option == "c")
                ChangeTaskName(taskId, input);
            else if (option == "o")
                CompleteTask(taskId);
        }

        private void CompleteTask(int taskId) =>
            _model.CompletingTask(taskId);

        private void ChangeTaskName(int taskId, TextReader input)
        {
            _viewSelector.ChangingTaskNameMode();
            var newName = input.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(newName))
                _model.UpdatingTaskName(new(taskId, newName));
        }

    }
}
