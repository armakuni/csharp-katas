namespace GameOfLife.Console.Tests
{
    [TestClass]
    public class GenerationTests
    {
        [TestMethod]
        public void WhenIRenderTheGeneration_ThenItRendersAnEmptyBoard()
        {
            // Arrange (Given some starting point)
            var generation1 = new Generation();

            // Act (When I do something)
            string? output = generation1.Render();

            // Assert (Then certain things happen)
            var expected = string.Join(
                Environment.NewLine,
                new[] {
                    "........",
                    "........",
                    "........",
                    "........"
                }
            );
            Assert.AreEqual(expected, output);
        }
    }
}