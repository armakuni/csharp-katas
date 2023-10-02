using TaskList.Console.Views;

namespace TaskList.Console.Model
{
    public class ToDoList : IModel
    {
        public void PreparingTaskList(ITaskView view)
        {
            view.IncompleteTasks(Array.Empty<ToDo>());
        }
    }
}
