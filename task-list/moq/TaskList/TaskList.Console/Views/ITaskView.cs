using TaskList.Console.Model;

namespace TaskList.Console.Views
{
    public interface ITaskView
    {
        void IncompleteTasks(ToDo[] toDos);
    }
}