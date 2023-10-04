namespace GameOfLife.Console
{
    public class Generation
    {
        public string Render() => 
            string.Join(
                Environment.NewLine,
                new[] {
                    "........",
                    "........",
                    "........",
                    "........"
                }
            );
    }
}
