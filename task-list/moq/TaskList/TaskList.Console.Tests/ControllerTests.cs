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
        private Mock<IModel>? _modelMock;
        private Controller.Controller? _sut;

        [TestInitialize]
        public void Setup()
        {
            _terminatorMock = new Mock<Terminator>();
            _viewSelectorMock = new Mock<IViewSelector>();
            _modelMock = new Mock<IModel>();
            _sut = new Controller.Controller(
                _terminatorMock.Object, 
                _viewSelectorMock.Object,
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
            _viewSelectorMock!.Verify(view => view.AddingTask());
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
            _viewSelectorMock!.Verify(view => view.AtMainMenu());
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
            _viewSelectorMock!.Verify(view => view.AtMainMenu());
        }
    }
}
