using TaskList.Console.Model;

namespace TaskList.Console.Views
{
    public class Main : ITaskView, IViewSelector, IErrorView
    {
        private readonly IModel _model;
        private readonly MainMenu _mainMenuView;
        private readonly AddingTask _addingTaskView;
        private readonly EditingTask _editingTaskView;
        // TODO: create a view model for these
        private ToDo[] _incompleteTasks = Array.Empty<ToDo>();
        private string? _latestError;
        private ToDo? _editingTask;

        public Main(IModel model, TextWriter output)
        {
            _model = model;
            _mainMenuView = new MainMenu(output);
            _addingTaskView = new AddingTask(output);
            _editingTaskView = new EditingTask(output);
        }

        public void IncompleteTasks(ToDo[] toDos) =>
            _incompleteTasks = toDos;

        public void MainMenuMode()
        {
            _model.PreparingTaskList(this);
            _mainMenuView.Render(_incompleteTasks, _latestError);
            _latestError = null;
        }

        public void ErrorOccurred(string errorMessage) =>
            _latestError = errorMessage;

        public void AddingTaskMode() =>
            _addingTaskView.Render();

        public void TaskSelectedForEdit(ToDo? toDo) =>
            _editingTask = toDo;

        public void EditingTaskMode()
        {
            _model.PreparingEditMode(this);
            _editingTaskView.Render(_editingTask);
        }

        public void ChangingTaskNameMode() =>
            _editingTaskView.RenderForChangingTaskName();
    }
}
