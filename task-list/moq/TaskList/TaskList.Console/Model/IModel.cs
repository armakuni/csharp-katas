using TaskList.Console.Views;

namespace TaskList.Console.Model
{
    public interface IModel
    {
        bool RequestEditingTask(int taskId);
        void NewTaskSpecified(string taskName);
        void PreparingTaskList(ITaskView view);

        void PreparingEditMode(ITaskView view);
    }
}