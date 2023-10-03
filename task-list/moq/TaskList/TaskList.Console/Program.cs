using TaskList.Console;
using TaskList.Console.Controller;
using TaskList.Console.Model;
using TaskList.Console.Views;

var model = new ToDoList();
var mainView = new Main(model, Console.Out);
var controller = new Controller(new Terminator());

mainView.Render();
controller.HandleUserInput(Console.In);