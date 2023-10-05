namespace GameOfLife.Console.Tests
{
    [TestClass]
    public class GenerationTests
    {
        [TestMethod]
        public void WhenItIsAlive_CellDiesWithFewerThanTwoNeighbours()
        {
            // Arrange
            Cell cell = new()
            {
                IsAlive = true,
                Neighbours = 1
            };
            // Act
            cell.Calculate();
            // Assert
            Assert.IsFalse(cell.IsAlive, "Cell dies if it has fewer than two neighbours");
        }

        [TestMethod]
        public void WhenItIsAlive_CellSurvivesWithTwoLiveNeighbours()
        {
            // Arrange
            Cell cell = new()
            {
                IsAlive = true,
                Neighbours = 2
            };
            // Act
            cell.Calculate();
            // Assert
            Assert.IsTrue(cell.IsAlive, "Cell lives if it has two neighbours");
        }
    }
}