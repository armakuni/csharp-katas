using Moq;
using TaskList.Console.Model;
using TaskList.Console.Views;

namespace TaskList.Console.Tests
{
    [TestClass]
    public class ToDoListTests
    {
        private ToDoList? _sut;

        [TestInitialize] public void Init() {
            _sut = new ToDoList();
        }

        [TestMethod]
        public void WhenPreparingMainTaskList_ThenItSendsAListOfIncompleteTasksToTheView()
        {
            // A
            var viewMock = new Mock<ITaskView>();
            // A
            _sut!.PreparingTaskList(viewMock.Object);
            // A
            viewMock.Verify(view => view.IncompleteTasks(Array.Empty<ToDo>()));
        }

        [TestMethod]
        public void WhenANewTaskIsSpecified_ThenItCreatesTheNewToDo()
        {
            // A
            var viewMock = new Mock<ITaskView>();
            // A
            _sut!.NewTaskSpecified("Clean the table");
            // A
            _sut.PreparingTaskList(viewMock.Object); // trigger sending the incomplete tasks
            viewMock.Verify(view => view.IncompleteTasks(
                It.Is<ToDo[]>(todos =>
                    todos.Count(todo => todo.Name == "Clean the table") == 1
                )
            ));
        }

        [TestMethod]
        public void WhenTwoNewTasksAreSpecified_ThenTheyGetDistinctIds()
        {
            // A
            var viewMock = new Mock<ITaskView>();
            
            // A
            _sut!.NewTaskSpecified("Clean the table");
            _sut!.NewTaskSpecified("Mop the floor");
            // A
            _sut.PreparingTaskList(viewMock.Object); // trigger sending the incomplete tasks
            viewMock.Verify(view => view.IncompleteTasks(
                It.Is<ToDo[]>(todos =>
                    todos[0].Id != todos[1].Id
                )
            ));

        }
    }
}
