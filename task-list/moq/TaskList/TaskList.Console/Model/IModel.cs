using TaskList.Console.Views;

namespace TaskList.Console.Model
{
    public interface IModel
    {
        bool EditingTask(int taskId);
        void SpecifyingNewTask(string taskName);
        void PreparingTaskList(ITaskView view);
        void PreparingEditMode(ITaskView view);
        void UpdatingTaskName(ToDo toDo);
        void CompletingTask(int taskId);
    }
}