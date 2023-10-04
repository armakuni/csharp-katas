using Moq;
using System.Text;
using TaskList.Console.Model;
using TaskList.Console.Views;

namespace TaskList.Console.Tests
{
    [TestClass]
    public class ControllerTests
    {
        private Mock<Terminator>? _terminatorMock;
        private Mock<IViewSelector>? _viewSelectorMock;
        private Mock<IErrorView>? _errorViewMock;
        private Mock<IModel>? _modelMock;
        private Controller.Controller? _sut;

        [TestInitialize]
        public void Setup()
        {
            _terminatorMock = new Mock<Terminator>();
            _viewSelectorMock = new Mock<IViewSelector>();
            _errorViewMock = new Mock<IErrorView>();
            _modelMock = new Mock<IModel>();
            _sut = new Controller.Controller(
                _terminatorMock.Object, 
                _viewSelectorMock.Object,
                _errorViewMock.Object,
                _modelMock.Object
            );
        }

        [TestMethod]
        public void WhenTheUserChoosesToQuit_ThenTheProgramExits()
        {
            // A
            var input = new StringReader("Q");
            _sut!.HandleUserInput(input);
            // A
            _terminatorMock!.Verify(terminator => terminator.Exit());
        }

        [TestMethod]
        public void WhenTheUserChoosesToAddATask_ThenTheControllerNotifiesTheView()
        {
            // A 
            var input = new StringReader("a");
            _sut!.HandleUserInput(input);
            // A
            _viewSelectorMock!.Verify(view => view.AddingTaskMode());
        }

        [TestMethod]
        public void GivenTheUserChoosesToAddATask_WhenTheUserEntersNothing_ThenTheControllerNotifiesTheView()
        {
            // A
            var userInput = new StringBuilder();
            userInput.AppendLine("a"); // add a task
            userInput.AppendLine(""); // but enter nothing for the task name
            var input = new StringReader(userInput.ToString());
            _sut!.HandleUserInput(input);
            // A
            _viewSelectorMock!.Verify(view => view.MainMenuMode());
        }

        [TestMethod]
        public void GivenTheUserChoosesToAddATask_WhenTheUserEntersATaskName_ThenTheControllerNotifiesTheModel()
        {
            // A
            var userInput = new StringBuilder();
            userInput.AppendLine("a"); // add a task
            userInput.AppendLine("Do the dishes"); // then the task name
            var input = new StringReader(userInput.ToString());
            _sut!.HandleUserInput(input);
            // A
            _modelMock!.Verify(model => model.NewTaskSpecified("Do the dishes"));
        }

        [TestMethod]
        public void GivenTheUserChoosesToAddATask_WhenTheTaskHasBeenAdded_ThenTheControllerNotifiesTheView()
        {
            // A
            var userInput = new StringBuilder();
            userInput.AppendLine("a"); // add a task
            userInput.AppendLine("Do the dishes"); // then the task name
            var input = new StringReader(userInput.ToString());
            _sut!.HandleUserInput(input);
            // A
            _viewSelectorMock!.Verify(view => view.MainMenuMode());
        }

        [TestMethod]
        public void GivenATaskExists_WhenTheUserChoosesToEditIt_ThenTheControllerNotifiesTheView()
        {
            // A
            var input = new StringReader("1");
            _sut!.HandleUserInput(input);
            // A
            _modelMock!.Verify(model => model.EditingTask(1));
        }

        [TestMethod]
        public void GivenTheTaskDoesNotExist_WhenTheUserAttemptsToEditIt_ThenTheControllerNotifiesTheView()
        {
            // A
            _modelMock!
                .Setup(model => model.EditingTask(It.IsAny<int>()))
                .Returns(false); // returning false indicates the task can not be edited
            // A
            var input = new StringReader("69");
            _sut!.HandleUserInput(input);
            // A
            _errorViewMock!.Verify(view => view.ErrorOccurred("69 is not a valid task id for editing"));
        }

        [TestMethod]
        public void WhenTheUserAttemptsToEditATaskUsingAnInvalidTaskId_ThenTheControllerNotifiesTheView()
        {
            // A
            var input = new StringReader("fish");
            _sut!.HandleUserInput(input);
            // A
            _errorViewMock!.Verify(view => view.ErrorOccurred($"fish is not a valid task id for editing"));
        }

        [TestMethod]
        public void GivenTheTaskExists_WhenTheUserAttemptsToEditIt_ThenTheControllerNotifiesTheView()
        {
            // A
            _modelMock!
                .Setup(model => model.EditingTask(It.IsAny<int>()))
                .Returns(true); // returning true indicates that the task is selected for edit
            // A
            var input = new StringReader("2");
            _sut!.HandleUserInput(input);
            // A
            _viewSelectorMock!.Verify(view => view.EditingTaskMode());
        }

        [TestMethod]
        public void GivenTheUserChoosesToEditATask_AndTheyChooseToChangeTheName_ThenTheControllerNotifiesTheView()
        {
            // A
            _modelMock!
                .Setup(model => model.EditingTask(It.IsAny<int>()))
                .Returns(true);
            // A
            var userInput = new StringBuilder();
            userInput.AppendLine("1");
            userInput.AppendLine("C");
            var input = new StringReader(userInput.ToString());
            _sut!.HandleUserInput(input);
            // A
            _viewSelectorMock!.Verify(view => view.ChangingTaskNameMode());
        }

        [TestMethod]
        public void GivenTheUserChoosesToEditATask_AndTheyChooseToChangeTheName_WhenTheyEnterTheName_ThenTheControllerNotifiesTheModel_AndItNotifiesTheView()
        {
            // A
            _modelMock!
                .Setup(model => model.EditingTask(It.IsAny<int>()))
                .Returns(true);
            // A
            var userInput = new StringBuilder();
            userInput.AppendLine("1");
            userInput.AppendLine("C");
            userInput.AppendLine("New name for the task");
            var input = new StringReader(userInput.ToString());
            _sut!.HandleUserInput(input);
            // A
            _modelMock!.Verify(model => model.UpdatingTaskName(new ToDo(1, "New name for the task")));
            _viewSelectorMock!.Verify(view => view.MainMenuMode());
        }

        [TestMethod]
        public void GivenTheUserChoosesToEditATask_AndTheyChooseToChangeTheName_IfTheyEnterNothing_ThenTheControllerDoesNotNotifyTheModelOfAnyChanges_AndItNotifiesTheView()
        {
            // A
            _modelMock!
                .Setup(model => model.EditingTask(It.IsAny<int>()))
                .Returns(true);
            // A
            var userInput = new StringBuilder();
            userInput.AppendLine("1");
            userInput.AppendLine("C");
            userInput.AppendLine();
            var input = new StringReader(userInput.ToString());
            _sut!.HandleUserInput(input);
            // A
            _modelMock!.Verify(
                model => model.UpdatingTaskName(new ToDo(1, "New name for the task")),
                Times.Never
            );
            _viewSelectorMock!.Verify(view => view.MainMenuMode());
        }

        [TestMethod]
        public void GivenTheUserChoosesToEditATask_AndTheyChooseToCompleteTheTask_ThenTheControllerNotifiesTheModel_AndItNotifiesTheView()
        {
            // A
            _modelMock!
                .Setup(model => model.EditingTask(It.IsAny<int>()))
                .Returns(true);
            // A
            var userInput = new StringBuilder();
            userInput.AppendLine("1");
            userInput.AppendLine("O");
            var input = new StringReader(userInput.ToString());
            _sut!.HandleUserInput(input);
            // A
            _modelMock!.Verify(model => model.CompletingTask(1));
            _viewSelectorMock!.Verify(view => view.MainMenuMode());
        }

    }
}
