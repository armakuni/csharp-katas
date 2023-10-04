using TaskList.Console;
using TaskList.Console.Controller;
using TaskList.Console.Model;
using TaskList.Console.Views;

var model = new ToDoList();
var mainView = new Main(model, Console.Out);
var controller = new Controller(new Terminator(), mainView, mainView, model);

mainView.MainMenuMode();
// main loop
do
{
    // the controller will exit the program for us when the user chooses to Quit
    controller.HandleUserInput(Console.In);

} while (true);