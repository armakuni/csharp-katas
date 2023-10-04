using TaskList.Console.Model;

namespace TaskList.Console.Views
{
    public class Main : ITaskView, IViewSelector, IErrorView
    {
        private readonly IModel _model;
        private readonly TextWriter _output;
        private ToDo[] _incompleteTasks = Array.Empty<ToDo>();
        private string? _latestError;
        private ToDo? _editingTask;

        public Main(IModel model, TextWriter output)
        {
            _model = model;
            _output = output;
        }

        public void IncompleteTasks(ToDo[] toDos) =>
            _incompleteTasks = toDos;

        public void MainMenuMode()
        {
            _model.PreparingTaskList(this);
            if (_incompleteTasks.Any())
                RenderListOfTasks();
            else
                RenderEmptyTaskList();
            RenderAnyErrors();
            RenderCommandPrompt();
        }

        private void RenderAnyErrors()
        {
            if (_latestError != null)
            {
                _output.WriteLine($"ERROR: {_latestError}");
                _latestError = null;
            }
        }

        private void RenderEmptyTaskList() =>
            _output.WriteLine("You have no tasks");

        private void RenderListOfTasks()
        {
            _output.WriteLine("Tasks:");
            foreach (var task in _incompleteTasks)
            {
                _output.WriteLine($"{task.Id}. {task.Name}");
            }
        }

        private void RenderCommandPrompt() =>
            _output.Write("(A)dd a task (Q)uit (or enter a task id): ");

        public void ErrorOccurred(string errorMessage) =>
            _latestError = errorMessage;

        public void AddingTaskMode() =>
            _output.WriteLine("Enter a task name (or blank to cancel): ");

        public void TaskSelectedForEdit(ToDo? toDo) =>
            _editingTask = toDo;

        public void EditingTaskMode()
        {
            _model.PreparingEditMode(this);
            _output.WriteLine($"Editing: {_editingTask?.Id}. {_editingTask?.Name}");
            _output.Write("(C)hange name or C(o)mplete task: ");
        }

        public void ChangingTaskNameMode() =>
            _output.Write("Enter new name: ");
    }
}
