using Moq;

namespace TaskList.Console.Tests
{
    [TestClass]
    public class ControllerTests
    {
        private Mock<Terminator>? _terminatorMock;
        private Controller.Controller? _sut;

        [TestInitialize]
        public void Setup()
        {
            _terminatorMock = new Mock<Terminator>();
            _sut = new Controller.Controller(_terminatorMock.Object);
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
    }
}
