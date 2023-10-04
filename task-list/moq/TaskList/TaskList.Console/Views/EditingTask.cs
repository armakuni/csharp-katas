using TaskList.Console.Model;

namespace TaskList.Console.Views
{
    internal class EditingTask
    {
        private readonly TextWriter _output;

        public EditingTask(TextWriter output) => _output = output;
        
        public void Render(ToDo? task)
        {
            _output.WriteLine($"Editing: {task?.Id}. {task?.Name}");
            _output.Write("(C)hange name or C(o)mplete task: ");
        }

        public void RenderForChangingTaskName() =>
            _output.Write("Enter new name: ");

    }
}
