using TaskList.Console.Views;

namespace TaskList.Console.Model
{
    public class ToDoList : IModel
    {
        private int _counter = 1;
        private ToDo? _editingTask;
        private readonly List<ToDo> _incompleteTasks = new();

        public void NewTaskSpecified(string taskName)
        {
            var todo = new ToDo(_counter++, taskName);
            _incompleteTasks.Add(todo);
        }

        public void PreparingTaskList(ITaskView view)
        {
            view.IncompleteTasks(_incompleteTasks.ToArray());
        }

        public bool RequestEditingTask(int taskId)
        {
            var found = _incompleteTasks.Find(task => task.Id == taskId);
            if (found != default)
            {
                _editingTask = found;
            }
            return found != default;
        }

        public void PreparingEditMode(ITaskView view)
        {
            view.TaskSelectedForEdit(_editingTask);
        }

        public void TaskNameUpdate(ToDo toDo)
        {
            if (_editingTask?.Id != toDo.Id)
                throw new ArgumentOutOfRangeException(nameof(toDo));
            var newTask = _editingTask! with { Name = toDo.Name };
            _incompleteTasks.Remove(_editingTask);
            _incompleteTasks.Add(newTask);
            _editingTask = newTask;
        }

        public void RequestTaskCompletion(int taskId)
        {
            if (_editingTask?.Id != taskId)
                throw new ArgumentOutOfRangeException(nameof(taskId));
            _incompleteTasks.Remove(_editingTask);
            _editingTask = null;
        }
    }
}
