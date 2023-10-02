using Moq;
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
            _sut!.Render();
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
            _sut!.Render();
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
            _sut!.Render();
            // A
            _outputMock!.Verify(output => output.WriteLine("You have no tasks"));
        }

        [TestMethod]
        public void WhenItRenders_ThenItRendersTheCommandPrompt()
        {
            // A
            _sut!.Render();
            // A
            _outputMock!.Verify(output => output.Write("(A)dd a task (Q)uit (or enter a task id): "));
        }

        [TestMethod]
        public void GivenAnErrorHasOccurred_WhenItRenders_ThenItRendersTheError()
        {
            // A
            _sut!.ErrorOccurred("The id you entered doesn't belong to an active task");
            // A
            _sut!.Render();
            // A
            _outputMock!.Verify(output => output.WriteLine("ERROR: The id you entered doesn't belong to an active task"));
        }
        
        [TestMethod]
        public void GivenAnErrorHasOccurred_AndItHasAlreadyBeenDisplayed_WhenItRenders_ThenItDoesNotRendersTheErrorAgain()
        {
            // A
            _sut!.ErrorOccurred("BOOM!");
            // A
            _sut!.Render();
            _sut!.Render();
            // A
            _outputMock!.Verify(
                output => output.WriteLine("ERROR: BOOM!"),
                Times.Exactly(1)
            );
        }

    }
}