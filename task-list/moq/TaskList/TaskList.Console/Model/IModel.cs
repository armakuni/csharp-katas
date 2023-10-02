using TaskList.Console.Views;

namespace TaskList.Console.Model
{
    public interface IModel
    {
        void PreparingTaskList(ITaskView view);
    }
}