using System;

namespace MinesweeperSolverDemo.Lib.Solver
{
public class GameSolver
{
    protected int GetWidth()
    {
        Console.Write("Please enter the width of the board: ");
        string widthEntered = Console.ReadLine();
        bool isValid = int.TryParse(widthEntered, out var width);
        return isValid ? width : -1;
    }

    protected int GetHeight()
    {
        Console.Write("Please enter the height of the board: ");
        string heightEntered = Console.ReadLine();
        bool isValid = int.TryParse(heightEntered, out var height);
        return isValid ? height : -1;
    }

    protected int GetMines()
    {
        Console.Write("Please enter the number of mines on each board: ");
        string minesEntered = Console.ReadLine();
        bool isValid = int.TryParse(minesEntered, out var mines);
        return isValid ? mines : -1;
    }

    protected int GetBoards()
    {
        Console.Write("Please enter the number of board to be solved: ");
        string boardsEntered = Console.ReadLine();
        bool isValid = int.TryParse(boardsEntered, out var boards);
        return isValid ? boards : -1;
    }

    protected void WidthErrors(int width)
    {
        if (width == 0)
        {
            Console.WriteLine("The width of the board must be greater than 0.");
        }
        else if (width < 0)
        {
            Console.WriteLine("Please enter a valid positive number for the width.");
        }
    }

    protected void HeightErrors(int height)
    {
        if (height == 0)
        {
            Console.WriteLine("The height of the board must be greater than 0.");
        }
        else if (height < 0)
        {
            Console.WriteLine("Please enter a valid positive number for the height.");
        }
    }

    protected void MinesErrors(int mines)
    {
        if (mines == 0)
        {
            Console.WriteLine("The number of mines must be greater than 0.");
        }
        else if (mines < 0)
        {
            Console.WriteLine("Please enter a valid positive number for the number of mines on the board.");
        }
    }

    protected void BoardsErrors(int boards)
    {
        if (boards == 0)
        {
            Console.WriteLine("The number of boards must be greater than 0.");
        }
        else if (boards < 0)
        {
            Console.WriteLine("Please enter a valid positive number for the number of boards to be solved.");
        }
    }
}
}
