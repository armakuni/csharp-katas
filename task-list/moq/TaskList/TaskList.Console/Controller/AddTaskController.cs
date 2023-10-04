using TaskList.Console.Model;
using TaskList.Console.Views;

namespace TaskList.Console.Controller
{
    internal class AddTaskController
    {
        private readonly IModel _model;
        private readonly IViewSelector _viewSelector;

        public AddTaskController(IModel model, IViewSelector viewSelector) {
            _model = model;
            _viewSelector = viewSelector;
        }

        public void AddATask(TextReader input)
        {
            _viewSelector.AddingTaskMode();
            var maybeName = input.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(maybeName))
                _model.SpecifyingNewTask(maybeName);
            _viewSelector.MainMenuMode();
        }

    }
}
