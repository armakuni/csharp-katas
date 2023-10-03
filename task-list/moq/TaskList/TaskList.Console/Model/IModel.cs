using TaskList.Console.Views;

namespace TaskList.Console.Model
{
    public interface IModel
    {
        void NewTaskSpecified(string v);
        void PreparingTaskList(ITaskView view);
    }
}