using TaskList.Console.Model;

namespace TaskList.Console.Views
{
    public interface ITaskView
    {
        void TaskSelectedForEdit(ToDo? toDo);
        void IncompleteTasks(ToDo[] toDos);
    }
}