using TaskList.Console;
using TaskList.Console.Controller;
using TaskList.Console.Model;
using TaskList.Console.Views;

var model = new ToDoList();
var main = new Main(model, Console.Out);
var controller = new Controller(new Terminator());
main.Render();
controller.HandleUserInput(Console.In);