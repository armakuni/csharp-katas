using System.Diagnostics.Metrics;
using TaskList.Console.Views;

namespace TaskList.Console.Model
{
    public class ToDoList : IModel
    {
        private int _counter = 1;
        private readonly List<ToDo> _incompleteTasks = new();

        public void NewTaskSpecified(string v)
        {
            var todo = new ToDo(_counter++, v);
            _incompleteTasks.Add(todo);
        }

        public void PreparingTaskList(ITaskView view)
        {
            view.IncompleteTasks(_incompleteTasks.ToArray());
        }
    }
}
