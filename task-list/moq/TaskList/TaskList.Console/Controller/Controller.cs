using TaskList.Console.Model;
using TaskList.Console.Views;

namespace TaskList.Console.Controller
{
    public class Controller
    {
        private readonly Terminator _terminator;
        private readonly EditTaskController _editTaskController;
        private readonly AddTaskController _addTaskController;

        public Controller(Terminator terminator, IViewSelector viewSelector, IErrorView errorView, IModel model)
        {
            _terminator = terminator;
            _editTaskController = new EditTaskController(model, errorView, viewSelector);
            _addTaskController = new AddTaskController(model, viewSelector);
        }

        public void HandleUserInput(TextReader input)
        {
            var data = input.ReadLine()?.ToLowerInvariant();
            if (data == "q")
                _terminator.Exit();
            else if (data == "a")
                _addTaskController.AddATask(input);
            else if (data != null)
                _editTaskController.EditATask(data, input);
        }
    }
}
