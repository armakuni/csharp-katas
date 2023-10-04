using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Console.Model;

namespace TaskList.Console.Views
{
    internal class MainMenu
    {
        private readonly TextWriter _output;

        public MainMenu(TextWriter output) {
            _output = output;
        }

        public void Render(ToDo[] incompleteTasks, string? latestError)
        {
            if (incompleteTasks.Any())
                RenderListOfTasks(incompleteTasks);
            else
                RenderEmptyTaskList();
            RenderAnyErrors(latestError);
            RenderCommandPrompt();
        }

        private void RenderAnyErrors(string? latestError)
        {
            if (latestError != null)
                _output.WriteLine($"ERROR: {latestError}");
        }

        private void RenderEmptyTaskList() =>
            _output.WriteLine("You have no tasks");

        private void RenderListOfTasks(ToDo[] incompleteTasks)
        {
            _output.WriteLine("Tasks:");
            foreach (var task in incompleteTasks)
                _output.WriteLine($"{task.Id}. {task.Name}");
        }

        private void RenderCommandPrompt() =>
            _output.Write("(A)dd a task (Q)uit (or enter a task id): ");
    }
}
