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

        [TestMethod]
        public void GivenNoTasksExist_WhenATaskIsRequestedForEdit_TheRequestIsDenied()
        {
            // A
            var actual = _sut!.RequestEditingTask(69);
            // A
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void GivenTheTaskExists_WhenItIsRequestedForEdit_ThenTheRequestIsAccepted()
        {
            // A
            _sut!.NewTaskSpecified("Pour a whisky");
            // A
            var actual = _sut!.RequestEditingTask(1);
            // A
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenTheTaskIsSelectedForEdit_WhenTheViewIsPreparingEditMode_ThenItSendsTaskDetailsToTheView()
        {
            // A
            _sut!.NewTaskSpecified("Pour a whisky");
            _sut.RequestEditingTask(1);
            var viewMock = new Mock<ITaskView>();
            // A
            _sut.PreparingEditMode(viewMock.Object);
            // A
            viewMock.Verify(view =>
                view.TaskSelectedForEdit(It.Is<ToDo>(task =>
                    task.Name == "Pour a whisky"
                ))
            );
        }

        [TestMethod]
        public void GivenTheTaskIsSelectedForEdit_WhenANewNameIsSupplied_ThenItIsUpdated()
        {
            // A
            _sut!.NewTaskSpecified("Pour a Irish whiskey");
            _sut!.RequestEditingTask(1);
            var viewMock = new Mock<ITaskView>();
            // A
            _sut!.TaskNameUpdate(new(1, "Pour a Scotch whisky"));
            // A
            _sut!.PreparingTaskList(viewMock.Object);
            viewMock.Verify(view =>
                view.IncompleteTasks(It.Is<ToDo[]>(tasks =>
                    tasks[0].Name == "Pour a Scotch whisky"
                ))
            );
        }
    }
}
