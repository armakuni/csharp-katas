namespace TaskList.Console.Views
{
    public interface IViewSelector
    {
        void AddingTaskMode();
        void MainMenuMode();
        void EditingTaskMode();
        void ChangingTaskNameMode();
    }
}
