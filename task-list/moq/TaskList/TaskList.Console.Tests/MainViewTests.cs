using Moq;
using System.Security.Cryptography;
using TaskList.Console.Model;
using TaskList.Console.Views;

namespace TaskList.Console.Tests
{
    [TestClass]
    public class MainViewTests
    {
        private Mock<TextWriter>? _outputMock;
        private Mock<IModel>? _modelMock;
        private Main? _sut;

        [TestInitialize]
        public void Initialize()
        {
            _outputMock = new Mock<TextWriter>();
            _modelMock = new Mock<IModel>();
            _sut = new Main(_modelMock.Object, _outputMock.Object);
        }

        [TestMethod]
        public void WhenItRenders_ItShouldNotifyTheModel()
        {
            // A
            _sut!.MainMenuMode();
            // A
            _modelMock!.Verify(model => model.PreparingTaskList(_sut));
        }

        [TestMethod]
        public void GivenAListOfIncompleteTasks_WhenItRenders_ThenItRendersTheList()
        {
            // A
            _sut!.IncompleteTasks(new[]
            {
                new ToDo(1, "Wash the dishes"),
                new ToDo(2, "Wipe the table"),
                new ToDo(3, "Pour a whisky")
            });
            // A
            _sut!.MainMenuMode();
            // A
            _outputMock!.Verify(output => output.WriteLine("Tasks:"));
            _outputMock!.Verify(output => output.WriteLine("1. Wash the dishes"));
            _outputMock!.Verify(output => output.WriteLine("2. Wipe the table"));
            _outputMock!.Verify(output => output.WriteLine("3. Pour a whisky"));
        }

        [TestMethod]
        public void GivenThereAreNoIncompleteTasks_WhenItRenders_ThenItRendersAnEmptyList()
        {
            // A
            _sut!.MainMenuMode();
            // A
            _outputMock!.Verify(output => output.WriteLine("You have no tasks"));
        }

        [TestMethod]
        public void WhenItRenders_ThenItRendersTheCommandPrompt()
        {
            // A
            _sut!.MainMenuMode();
            // A
            _outputMock!.Verify(output => output.Write("(A)dd a task (Q)uit (or enter a task id): "));
        }

        [TestMethod]
        public void GivenAnErrorHasOccurred_WhenItRenders_ThenItRendersTheError()
        {
            // A
            _sut!.ErrorOccurred("The id you entered doesn't belong to an active task");
            // A
            _sut!.MainMenuMode();
            // A
            _outputMock!.Verify(output => output.WriteLine("ERROR: The id you entered doesn't belong to an active task"));
        }
        
        [TestMethod]
        public void GivenAnErrorHasOccurred_AndItHasAlreadyBeenDisplayed_WhenItRenders_ThenItDoesNotRendersTheErrorAgain()
        {
            // A
            _sut!.ErrorOccurred("BOOM!");
            // A
            _sut!.MainMenuMode();
            _sut!.MainMenuMode();
            // A
            _outputMock!.Verify(
                output => output.WriteLine("ERROR: BOOM!"),
                Times.Exactly(1)
            );
        }

        [TestMethod]
        public void WhenAddTaskModeIsSelected_ThenItRendersTheAddATaskPrompt()
        {
            // A
            _sut!.AddingTaskMode();
            // A
            _outputMock!.Verify(output => output.WriteLine("Enter a task name (or blank to cancel): "));
        }

        [TestMethod]
        public void WhenPreparingForEditMode_ItNotifiesTheModel()
        {
            // A
            _sut!.EditingTaskMode();
            // A
            _modelMock!.Verify(model => model.PreparingEditMode(_sut));

        }

        [TestMethod]
        public void WhenRenderingEditMode_ItShouldRenderTheEditPrompt()
        {
            // A
            _sut!.TaskSelectedForEdit(new(2, "Prune the roses"));
            // A
            _sut!.EditingTaskMode();
            // A
            _outputMock!.Verify(output => output.WriteLine("Editing: 2. Prune the roses"));
            _outputMock!.Verify(output => output.Write("(C)hange name or C(o)mplete task: "));
        }

        [TestMethod]
        public void WhenRenderingEditTaskNameMode_ItShouldRenderThePrompt()
        {
            // A
            _sut!.TaskSelectedForEdit(new(3, "Pour a whisky"));
            // A
            _sut!.ChangingTaskNameMode();
            // A
            _outputMock!.Verify(output => output.Write("Enter new name: "));
        }
    }
}