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

    }
}
