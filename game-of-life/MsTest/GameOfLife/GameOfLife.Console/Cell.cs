namespace GameOfLife.Console;

public class Cell
{
    public bool IsAlive { get; set; } = false;
    public int Neighbours { get; set; }

    public void Calculate()
    {
        
    }
}